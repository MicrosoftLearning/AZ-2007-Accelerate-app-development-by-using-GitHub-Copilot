# Cheese Cave Device Application

This is the Python implementation of the Cheese Cave device application from the original `SampleApps` directory.

## How to Run

1. Ensure you have Python 3.7 or higher installed on your system.
2. Install the required dependencies by running:

```bash
pip install azure-iot-device
```

3. Replace `YOUR DEVICE CONNECTION STRING HERE` in the script with your Azure IoT Hub device connection string.
4. Navigate to this directory in your terminal.
5. Run the following command:

```bash
python main.py
```

## Output

The application will:
- Simulate reading temperature and humidity data.
- Send telemetry data to Azure IoT Hub.
- Update the device twin with the current conditions.
- Handle direct method calls from the cloud to control the fan.

## Notes

- Ensure the BME280 sensor and GPIO are properly configured if running on actual hardware.
- Uncomment the GPIO setup and control lines in the script for real hardware interaction. 