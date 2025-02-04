from datetime import datetime

# Custom Exceptions
class InsufficientFundsException(Exception):
    def __init__(self, attempted_amount, current_balance):
        super().__init__(f"Insufficient balance for debit. Attempted to debit {attempted_amount}, but current balance is {current_balance}.")
        self.attempted_amount = attempted_amount
        self.current_balance = current_balance

class InvalidAccountTypeException(Exception):
    def __init__(self, account_type):
        super().__init__(f"Invalid account type: {account_type}.")
        self.account_type = account_type

class InvalidTransferAmountException(Exception):
    def __init__(self, transfer_amount):
        super().__init__(f"Invalid transfer amount: {transfer_amount}.")
        self.transfer_amount = transfer_amount

# BankAccount Class
class BankAccount:
    ACCOUNT_TYPES = ["Savings", "Checking", "MoneyMarket", "CertificateOfDeposit", "Retirement"]
    MAX_TRANSFER_AMOUNT_FOR_DIFFERENT_OWNERS = 500

    def __init__(self, account_number, initial_balance, account_holder_name, account_type, date_opened):
        if account_type not in self.ACCOUNT_TYPES:
            raise InvalidAccountTypeException(account_type)

        self.account_number = account_number
        self.balance = initial_balance
        self.account_holder_name = account_holder_name
        self.account_type = account_type
        self.date_opened = date_opened

    def credit(self, amount):
        if amount <= 0:
            raise InvalidTransferAmountException(amount)
        self.balance += amount

    def debit(self, amount):
        if amount <= 0:
            raise InvalidTransferAmountException(amount)
        if self.balance < amount:
            raise InsufficientFundsException(amount, self.balance)
        self.balance -= amount

    def transfer(self, to_account, amount):
        if amount <= 0:
            raise InvalidTransferAmountException(amount)
        if self.account_holder_name != to_account.account_holder_name and amount > self.MAX_TRANSFER_AMOUNT_FOR_DIFFERENT_OWNERS:
            raise Exception("Transfers over $500 are not allowed between different account holders.")
        self.debit(amount)
        to_account.credit(amount)

    def print_statement(self):
        print(f"Account Number: {self.account_number}")
        print(f"Account Holder: {self.account_holder_name}")
        print(f"Account Type: {self.account_type}")
        print(f"Date Opened: {self.date_opened}")
        print(f"Balance: ${self.balance:.2f}")

    def calculate_interest(self, interest_rate):
        if interest_rate <= 0:
            raise Exception("Invalid interest rate.")
        return self.balance * (interest_rate / 100)

if __name__ == "__main__":
    # Example usage
    account1 = BankAccount("123456", 1000.0, "John Doe", "Savings", datetime.now())
    account2 = BankAccount("654321", 500.0, "Jane Doe", "Checking", datetime.now())

    account1.credit(200)
    print(f"Account 1 Balance: {account1.balance}")

    account1.debit(100)
    print(f"Account 1 Balance after debit: {account1.balance}")

    account1.transfer(account2, 300)
    print(f"Account 1 Balance after transfer: {account1.balance}")
    print(f"Account 2 Balance after receiving transfer: {account2.balance}")

    account1.print_statement()
    interest = account1.calculate_interest(5)
    print(f"Interest on Account 1 at 5%: ${interest:.2f}") 