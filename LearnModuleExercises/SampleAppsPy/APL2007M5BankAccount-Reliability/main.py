import random
from datetime import datetime, timedelta

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

    def transfer(self, to_account, amount):
        if self.balance >= amount:
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

# Helper functions
def generate_random_dollar_amount(min_amount, max_amount):
    return round(random.uniform(min_amount, max_amount), 2)

def generate_random_account_holder():
    return random.choice(["John Doe", "Jane Smith", "Alice Johnson", "Bob Brown"])

def generate_random_account_type():
    return random.choice(["Savings", "Checking", "Business"])

def generate_random_date_opened():
    days_back = random.randint(0, 3650)  # Up to 10 years back
    return datetime.now() - timedelta(days=days_back)

def create_bank_accounts(number_of_accounts):
    accounts = []
    for i in range(number_of_accounts):
        initial_balance = generate_random_dollar_amount(200.0, 1000.0)
        account_holder = generate_random_account_holder()
        account_type = generate_random_account_type()
        date_opened = generate_random_date_opened()
        account = BankAccount(f"Account {i + 1}", initial_balance, account_holder, account_type, date_opened)
        accounts.append(account)
    return accounts

def simulate_transactions(accounts, number_of_transactions):
    for account in accounts:
        for _ in range(number_of_transactions):
            try:
                amount = generate_random_dollar_amount(-500.0, 500.0)
                if amount > 0:
                    account.credit(amount)
                else:
                    account.debit(abs(amount))
            except Exception as e:
                print(f"Transaction failed for {account.account_number}: {e}")

def simulate_transfers(accounts, number_of_transactions):
    for _ in range(number_of_transactions):
        from_account = random.choice(accounts)
        to_account = random.choice(accounts)
        if from_account != to_account:
            try:
                amount = generate_random_dollar_amount(1.0, 500.0)
                from_account.transfer(to_account, amount)
            except Exception as e:
                print(f"Transfer failed from {from_account.account_number} to {to_account.account_number}: {e}")

if __name__ == "__main__":
    accounts = create_bank_accounts(20)
    simulate_transactions(accounts, 100)
    simulate_transfers(accounts, 100)

    for account in accounts:
        account.print_statement() 