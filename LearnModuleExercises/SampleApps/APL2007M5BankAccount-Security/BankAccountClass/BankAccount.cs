using System;

namespace BankAccountApp
{
    public class InsufficientFundsException : Exception
    {
        public double AttemptedAmount { get; }
        public double CurrentBalance { get; }

        public InsufficientFundsException(double attemptedAmount, double currentBalance)
            : base($"Insufficient balance for debit. Attempted to debit {attemptedAmount}, but current balance is {currentBalance}.")
        {
            AttemptedAmount = attemptedAmount;
            CurrentBalance = currentBalance;
        }
    }

    public class InvalidAccountTypeException : Exception
    {
        public string AccountType { get; }

        public InvalidAccountTypeException(string accountType)
            : base($"Invalid account type: {accountType}.")
        {
            AccountType = accountType;
        }
    }

    public class InvalidAccountNumberException : Exception
    {
        public string AccountNumber { get; }

        public InvalidAccountNumberException(string accountNumber)
            : base($"Invalid account number: {accountNumber}.")
        {
            AccountNumber = accountNumber;
        }
    }

    public class InvalidAccountHolderNameException : Exception
    {
        public string AccountHolderName { get; }

        public InvalidAccountHolderNameException(string accountHolderName)
            : base($"Invalid account holder name: {accountHolderName}.")
        {
            AccountHolderName = accountHolderName;
        }
    }

    public class InvalidDateOpenedException : Exception
    {
        public DateTime DateOpened { get; }

        public InvalidDateOpenedException(DateTime dateOpened)
            : base($"Invalid date opened: {dateOpened}.")
        {
            DateOpened = dateOpened;
        }
    }

    public class InvalidInitialBalanceException : Exception
    {
        public double InitialBalance { get; }

        public InvalidInitialBalanceException(double initialBalance)
            : base($"Invalid initial balance: {initialBalance}.")
        {
            InitialBalance = initialBalance;
        }
    }

    public class InvalidInterestRateException : Exception
    {
        public double InterestRate { get; }

        public InvalidInterestRateException(double interestRate)
            : base($"Invalid interest rate: {interestRate}.")
        {
            InterestRate = interestRate;
        }
    }

    public class InvalidTransferAmountException : Exception
    {
        public double TransferAmount { get; }

        public InvalidTransferAmountException(double transferAmount)
            : base($"Invalid transfer amount: {transferAmount}.")
        {
            TransferAmount = transferAmount;
        }
    }

    public class InvalidCreditAmountException : Exception
    {
        public double CreditAmount { get; }

        public InvalidCreditAmountException(double creditAmount)
            : base($"Invalid credit amount: {creditAmount}.")
        {
            CreditAmount = creditAmount;
        }
    }

    public class InvalidDebitAmountException : Exception
    {
        public double DebitAmount { get; }

        public InvalidDebitAmountException(double debitAmount)
            : base($"Invalid debit amount: {debitAmount}.")
        {
            DebitAmount = debitAmount;
        }
    }


    public class BankAccount
    {
        public enum AccountTypes
        {
            Savings,
            Checking,
            MoneyMarket,
            CertificateOfDeposit,
            Retirement
        }
        public string AccountNumber { get; }
        public double Balance { get; private set; }
        public string AccountHolderName { get; }
        public AccountTypes AccountType { get; }
        public DateTime DateOpened { get; }
        private const double MaxTransferAmountForDifferentOwners = 500;

        public BankAccount(string accountNumber, double initialBalance, string accountHolderName, string accountType, DateTime dateOpened)
        {
            if (accountNumber.Length != 10)
            {
                throw new InvalidAccountNumberException(accountNumber);
            }

            if (initialBalance < 0)
            {
                throw new InvalidInitialBalanceException(initialBalance);
            }

            if (accountHolderName.Length < 2)
            {
                throw new InvalidAccountHolderNameException(accountHolderName);
            }

            /* the enum will enforce the valid values
            if (accountType != "Savings" && accountType != "Checking" && accountType != "Money Market" && accountType != "Certificate of Deposit" && accountType != "Retirement")
            {
                throw new InvalidAccountTypeException(accountType);
            }
            */     

            if (dateOpened > DateTime.Now)
            {
                throw new InvalidDateOpenedException(dateOpened);
            }

            AccountNumber = accountNumber;
            Balance = initialBalance;
            AccountHolderName = accountHolderName;
            //AccountType = AccountTypes.Savings; // (AccountTypes)Enum.Parse(typeof(AccountTypes), accountType);
            AccountType = (AccountTypes)Enum.Parse(typeof(AccountTypes), accountType);
            DateOpened = dateOpened;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new InvalidCreditAmountException(amount);
            }

            Balance += amount;
        }

        public void Debit(double amount)
        {
            if (amount < 0)
            {
                throw new InvalidDebitAmountException(amount);
            }

            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InsufficientFundsException(amount, Balance);
            }
        }

        public double GetBalance()
        {
            return Balance; // Math.Round(balance, 2);
        }

        public void Transfer(BankAccount toAccount, double amount)
        {
            ValidateTransferAmount(amount);
            ValidateTransferLimitForDifferentOwners(toAccount, amount);

            if (Balance >= amount)
            {
                Debit(amount);
                toAccount.Credit(amount);
            }
            else
            {
                throw new InsufficientFundsException(amount, Balance);
            }
        }

        private void ValidateTransferAmount(double amount)
        {
            if (amount < 0)
            {
                throw new InvalidTransferAmountException(amount);
            }
        }

        private void ValidateTransferLimitForDifferentOwners(BankAccount toAccount, double amount)
        {
            if (AccountHolderName != toAccount.AccountHolderName && amount > MaxTransferAmountForDifferentOwners)
            {
                throw new Exception("Transfer amount exceeds maximum limit for different account owners.");
            }
        }


        /* 
        
        public void Transfer(BankAccount toAccount, double amount)
        {
            if (amount < 0)
            {
                throw new InvalidTransferAmountException(amount);
            }

            if (Balance >= amount)
            {
                if (AccountHolderName != toAccount.AccountHolderName && amount > 500)
                {
                    throw new Exception("Transfer amount exceeds maximum limit for different account owners.");
                }

                Debit(amount);
                toAccount.Credit(amount);
            }
            else
            {
                throw new Exception("Insufficient balance for transfer.");
            }
        }

        */

        public void PrintStatement()
        {
            Console
                .WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");

            // Add code here to print recent transactions
        }

        public double CalculateInterest(double interestRate)
        {
            if (interestRate < 0)
            {
                throw new InvalidInterestRateException(interestRate);
            }

            return Balance * interestRate;
        }
    }

}