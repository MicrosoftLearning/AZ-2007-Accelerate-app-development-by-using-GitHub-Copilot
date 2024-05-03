from datetime import date
from random import randint, choice
from collections import defaultdict
from operator import itemgetter

class QuarterlyIncomeReport:
    def __init__(self):
        pass

    def main(self):
        # create a new instance of the class
        report = QuarterlyIncomeReport()

        # call the GenerateSalesData method
        salesData = report.generate_sales_data()

        # call the QuarterlySalesReport method
        report.quarterly_sales_report(salesData)

    # public struct SalesData includes the following fields: date sold, department name, product ID, quantity sold, unit price
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

    # the generate_sales_data method returns 1000 SalesData records. It assigns random values to each field of the data structure
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
            product_id = f"{department_abbreviation}-{first_digit}{next_two_digits}-{size_code}-{color_code}-{manufacturing_site}"
            quantity_sold = randint(1, 100)
            unit_price = randint(25, 299) + randint(0, 99) / 100
            base_cost = unit_price * (1 - randint(5, 20) / 100)
            volume_discount = int(quantity_sold * 0.1)
            sales_data.append(self.SalesData(date_sold, department_name, product_id, quantity_sold, unit_price, base_cost, volume_discount))
        return sales_data

    def quarterly_sales_report(self, sales_data):
        # create a dictionary to store the quarterly sales data
        quarterly_sales = defaultdict(float)
        quarterly_profit = defaultdict(float)
        quarterly_profit_percentage = defaultdict(float)

        # create a dictionary to store the quarterly sales data by department
        quarterly_sales_by_department = defaultdict(lambda: defaultdict(float))
        quarterly_profit_by_department = defaultdict(lambda: defaultdict(float))
        quarterly_profit_percentage_by_department = defaultdict(lambda: defaultdict(float))

        # create a dictionary to store the top 3 sales orders by quarter
        top3_sales_orders_by_quarter = defaultdict(list)

        # iterate through the sales data
        for data in sales_data:
            # calculate the total sales for each quarter
            quarter = self.get_quarter(data.date_sold.month)
            total_sales = data.quantity_sold * data.unit_price
            total_cost = data.quantity_sold * data.base_cost
            profit = total_sales - total_cost
            profit_percentage = (profit / total_sales) * 100

            # calculate the total sales, profit, and profit percentage by department
            quarterly_sales_by_department[quarter][data.department_name] += total_sales
            quarterly_profit_by_department[quarter][data.department_name] += profit
            quarterly_profit_percentage_by_department[quarter][data.department_name] = profit_percentage

            # calculate the total sales and profit for each quarter
            quarterly_sales[quarter] += total_sales
            quarterly_profit[quarter] += profit

            # add the sales data to the top 3 sales orders by quarter
            top3_sales_orders_by_quarter[quarter].append(data)

        # sort the top 3 sales orders by profit in descending order
        for quarter in top3_sales_orders_by_quarter:
            top3_sales_orders_by_quarter[quarter] = sorted(top3_sales_orders_by_quarter[quarter], key=lambda order: (order.quantity_sold * order.unit_price) - (order.quantity_sold * order.base_cost), reverse=True)[:3]

        # display the quarterly sales report
        print("Quarterly Sales Report")
        print("----------------------")

        # sort the quarterly sales by key (quarter)
        sorted_quarterly_sales = sorted(quarterly_sales.items(), key=itemgetter(0))

        for quarter, sales_amount in sorted_quarterly_sales:
            # format the sales amount as currency using regional settings
            formatted_sales_amount = f"${sales_amount:.2f}"
            formatted_profit_amount = f"${quarterly_profit[quarter]:.2f}"
            formatted_profit_percentage = f"{quarterly_profit_percentage[quarter]:.2f}"

            print(f"{quarter}: Sales: {formatted_sales_amount}, Profit: {formatted_profit_amount}, Profit Percentage: {formatted_profit_percentage}%")

            # display the quarterly sales, profit, and profit percentage by department
            print("By Department:")
            sorted_quarterly_sales_by_department = sorted(quarterly_sales_by_department[quarter].items(), key=itemgetter(0))

            # Print table headers
            print("┌───────────────────────┬───────────────────┬───────────────────┬───────────────────┐")
            print("│      Department       │       Sales       │       Profit      │ Profit Percentage │")
            print("├───────────────────────┼───────────────────┼───────────────────┼───────────────────┤")

            for department, department_sales_amount in sorted_quarterly_sales_by_department:
                formatted_department_sales_amount = f"${department_sales_amount:.2f}"
                formatted_department_profit_amount = f"${quarterly_profit_by_department[quarter][department]:.2f}"
                formatted_department_profit_percentage = f"{quarterly_profit_percentage_by_department[quarter][department]:.2f}"

                print(f"│ {department:<22}│ {formatted_department_sales_amount:>17} │ {formatted_department_profit_amount:>17} │ {formatted_department_profit_percentage:>17} │")

            print("└───────────────────────┴───────────────────┴───────────────────┴───────────────────┘")
            print()

            # display the top 3 sales orders for the quarter
            print("Top 3 Sales Orders:")
            top3_sales_orders = top3_sales_orders_by_quarter[quarter]

            # Print table headers
            print("┌───────────────────────┬───────────────────┬───────────────────┬───────────────────┬───────────────────┬───────────────────┐")
            print("│      Product ID       │   Quantity Sold   │    Unit Price     │   Total Sales     │      Profit       │ Profit Percentage │")
            print("├───────────────────────┼───────────────────┼───────────────────┼───────────────────┼───────────────────┼───────────────────┤")

            for sales_order in top3_sales_orders:
                order_total_sales = sales_order.quantity_sold * sales_order.unit_price
                order_profit = order_total_sales - (sales_order.quantity_sold * sales_order.base_cost)
                order_profit_percentage = (order_profit / order_total_sales) * 100

                print(f"│ {sales_order.product_id:<22}│ {sales_order.quantity_sold:>17} │ {sales_order.unit_price:>17.2f} │ {order_total_sales:>17.2f} │ {order_profit:>17.2f} │ {order_profit_percentage:>17.2f} │")

            print("└───────────────────────┴───────────────────┴───────────────────┴───────────────────┴───────────────────┴───────────────────┘")
            print()

    def get_quarter(self, month):
        if 1 <= month <= 3:
            return "Q1"
        elif 4 <= month <= 6:
            return "Q2"
        elif 7 <= month <= 9:
            return "Q3"
        else:
            return "Q4"

# create a new instance of the class
report = QuarterlyIncomeReport()
report.main()
