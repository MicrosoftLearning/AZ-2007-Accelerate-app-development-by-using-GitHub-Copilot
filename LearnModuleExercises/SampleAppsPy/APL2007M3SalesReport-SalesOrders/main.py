from datetime import date
from random import randint, choice
from collections import defaultdict

class QuarterlyIncomeReport:
    class SalesData:
        def __init__(self, date_sold, department_name, product_id, quantity_sold, unit_price, base_cost, volume_discount):
            self.date_sold = date_sold
            self.department_name = department_name
            self.product_id = product_id
            self.quantity_sold = quantity_sold
            self.unit_price = unit_price
            self.base_cost = base_cost
            self.volume_discount = volume_discount

    class ProdDepartments:
        department_names = ["Men's Clothing", "Women's Clothing", "Children's Clothing", "Accessories", "Footwear", "Outerwear", "Sportswear", "Undergarments"]
        department_abbreviations = ["MENS", "WOMN", "CHLD", "ACCS", "FOOT", "OUTR", "SPRT", "UNDR"]

    class ManufacturingSites:
        manufacturing_sites = ["US1", "US2", "US3", "UK1", "UK2", "UK3", "JP1", "JP2", "JP3", "CA1"]

    def generate_sales_data(self):
        sales_data = []
        for _ in range(1000):
            date_sold = date(2023, randint(1, 12), randint(1, 28))
            department_name = choice(self.ProdDepartments.department_names)
            department_index = self.ProdDepartments.department_names.index(department_name)
            department_abbreviation = self.ProdDepartments.department_abbreviations[department_index]
            first_digit = str(department_index + 1)
            next_two_digits = str(randint(1, 99)).zfill(2)
            size_code = choice(["XS", "S", "M", "L", "XL"])
            color_code = choice(["BK", "BL", "GR", "RD", "YL", "OR", "WT", "GY"])
            manufacturing_site = choice(self.ManufacturingSites.manufacturing_sites)
            product_id = f"{first_digit}{next_two_digits}-{size_code}-{color_code}-{manufacturing_site}"
            quantity_sold = randint(1, 100)
            unit_price = round(randint(10, 100) + randint(0, 99) / 100, 2)
            base_cost = round(unit_price * 0.6, 2)
            volume_discount = randint(0, 20)
            sales_data.append(self.SalesData(date_sold, department_name, product_id, quantity_sold, unit_price, base_cost, volume_discount))
        return sales_data

    def quarterly_sales_report(self, sales_data):
        quarterly_sales = defaultdict(float)
        for record in sales_data:
            quarter = self.get_quarter(record.date_sold.month)
            quarterly_sales[quarter] += record.quantity_sold * record.unit_price

        print("Quarterly Sales Report:")
        for quarter, total_sales in sorted(quarterly_sales.items()):
            print(f"Q{quarter}: ${total_sales:.2f}")

    def get_quarter(self, month):
        if month in [1, 2, 3]:
            return 1
        elif month in [4, 5, 6]:
            return 2
        elif month in [7, 8, 9]:
            return 3
        elif month in [10, 11, 12]:
            return 4

if __name__ == "__main__":
    report = QuarterlyIncomeReport()
    sales_data = report.generate_sales_data()
    report.quarterly_sales_report(sales_data) 