using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;
using Windows.Devices.Gpio;
using Windows.Networking.Sockets;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Storage.Streams;
using AdafruitClassLibrary;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Media.SpeechSynthesis;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace RobotHeadless
{
    public sealed class StartupTask : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        BackgroundTaskDeferral deferralGPIO;
        BackgroundTaskDeferral deferralMotors;
        BackgroundTaskDeferral deferralServos;
        BackgroundTaskDeferral deferralRFcomm;
        BackgroundTaskDeferral deferralSpeaking;

        private ThreadPoolTimer timerBluetoothConnection;


        // Bluetooth Communication Config
        // --------------------------------------------------------------------------------------
        private StreamSocket streamSocket;
        private StreamSocketListener socketListener;
        private RfcommServiceProvider rfcommProvider;
        private DataWriter writer;

        // The Bluetooth RFComm Server's custom service Uuid: 34B1CF4D-1069-4AD6-89B6-E161D79BE4D8
        private static readonly Guid BluetoothRfcommServiceUuid = Guid.Parse("34B1CF4D-1069-4AD6-89B6-E161D79BE4D8");


        // The Id of the Service Name SDP attribute
        private const UInt16 SdpServiceNameAttributeId = 0x100;

        // The SDP Type of the Service Name SDP attribute.
        // The first byte in the SDP Attribute encodes the SDP Attribute Type as follows :
        //    -  the Attribute Type size in the least significant 3 bits,
        //    -  the SDP Attribute Type value in the most significant 5 bits.
        private const byte SdpServiceNameAttributeType = (4 << 3) | 5;

        // The value of the Service Name SDP attribute
        private const string SdpServiceName = "Robot - Bluetooth Rfcomm Service";

        // classify the notification as either informational or problem notification 
        private enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };

        private short dcmotorRightRear;     // controls one of the DC motors used to move the robot around 
        private short dcmotorLeftRear;      // controls one of the DC motors used to move the robot around

        private short servoBodyRotation;    // controls a servo motor, upper body rotation

        private short servoRightShoulder;   // controls a servo motor, right arm shoulder joint
        private short servoLeftShoulder;    // controls a servo motor, left arm shoulder joint

        private short servoRightElbow;      // controls a servo motor, right arm elbow joint
        private short servoLeftElbow;       // controls a servo motor, left arm elbow joint

        private short servoRightHandGrip;   // controls a servo motor, right arm hand gripper
        private short servoLeftHandRotate;  // controls a servo motor, left arm camera rotation


        // Motor Hat Config
        // --------------------------------------------------------------------------------------
        // The Adafruit Class Library is a C# library for controlling various devices connected to a Raspberry Pi running Windows 10 IoT Core.

        // The MototHat object provides methods for controlling up to 4 DC motors. Uses the Adafruit MotorController Hat, which uses an I2C pin connection. The default I2C address for the Hat is 0x60
        private MotorHat motorHat;

        // DCMotor class provides control for individual DC motors 
        private MotorHat.DCMotor dcMotor1;
        private MotorHat.DCMotor dcMotor2;

        private double dcMotor1Speed;
        private double dcMotor2Speed;

        private const int LED_PIN_BLUETOOTHCONNECTION = 5;
        private const int LED_PIN_BATTERYPOWER = 6;
        private const int LED_PIN_MOTORPOWER = 12;
        private const int LED_PIN_PIPOWER = 13;

        private GpioPin pinBluetoothConnection;
        private GpioPin pinBatteryPower;
        private GpioPin pinPowerMotors;
        private GpioPin pinPowerPi;

        private GpioPinValue pinValue;


        // The Servo motor are controlled using the I2C pins. The default I2C address is 0x40 (I2C addresses for the chip are in the range 0x40 to 0x7F)
        private Pca9685 i2cServoController = new Pca9685();

        // Voice Recognition and Synthesis
        private static MediaElement media;

        private SpeechSynthesizer synthesizer;
        private ResourceContext speechContext;
        private ResourceMap speechResourceMap;


        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //
            _deferral = taskInstance.GetDeferral();

            //InitGPIO();

            deferralGPIO = taskInstance.GetDeferral();
            await InitGPIOAsync();
            deferralGPIO.Complete();

            // test
            //BlinkBluetoothLED();

            deferralMotors = taskInstance.GetDeferral();
            await InitializeMotorsAtStartup();
            deferralMotors.Complete();


            deferralServos = taskInstance.GetDeferral();
            await InitializeServosAtStartup();
            deferralServos.Complete();

            deferralRFcomm = taskInstance.GetDeferral();
            await InitializeBluetoothAtStartup();
            deferralRFcomm.Complete();


            //synthesizer = new SpeechSynthesizer();
            //media = new MediaElement();

            //speechContext = ResourceContext.GetForCurrentView();
            //speechContext.Languages = new string[] { SpeechSynthesizer.DefaultVoice.Language };

            //speechResourceMap = ResourceManager.Current.MainResourceMap.GetSubtree("LocalizationTTSResources");

            //InitializeVoice();

            //deferralSpeaking = taskInstance.GetDeferral();
            //await SpeakPhrase("My name is Norman");
            //deferralSpeaking.Complete();

        }

        private void InitGPIO()
        {
            GpioController gpio = GpioController.GetDefault();

            // initialize GPIO pin for Bluetooth Connection
            pinBluetoothConnection = gpio.OpenPin(LED_PIN_BLUETOOTHCONNECTION);
            pinValue = GpioPinValue.High;
            pinBluetoothConnection.Write(pinValue);
            pinBluetoothConnection.SetDriveMode(GpioPinDriveMode.Output);

            // initialize GPIO pin for Battery Power
            pinBatteryPower = gpio.OpenPin(LED_PIN_BATTERYPOWER);
            pinValue = GpioPinValue.Low;
            pinBatteryPower.Write(pinValue);
            pinBatteryPower.SetDriveMode(GpioPinDriveMode.Output);

            // initialize GPIO pin for Power to Motors
            pinPowerMotors = gpio.OpenPin(LED_PIN_MOTORPOWER);
            pinValue = GpioPinValue.Low;
            pinPowerMotors.Write(pinValue);
            pinPowerMotors.SetDriveMode(GpioPinDriveMode.Output);

            // initialize GPIO pin for Power to Raspberry Pi and Webcam
            pinPowerPi = gpio.OpenPin(LED_PIN_PIPOWER);
            pinValue = GpioPinValue.Low;
            pinPowerPi.Write(pinValue);
            pinPowerPi.SetDriveMode(GpioPinDriveMode.Output);


        }

        private async Task InitGPIOAsync()
        {
            // We use 4 GPIO pins to provide status information. Status is communicated by controlling collored LEDs. 
            //
            // The following GpioPin objects are created for each of the LEDs:
            //      pinBluetoothConnection (GpioPin) uses LED_PIN_BLUETOOTHCONNECTION (GPIO 5) to control a Blue LED.
            //      pinBatteryPower (GpioPin) uses LED_PIN_BATTERYPOWER (GPIO 6) to control a Red LED.
            //      pinPowerMotors (GpioPin) uses LED_PIN_MOTORPOWER (GPIO 12) to control a Green LED.
            //      pinPowerPi (GpioPin) uses LED_PIN_PIPOWER (GPIO 13) to control a Yellow LED.
            //
            // Each GpioPin object is initialized for Output and each LED is initally off.


            GpioController gpio = await GpioController.GetDefaultAsync();

            // ----------------------------------------------------------------
            // NOTE: with the way the LEDs are wired, Low is ON and High is OFF
            // ----------------------------------------------------------------

            // initialize GPIO pin for Bluetooth Connection
            pinBluetoothConnection = gpio.OpenPin(LED_PIN_BLUETOOTHCONNECTION);
            pinValue = GpioPinValue.High;
            pinBluetoothConnection.Write(pinValue);
            pinBluetoothConnection.SetDriveMode(GpioPinDriveMode.Output);

            // initialize GPIO pin for Battery Power
            pinBatteryPower = gpio.OpenPin(LED_PIN_BATTERYPOWER);
            pinValue = GpioPinValue.High;
            pinBatteryPower.Write(pinValue);
            pinBatteryPower.SetDriveMode(GpioPinDriveMode.Output);

            // initialize GPIO pin for Power to Motors
            pinPowerMotors = gpio.OpenPin(LED_PIN_MOTORPOWER);
            pinValue = GpioPinValue.High;
            pinPowerMotors.Write(pinValue);
            pinPowerMotors.SetDriveMode(GpioPinDriveMode.Output);

            // initialize GPIO pin for Power to Raspberry Pi and Webcam
            pinPowerPi = gpio.OpenPin(LED_PIN_PIPOWER);
            pinValue = GpioPinValue.High;
            pinPowerPi.Write(pinValue);
            pinPowerPi.SetDriveMode(GpioPinDriveMode.Output);

        }

        private async Task InitializeBluetoothAtStartup()
        {
            await InitializeRfcommServer();
            BlinkBluetoothLED();

        }


        private void BlinkBluetoothLED()
        {
            // set up a timer timerBluetoothConnection for a headless app 
            timerBluetoothConnection = ThreadPoolTimer.CreatePeriodicTimer(TimerBluetoothConnection_Tick, TimeSpan.FromMilliseconds(500));

        }

        private void TimerBluetoothConnection_Tick(ThreadPoolTimer timerBluetoothConnection)
        {
            pinValue = pinBluetoothConnection.Read();

            if (pinValue == GpioPinValue.High)
            {
                pinValue = GpioPinValue.Low;
            }
            else
            {
                pinValue = GpioPinValue.High;
            }

            pinBluetoothConnection.Write(pinValue);

        }

        private async Task InitializeServosAtStartup()
        {
            await i2cServoController.InitPCA9685Async();

            i2cServoController.SetPWMFrequency(250); // Frequency values between 40 and 1000Hz

            // to calculate the pulse-width in microseconds
            // 
            // 1 / frequency = 1 / 250 = 4 milliseconds = 4,000 microseconds
            // timer per "tick" = 4,000 / 4096 = .9765625 microseconds / tick.
            //
            // to get a pulse of 1000 microseconds, you need 1000 / 0.9765625 = 1024 ticks
            // to get a pulse of 1500 microseconds, you need 1500 / 0.9765625 = 1536 ticks
            // to get a pulse of 2000 microseconds, you need 2000 / 0.9765625 = 2048 ticks


            //i2cServoController.SetPWMFrequency(500); // Frequency values between 40 and 1000Hz
            // to calculate the pulse-width in microseconds
            // 
            // 1 / frequency = 1 / 500 = 2 milliseconds = 2,000 microseconds
            // timer per "tick" = 2,000 / 4096 = .48828125 microseconds / tick.
            // 
            // to get a pulse of 1000 microseconds, you need 1000 / 0.48828125 = 2048 ticks
            // to get a pulse of 1500 microseconds, you need 1500 / 0.48828125 = 3072 ticks
            // to get a pulse of 2000 microseconds, you need 2000 / 0.48828125 = 4096 ticks
        }


        /// <summary>
        /// Initializes the server using RfcommServiceProvider to advertise the Bluetooth RFComm Service UUID and start listening
        /// for incoming connections.
        /// </summary>
        private async Task InitializeRfcommServer()
        {
            //ListenButton.IsEnabled = false;
            //DisconnectButton.IsEnabled = true;

            try
            {
                rfcommProvider = await RfcommServiceProvider.CreateAsync(RfcommServiceId.FromUuid(BluetoothRfcommServiceUuid));
            }
            // Catch exception HRESULT_FROM_WIN32(ERROR_DEVICE_NOT_AVAILABLE).
            catch (Exception ex) when ((uint)ex.HResult == 0x800710DF)
            {
                // The Bluetooth radio may be off.
                //NotifyUser("Make sure your Bluetooth Radio is on: " + ex.Message, NotifyType.ErrorMessage);
                //ListenButton.IsEnabled = true;
                //DisconnectButton.IsEnabled = false;

                return;
            }


            // Create a listener for this service and start listening
            socketListener = new StreamSocketListener();
            socketListener.ConnectionReceived += OnConnectionReceived;
            //var rfcomm = rfcommProvider.ServiceId.AsString(); 

            await socketListener.BindServiceNameAsync(rfcommProvider.ServiceId.AsString(), SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);

            // Set the SDP attributes and start Bluetooth advertising
            InitializeServiceSdpAttributes(rfcommProvider);

            try
            {
                rfcommProvider.StartAdvertising(socketListener, true);
            }
            catch (Exception e)
            {
                // If you aren't able to get a reference to an RfcommServiceProvider, tell the user why.  Usually throws an exception if user changed their privacy settings to prevent Sync w/ Devices.  
                //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                //{
                //    NotifyUser(e.Message, NotifyType.ErrorMessage);

                //    ListenButton.IsEnabled = true;
                //    DisconnectButton.IsEnabled = false;

                //});

                return;
            }

            //NotifyUser("Listening for incoming connections", NotifyType.StatusMessage);


        }

        private async void OnConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            // Don't need the listener anymore
            socketListener.Dispose();
            socketListener = null;

            try
            {
                streamSocket = args.Socket;
            }
            catch (Exception e)
            {
                Disconnect();

                //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                //{
                //    NotifyUser(e.Message, NotifyType.ErrorMessage);

                //    // turn off the Bluetooth connection LED
                //    BluetoothDisonnected();

                //});

                BluetoothDisonnected();

                return;
            }


            // ------------------------------------------------------------------------------
            // Note - this is the supported way to get a Bluetooth device from a given streamSocket
            // ------------------------------------------------------------------------------
            var remoteDevice = await BluetoothDevice.FromHostNameAsync(streamSocket.Information.RemoteHostName);

            writer = new DataWriter(streamSocket.OutputStream);
            var reader = new DataReader(streamSocket.InputStream);
            bool remoteDisconnection = false;

            //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            //{
            //    NotifyUser("Connected to Client: " + remoteDevice.Name, NotifyType.StatusMessage);

            //    BluetoothConnected();
            //});

            BluetoothConnected();


            // Infinite read buffer loop
            while (true)
            {
                try
                {
                    // Based on the protocol we've defined, the first uint is the size of the message
                    uint readLength = await reader.LoadAsync(sizeof(uint));

                    // Check if the size of the data is expected (otherwise the remote has already terminated the connection)
                    if (readLength < sizeof(uint))
                    {
                        remoteDisconnection = true;
                        break;
                    }
                    uint currentLength = reader.ReadUInt32();

                    // Load the rest of the message since you already know the length of the data expected.  
                    readLength = await reader.LoadAsync(currentLength);

                    // Check if the size of the data is expected (otherwise the remote has already terminated the connection)
                    if (readLength < currentLength)
                    {
                        remoteDisconnection = true;
                        break;
                    }
                    string message = reader.ReadString(currentLength);

                    //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    //{
                    //    ConversationListBox.Items.Add("Received: " + message);

                    //});

                    //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    //{
                    //    LastMessageReceived.Text = message;

                    //});



                    // ==============================================================================================
                    //                                     MESSAGE RECEIVED
                    // ==============================================================================================

                    try
                    {
                        // parse the message into Command components
                        string[] motorCommands = new string[9];

                        motorCommands = message.Split(new char[] { ',' });

                        dcmotorLeftRear = Convert.ToInt16(motorCommands[0]);
                        dcmotorRightRear = Convert.ToInt16(motorCommands[1]);

                        servoBodyRotation = Convert.ToInt16(motorCommands[2]);

                        servoLeftShoulder = Convert.ToInt16(motorCommands[3]);
                        servoRightShoulder = Convert.ToInt16(motorCommands[4]);

                        servoLeftElbow = Convert.ToInt16(motorCommands[5]);
                        servoRightElbow = Convert.ToInt16(motorCommands[6]);

                        servoLeftHandRotate = Convert.ToInt16(motorCommands[7]);
                        servoRightHandGrip = Convert.ToInt16(motorCommands[8]);

                    }
                    catch
                    {
                        //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        //{
                        //    NotifyUser("Error parsing robot motor control string", NotifyType.StatusMessage);
                        //});

                    }

                    // control the DC motors
                    try
                    {

                        // 
                        dcMotor1Speed = dcmotorLeftRear;
                        uint m1Speed = 0;
                        dcMotor1.Run(MotorHat.DCMotor.Command.RELEASE);
                        if (dcmotorLeftRear > 0)
                        {
                            dcMotor1.Run(MotorHat.DCMotor.Command.FORWARD);
                        }
                        else if (dcmotorLeftRear < 0)
                        {
                            dcMotor1.Run(MotorHat.DCMotor.Command.BACKWARD);
                            dcMotor1Speed = -dcMotor1Speed;
                        }
                        m1Speed = (uint)dcMotor1Speed;
                        dcMotor1.SetSpeed(m1Speed);

                        //
                        dcMotor2Speed = dcmotorRightRear;
                        uint m2Speed = 0;
                        dcMotor2.Run(MotorHat.DCMotor.Command.RELEASE);
                        if (dcmotorRightRear > 0)
                        {
                            dcMotor2.Run(MotorHat.DCMotor.Command.FORWARD);
                        }
                        else if (dcmotorRightRear < 0)
                        {
                            dcMotor2.Run(MotorHat.DCMotor.Command.BACKWARD);
                            dcMotor2Speed = -dcMotor2Speed;
                        }
                        m2Speed = (uint)dcMotor2Speed;
                        dcMotor2.SetSpeed(m2Speed);
                    }
                    catch
                    {

                    }


                    // Control the Servo Motors
                    //
                    //  value = number of timer ticks (0 .. 4096)
                    //
                    //      servoBodyRotation 
                    //      servoLeftShoulder 
                    //      servoRightShoulder 
                    //      servoLeftElbow 
                    //      servoRightElbow 
                    //      servoLeftHandRotate 
                    //      servoRightHandGrip 
                    //
                    //
                    try
                    {
                        // i2cServoController.SetPWM is used to set the PWM on a specified pin. 
                        //
                        //  Arguments are the pin number (channel), the on time (pulse start), and the off time (pulse end). 
                        //
                        //  You specify the 'tick' value between 0..4095 when the signal will turn on, and when it will turn off. Channel 
                        //  indicates which of the 16 PWM outputs (0 based) should be updated with the new values.
                        //
                        //  SetPWM(int num, ushort on, ushort off)
                        //
                        //
                        // Calculations
                        //
                        //  Use the following formula to calculate the pulse-width in microseconds (based on the specified frequency that you define)
                        //
                        //      pw = 1 / frequency / (off - on) 
                        //
                        //  Use the following formula to calculate the time per "tick" (based on the specified frequency that you define)
                        //
                        //      time per "tick" = 1 / frequency / 4096
                        //
                        //  If you specify a frequency of 250Hz
                        //
                        //      1 / frequency = 1 / 250 = 4 milliseconds = 4,000 microseconds
                        //
                        //      The time per tick = 4,000 / 4096 = .9765625 microseconds (per tick).
                        //
                        //  Power HD 1501MG Servo Specs (this larger servo is used in the body/shoulders)
                        //      https://www.pololu.com/file/download/HD-1501MG.pdf?file_id=0J729
                        //      Control System: Pulse width modulation
                        //      Amplifier type: Analog controller
                        //      Operating travel: 45 degrees (when going from a 1500 to 2000 micro second pulse width)
                        //      Neutral position: 1500 micro seconds
                        //      Dead band width: 2 micro seconds
                        //
                        //                          ================
                        //      Rotating direction: Counterclockwise (when going from a 1500 to 2000 micro second pulse width)
                        //                          ================
                        //
                        //      Pulse width range: 800 -> 2200 microseconds
                        //      Maximum travel: Approximately 165 degrees (when going from a 800 to 2200 micro second pulse width)
                        //
                        //      to get a pulse of 800 microseconds,  you need  800 / 0.9765625 =  819 ticks ( 82 degrees)
                        //      to get a pulse of 1000 microseconds, you need 1000 / 0.9765625 = 1024 ticks ( 45 degrees)
                        //      to get a pulse of 1500 microseconds, you need 1500 / 0.9765625 = 1536 ticks (  0 degrees)
                        //      to get a pulse of 2000 microseconds, you need 2000 / 0.9765625 = 2048 ticks (-45 degrees)
                        //      to get a pulse of 2200 microseconds, you need 2200 / 0.9765625 = 2253 ticks (-82 degrees)

                        //
                        //  Power HD 1810MG Servo Specs (this smaller servo is used in the elbow and hands)
                        //      https://www.pololu.com/file/download/HD-1810MG.pdf?file_id=0J508
                        //      Control System: Pulse width modulation
                        //      Amplifier type: Digital controller
                        //      Operating travel: 45 degrees (when going from a 1500 to 2000 micro second pulse width)
                        //      Neutral position: 1500 micro seconds
                        //      Dead band width: 5 micro seconds
                        //
                        //                          =========
                        //      Rotating direction: Clockwise (when going from a 1500 to 2000 micro second pulse width)
                        //                          =========
                        //
                        //      Pulse width range: 750 -> 2250 microseconds
                        //      Maximum travel: Approximately 145 degrees (when going from a 750 to 2250 micro second pulse width)
                        //

                        //  to get a pulse of 750 microseconds, you need   750 / 0.9765625 =  768 ticks (-72 degrees)
                        //  to get a pulse of 1000 microseconds, you need 1000 / 0.9765625 = 1024 ticks (-45 degrees)
                        //  to get a pulse of 1500 microseconds, you need 1500 / 0.9765625 = 1536 ticks (  0 degrees)
                        //  to get a pulse of 2000 microseconds, you need 2000 / 0.9765625 = 2048 ticks ( 45 degrees)
                        //  to get a pulse of 2250 microseconds, you need 2250 / 0.9765625 = 2304 ticks ( 72 degrees)



                        //  servoBodyRotation
                        int servoChannel = 15;
                        ushort servo1OnTime = 0;
                        ushort servo1OffTime = (ushort)servoBodyRotation;
                        i2cServoController.SetPWM(servoChannel, servo1OnTime, servo1OffTime);
                        //int pw = (int)(servoBodyRotation * 0.9765625);


                        //  servoLeftShoulder 
                        servoChannel = 1;
                        servo1OnTime = 0;
                        servo1OffTime = (ushort)servoRightShoulder;
                        i2cServoController.SetPWM(servoChannel, servo1OnTime, servo1OffTime);
                        //int pw = (int)(servoRightShoulder * 0.9765625);


                        //  servoRightShoulder 
                        servoChannel = 2;
                        servo1OnTime = 0;
                        servo1OffTime = (ushort)servoLeftShoulder;
                        i2cServoController.SetPWM(servoChannel, servo1OnTime, servo1OffTime);
                        //int pw = (int)(servoLeftShoulder * 0.9765625);


                        //  servoLeftElbow 
                        servoChannel = 3;
                        servo1OnTime = 0;
                        servo1OffTime = (ushort)servoRightShoulder;
                        i2cServoController.SetPWM(servoChannel, servo1OnTime, servo1OffTime);
                        //int pw = (int)(servoRightShoulder * 0.9765625);


                        //  servoRightElbow 
                        servoChannel = 4;
                        servo1OnTime = 0;
                        servo1OffTime = (ushort)servoLeftShoulder;
                        i2cServoController.SetPWM(servoChannel, servo1OnTime, servo1OffTime);
                        //int pw = (int)(servoLeftShoulder * 0.9765625);


                        //  servoLeftHandRotate 
                        servoChannel = 5;
                        servo1OnTime = 0;
                        servo1OffTime = (ushort)servoLeftHandRotate;
                        i2cServoController.SetPWM(servoChannel, servo1OnTime, servo1OffTime);
                        //int pw = (int)(servoLeftHandRotate * 0.9765625);


                        //  servoRightHandGrip 
                        servoChannel = 6;
                        servo1OnTime = 0;
                        servo1OffTime = (ushort)servoRightHandGrip;
                        i2cServoController.SetPWM(servoChannel, servo1OnTime, servo1OffTime);
                        //int pw = (int)(servoRightHandGrip * 0.9765625);

                    }
                    catch
                    {

                    }



                }
                // Catch exception HRESULT_FROM_WIN32(ERROR_OPERATION_ABORTED).
                catch (Exception ex) when ((uint)ex.HResult == 0x800703E3)
                {
                    //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    //{
                    //    NotifyUser("Client Disconnected Successfully", NotifyType.StatusMessage);
                    //});
                    break;
                }
            }

            reader.DetachStream();
            if (remoteDisconnection)
            {
                Disconnect();

                //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                //{
                //    NotifyUser("Client disconnected", NotifyType.StatusMessage);

                //    // turn off the Bluetooth connection LED
                //    BluetoothDisonnected();

                //});

                // turn off the Bluetooth connection LED
                BluetoothDisonnected();


            }
        }

        /// <summary>
        /// Creates the SDP record that will be revealed to the Client device when pairing occurs.  
        /// </summary>
        /// <param name="rfcommProvider">The RfcommServiceProvider that is being used to initialize the server</param>
        private void InitializeServiceSdpAttributes(RfcommServiceProvider rfcommProvider)
        {
            var sdpWriter = new DataWriter();

            // Write the Service Name Attribute.
            sdpWriter.WriteByte(SdpServiceNameAttributeType);

            // The length of the UTF-8 encoded Service Name SDP Attribute.
            sdpWriter.WriteByte((byte)SdpServiceName.Length);

            // The UTF-8 encoded Service Name value.
            sdpWriter.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            sdpWriter.WriteString(SdpServiceName);

            // Set the SDP Attribute on the RFCOMM Service Provider.
            rfcommProvider.SdpRawAttributes.Add(SdpServiceNameAttributeId, sdpWriter.DetachBuffer());
        }


        private void Disconnect()
        {
            if (rfcommProvider != null)
            {
                rfcommProvider.StopAdvertising();
                rfcommProvider = null;
            }

            if (socketListener != null)
            {
                socketListener.Dispose();
                socketListener = null;
            }

            if (writer != null)
            {
                writer.DetachStream();
                writer = null;
            }

            if (streamSocket != null)
            {
                streamSocket.Dispose();
                streamSocket = null;
            }
            //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            //{
            //    ListenButton.IsEnabled = true;
            //    DisconnectButton.IsEnabled = false;
            //    ConversationListBox.Items.Clear();

            //});
        }

        private void BluetoothDisonnected()
        {
            //
            //if (timerBluetoothConnection.IsEnabled == true)
            //{
            //    timerBluetoothConnection.Stop();
            //}

            timerBluetoothConnection.Cancel();

            // with the way the LEDs are wired, Low is ON and High is OFF
            pinValue = GpioPinValue.High;
            pinBluetoothConnection.Write(pinValue);
        }


        private void BluetoothConnected()
        {
            //if (timerBluetoothConnection.IsEnabled == true)
            //{
            //    timerBluetoothConnection.Stop();
            //}

            timerBluetoothConnection.Cancel();

            // with the way the LEDs are wired, Low is ON and High is OFF
            pinValue = GpioPinValue.Low;
            pinBluetoothConnection.Write(pinValue);
        }



        // ===========================================================================================================
        //                                            INITIALIZE MOTOR CONTROL
        // ===========================================================================================================

        private async Task InitializeMotorsAtStartup()
        {
            await InitializeMotorHatAsync();
            InitializeDCMotors();

        }


        private void InitializeDCMotors()
        {
            dcMotor1.Run(MotorHat.DCMotor.Command.RELEASE);
            dcMotor1.SetSpeed(0);

            dcMotor2.Run(MotorHat.DCMotor.Command.RELEASE);
            dcMotor2.SetSpeed(0);
        }

        private async Task InitializeMotorHatAsync()
        {
            motorHat = new MotorHat();

            await motorHat.InitAsync(1600).ConfigureAwait(false);

            dcMotor1 = motorHat.GetMotor(1);  //motor port 1
            dcMotor2 = motorHat.GetMotor(2);  //motor port 2

        }

        private void InitializeVoice()
        {
            // Get all of the installed voices.
            var voices = SpeechSynthesizer.AllVoices;

            // Get the currently selected voice.
            VoiceInformation currentVoice = synthesizer.Voice;

            //foreach (VoiceInformation voice in voices.OrderBy(p => p.Language))
            //{
            //    ComboBoxItem item = new ComboBoxItem();
            //    item.Name = voice.DisplayName;
            //    item.Tag = voice;
            //    item.Content = voice.DisplayName + " (Language: " + voice.Language + ")";
            //    listboxVoiceChooser.Items.Add(item);

            //    // Check to see if we're looking at the current voice and set it as selected in the listbox.
            //    if (currentVoice.Id == voice.Id)
            //    {
            //        item.IsSelected = true;
            //        listboxVoiceChooser.SelectedItem = item;
            //    }
            //}



            //private void ListboxVoiceChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
            //{
            //    ComboBoxItem item = (ComboBoxItem)(listboxVoiceChooser.SelectedItem);
            //    VoiceInformation voice = (VoiceInformation)(item.Tag);
            //    synthesizer.Voice = voice;

            //    // update UI text to be an appropriate default translation.
            //    speechContext.Languages = new string[] { voice.Language };
            //    textToSynthesize.Text = speechResourceMap.GetValue("SynthesizeTextDefaultText", speechContext).ValueAsString;
            //}

        }

        private async Task SpeakPhrase(string phrase)
        {
            // If the media is playing, the user has pressed the button to stop the playback.
            if (media.CurrentState == MediaElementState.Playing)
            {
                media.Stop();
            }
            else
            {
                if (!String.IsNullOrEmpty(phrase))
                {

                    try
                    {
                        // Create a stream from the text. This will be played using a media element.
                        SpeechSynthesisStream synthesisStream = await synthesizer.SynthesizeTextToStreamAsync(phrase);

                        // Set the source and start playing the synthesized audio stream.
                        media.AutoPlay = true;
                        media.SetSource(synthesisStream, synthesisStream.ContentType);
                        media.Play();
                    }
                    catch
                    {

                    }
                }
            }

        }
    }
}

