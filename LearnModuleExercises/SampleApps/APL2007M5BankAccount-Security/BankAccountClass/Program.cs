namespace BankAccountApp
{
    class Program
    {
        private static readonly Random random = new Random();
        private const int MaxYearsBack = 10;
        private const int NumberOfAccounts = 20;
        private const int NumberOfTransactions = 100;
        private const double minTransactionAmount = -500.0;
        private const double maxTransactionAmount = 500.0;
        private const double minAccountStart = 200.0;
        private const double maxAccountStart = 1000.0;

        static async Task Main()
        {
            List<BankAccount> accounts = CreateBankAccounts(NumberOfAccounts);
            await SimulateTransactionsAsync(accounts, NumberOfTransactions, minTransactionAmount, maxTransactionAmount);
            await SimulateTransfersAsync(accounts, NumberOfTransactions, minTransactionAmount, maxTransactionAmount);
        }

        static List<BankAccount> CreateBankAccounts(int numberOfAccounts)
        {
            List<BankAccount> accounts = new();
            int createdAccounts = 0;
            while (createdAccounts < numberOfAccounts)
            {
                try
                {
                    double initialBalance = GenerateRandomDollarAmount(true, minAccountStart, maxAccountStart);
                    string accountHolderName = GenerateRandomAccountHolder();
                    string accountType = GenerateRandomAccountType();
                    DateTime dateOpened = GenerateRandomDateOpened();
                    string accountNumber = "102000" + random.Next(1000, 9999).ToString();
                    BankAccount account = new(accountNumber, initialBalance, accountHolderName, accountType, dateOpened);
                    accounts.Add(account);
                    createdAccounts++;

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Account creation failed due to invalid argument: {ex.Message}");
                    // Log the exception
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Account creation failed: {ex.Message}");
                    // Log the exception
                }
                finally
                {
                    // Any cleanup code would go here.
                }
            }
            return accounts;
        }

        static async Task SimulateTransactionsAsync(List<BankAccount> accounts, int numberOfTransactions, double minTransactionAmount, double maxTransactionAmount)
        {
            var tasks = accounts.Select(async account =>
            {
                for (int i = 0; i < numberOfTransactions; i++)
                {
                    double transactionAmount = GenerateRandomDollarAmount(false, minTransactionAmount, maxTransactionAmount);
                    try
                    {
                        if (transactionAmount >= 0)
                        {
                            account.Credit(transactionAmount);
                            Console.WriteLine($"Credit: {transactionAmount}, Balance: {account.Balance.ToString("C")}, Account Holder: {account.AccountHolderName}, Account Type: {account.AccountType}");
                        }
                        else
                        {
                            account.Debit(-transactionAmount);
                            Console.WriteLine($"Debit: {transactionAmount}, Balance: {account.Balance.ToString("C")}, Account Holder: {account.AccountHolderName}, Account Type: {account.AccountType}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Transaction failed: {ex.Message}");
                    }
                }

                Console.WriteLine($"Account: {account.AccountNumber}, Balance: {account.Balance.ToString("C")}, Account Holder: {account.AccountHolderName}, Account Type: {account.AccountType}");
            });

            await Task.WhenAll(tasks);
        }

        static async Task SimulateTransfersAsync(List<BankAccount> accounts, int numberOfTransactions, double minTransactionAmount, double maxTransactionAmount)
        {
            var tasks = accounts.Select(async account =>
            {
                for (int i = 0; i < numberOfTransactions; i++)
                {
                    double transactionAmount = GenerateRandomDollarAmount(false, minTransactionAmount, maxTransactionAmount);
                    try
                    {
                        if (transactionAmount >= 0)
                        {
                            account.Credit(transactionAmount);
                            Console.WriteLine($"Credit: {transactionAmount}, Balance: {account.Balance.ToString("C")}, Account Holder: {account.AccountHolderName}, Account Type: {account.AccountType}");
                        }
                        else
                        {
                            account.Debit(-transactionAmount);
                            Console.WriteLine($"Debit: {transactionAmount}, Balance: {account.Balance.ToString("C")}, Account Holder: {account.AccountHolderName}, Account Type: {account.AccountType}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Transaction failed: {ex.Message}");
                    }
                }

                Console.WriteLine($"Account: {account.AccountNumber}, Balance: {account.Balance.ToString("C")}, Account Holder: {account.AccountHolderName}, Account Type: {account.AccountType}");
            });

            await Task.WhenAll(tasks);
        }

        static double GenerateRandomDollarAmount(bool isAccount, double min, double max)
        {
            if (isAccount)
            {
                double accountStartingValue = random.NextDouble() * (max - min) + min;
                return Math.Round(accountStartingValue, 2);
            }
            else
            {
                double transactionAmount = random.NextDouble() * random.Next((int)min, (int)max) + random.NextDouble();
                return Math.Round(transactionAmount, 2);
            }
        }

        static string GenerateRandomAccountHolder()
        {
            string[] accountHolderNames = { "John Smith", "Maria Garcia", "Mohammed Khan", "Sophie Dubois", "Liam Johnson", "Emma Martinez", "Noah Lee", "Olivia Kim", "William Chen", "Ava Wang", "James Brown", "Isabella Nguyen", "Benjamin Wilson", "Mia Li", "Lucas Anderson", "Charlotte Liu", "Alexander Taylor", "Amelia Patel", "Daniel Garcia", "Sophia Kim" };
            var accountHolderName = accountHolderNames[random.Next(0, accountHolderNames.Length)];
            return accountHolderName;
        }

        static string GenerateRandomAccountType()
        {
            string[] accountTypes = { "Savings", "Checking", "Money Market", "Certificate of Deposit", "Retirement" };
            return accountTypes[random.Next(0, accountTypes.Length)];
        }

        static DateTime GenerateRandomDateOpened()
        {
            DateTime startDate = new(DateTime.Today.Year - MaxYearsBack, 1, 1);
            int daysRange = (DateTime.Today - startDate).Days;
            DateTime randomDate = startDate.AddDays(random.Next(daysRange));

            if (randomDate.Year == DateTime.Today.Year && randomDate >= DateTime.Today)
            {
                randomDate = randomDate.AddDays(-1);
            }

            return randomDate;
        }
    }
}