from datetime import datetime

class BankAccount:
    def __init__(self, account_number, initial_balance, account_holder_name, account_type, date_opened):
        self.account_number = account_number
        self.balance = initial_balance
        self.account_holder_name = account_holder_name
        self.account_type = account_type
        self.date_opened = date_opened

    def credit(self, amount):
        self.balance += amount

    def debit(self, amount):
        if self.balance >= amount:
            self.balance -= amount
        else:
            raise Exception("Insufficient balance for debit.")

    def get_balance(self):
        return self.balance

    def transfer(self, to_account, amount):
        if self.balance >= amount:
            if self.account_holder_name != to_account.account_holder_name and amount > 500:
                raise Exception("Transfers over $500 are not allowed between different account holders.")
            self.debit(amount)
            to_account.credit(amount)
        else:
            raise Exception("Insufficient balance for transfer.")

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
    print(f"Account 1 Balance: {account1.get_balance()}")

    account1.debit(100)
    print(f"Account 1 Balance after debit: {account1.get_balance()}")

    account1.transfer(account2, 300)
    print(f"Account 1 Balance after transfer: {account1.get_balance()}")
    print(f"Account 2 Balance after receiving transfer: {account2.get_balance()}")

    account1.print_statement()
    interest = account1.calculate_interest(5)
    print(f"Interest on Account 1 at 5%: ${interest:.2f}") 