namespace BankAccountApp
{
    class BankAccount
    {
        public string AccountNumber { get; }
        public double Balance { get; private set; }
        public string AccountHolderName { get; }
        public string AccountType { get; }
        public DateTime DateOpened { get; }

        public BankAccount(string accountNumber, double initialBalance, string accountHolderName, string accountType, DateTime dateOpened)
        {
            if (initialBalance < 200)
            {
                throw new Exception("Initial balance must be at least 200.");
            }

            AccountNumber = accountNumber;
            Balance = initialBalance;
            AccountHolderName = accountHolderName;
            AccountType = accountType;
            DateOpened = dateOpened;
        }

        public void Credit(double amount)
        {

            if (AccountType == "Money Market" || AccountType == "Certificate of Deposit" || AccountType == "Retirement")
            {
                throw new Exception("Credits to this account type are not allowed.");
            }

            Balance += amount;
        }

        public void Debit(double amount)
        {

            if (AccountType == "Money Market" || AccountType == "Certificate of Deposit" || AccountType == "Retirement")
            {
                throw new Exception("Debits from this account type are not allowed.");
            }

            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new Exception("Insufficient balance for debit.");
            }
        }

        public double GetBalance()
        {
            return Balance; // Math.Round(balance, 2);
        }

        public void Transfer(BankAccount toAccount, double amount)
        {
            if (Balance >= amount)
            {
                if (AccountHolderName != toAccount.AccountHolderName && amount > 500)
                {
                    throw new Exception("Transfer amount exceeds maximum limit for different account owners.");
                }

                if (Balance - amount < 200)
                {
                    throw new Exception("Transfer amount would result in balance below 200.");
                }

                if (AccountType == "Money Market" || AccountType == "Certificate of Deposit" || AccountType == "Retirement")
                {
                    throw new Exception("Transfers from this account type are not allowed.");
                }

                Debit(amount);
                toAccount.Credit(amount);
            }
            else
            {
                throw new Exception("Insufficient balance for transfer.");
            }
        }

        public void PrintStatement()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
            // Add code here to print recent transactions
        }

        public double CalculateInterest(double interestRate)
        {
            return Balance * interestRate;
        }
    }
}