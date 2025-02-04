import random
from datetime import date

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
        for _ in range(100000):
            date_sold = date(2023, random.randint(1, 12), random.randint(1, 28))
            department_name = random.choice(self.ProdDepartments.department_names)
            product_id = f"{random.randint(1000, 9999)}-{random.choice(self.ManufacturingSites.manufacturing_sites)}"
            quantity_sold = random.randint(1, 100)
            unit_price = round(random.uniform(10.0, 100.0), 2)
            base_cost = round(unit_price * 0.6, 2)
            volume_discount = random.randint(0, 20)
            sales_data.append(self.SalesData(date_sold, department_name, product_id, quantity_sold, unit_price, base_cost, volume_discount))
        return sales_data

if __name__ == "__main__":
    report = QuarterlyIncomeReport()
    sales_data = report.generate_sales_data()
    print(f"Generated {len(sales_data)} sales records.") 