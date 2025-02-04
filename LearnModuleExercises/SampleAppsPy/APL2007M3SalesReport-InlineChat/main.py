from datetime import date
from random import randint
from collections import defaultdict

class QuarterlyIncomeReport:
    class SalesData:
        def __init__(self, date_sold, department_name, product_id, quantity_sold, unit_price):
            self.date_sold = date_sold
            self.department_name = department_name
            self.product_id = product_id
            self.quantity_sold = quantity_sold
            self.unit_price = unit_price

    def generate_sales_data(self):
        sales_data = []
        for _ in range(1000):
            date_sold = date(2023, randint(1, 12), randint(1, 28))
            department_name = f"Department {randint(1, 10)}"
            product_id = randint(1, 100)
            quantity_sold = randint(1, 100)
            unit_price = round(randint(1, 100) + randint(0, 99) / 100, 2)
            sales_data.append(self.SalesData(date_sold, department_name, product_id, quantity_sold, unit_price))
        return sales_data

    def quarterly_sales_report(self, sales_data):
        quarterly_sales = defaultdict(float)
        for record in sales_data:
            quarter = self.get_quarter(record.date_sold.month)
            quarterly_sales[quarter] += record.quantity_sold * record.unit_price

        print("Quarterly Sales Report")
        print("----------------------")
        for quarter, total_sales in sorted(quarterly_sales.items()):
            print(f"{quarter}: ${total_sales:.2f}")

    def get_quarter(self, month):
        if month in [1, 2, 3]:
            return "Q1"
        elif month in [4, 5, 6]:
            return "Q2"
        elif month in [7, 8, 9]:
            return "Q3"
        elif month in [10, 11, 12]:
            return "Q4"

if __name__ == "__main__":
    report = QuarterlyIncomeReport()
    sales_data = report.generate_sales_data()
    report.quarterly_sales_report(sales_data) 