---
demo:
    title: 'Demo: Create code by using code line completions'
    module: 'Module 3: Develop code features using GitHub Copilot tools'
---

# Demo: Create code by using code line completions

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

GitHub Copilot can provide code completion suggestions for numerous programming languages and a wide variety of frameworks, but works especially well for Python, JavaScript, TypeScript, Ruby, Go, and C#. Code line completions are generated based on the context of the code you're writing. You can accept, reject, or partially accept the suggestions provided by GitHub Copilot.

GitHub Copilot provides two ways to generate code line completions:

- **From a comment**: You can generate code line completions by writing a comment that describes the code you want to generate. GitHub Copilot provides code completion suggestions based on the comment you write.

- **From code**: You can generate code line completions by starting a code line, or by pressing Enter after a completed code line. GitHub Copilot provides code completion suggestions based on the code you write.

In this demonstration, you use GitHub Copilot to generate code line completions in your Visual Studio Code environment.

### Create a Python script in your Visual Studio Code environment

In this demonstration, you create a Python script using GitHub Copilot tools.

Use the following steps to complete this section of the demo:

1. Open a new instance of Visual Studio Code, and then open the Chat view.

    You can open the Chat view by selecting **Open Chat** from the Visual Studio Code Command Center or using the **Ctrl+Alt+I** keyboard shortcut.

1. In the Chat view, enter the following prompt:

    ```plaintext
    @workspace /new Python script named sales_report.py and a requirements.txt. The script should generate a quarterly sales report.
    ```

1. In the Chat view, select **Create Workspace**.

    GitHub Copilot uses your prompt to create the workspace for a new Python script. The script is named `sales_report.py` and includes the necessary boilerplate code.

1. In the Select Folder dialog, navigate to your working directory, select the folder, and then select **Select as Parent Folder**.

    You're prompted to select a parent folder for the new workspace. Selecting a working directory is a good choice for this demo. Remember to clean up when you complete this training.

1. When prompted to open the new project, select **Open**.

1. In the Explorer view, select **sales_report.py**.

1. Replace the contents of the `sales_report.py` file with the following code:

    ```python
    from datetime import date
    from random import randint
    from collections import defaultdict

    class QuarterlySalesReport:
        def __init__(self):
            self.sales_data = []

        def generate_sales_data(self):
            for _ in range(1000):
                date_sold = date(2023, randint(1, 12), randint(1, 28))
                department = f"Department {randint(1, 10)}"
                quantity = randint(1, 100)
                unit_price = round(randint(10, 100) + randint(0, 99) / 100, 2)
                self.sales_data.append((date_sold, department, quantity, unit_price))

        def calculate_quarterly_sales(self):
            quarterly_sales = defaultdict(float)
            for date_sold, _, quantity, unit_price in self.sales_data:
                quarter = (date_sold.month - 1) // 3 + 1
                quarterly_sales[quarter] += quantity * unit_price
            return quarterly_sales

        def print_report(self):
            quarterly_sales = self.calculate_quarterly_sales()
            print("Quarterly Sales Report")
            print("----------------------")
            for quarter, total in sorted(quarterly_sales.items()):
                print(f"Q{quarter}: ${total:.2f}")

    if __name__ == "__main__":
        report = QuarterlySalesReport()
        report.generate_sales_data()
        report.print_report()
    ```

Your setup requirements are complete and you're ready to continue the demo.

### Use GitHub Copilot to generate code line completions from a comment

GitHub Copilot generates code completion suggestions based on the comment and the existing context of your app. You can use comments to describe code snippets, methods, data structures, and other code elements.

Use the following steps to complete this section of the demo:

1. In the `sales_report.py` file, create two empty code lines below the `generate_sales_data` method.

1. To create a method that calculates the total sales for each department, create the following code comment, and then press Enter:

    ```python
    # Define a method to calculate total sales by department
    ```

    GitHub Copilot generates one or more code completion suggestions based on your code comment and any existing code that it finds in your app.

1. Take a minute to review the code completion suggestions provided by GitHub Copilot.

    Notice that the suggestions include a method that calculates total sales by department. The method uses a dictionary to store the total sales for each department and iterates through the sales data to calculate the totals.

1. To accept a suggested method, press the Tab key or select **Accept**.

1. If necessary, adjust the method to match your requirements.

    ```python
    def calculate_sales_by_department(self):
        department_sales = defaultdict(float)
        for _, department, quantity, unit_price in self.sales_data:
            department_sales[department] += quantity * unit_price
        return department_sales
    ```

The ability to generate code from comments is a powerful feature of GitHub Copilot. With just a comment, you were able to generate a method that calculates total sales by department.

### Summary

In this demo, you used GitHub Copilot to generate code line completions in your Visual Studio Code environment. You used comments to generate a method that calculates total sales by department. By leveraging GitHub Copilot's code completion capabilities, you can accelerate your development process and focus on building high-quality applications. 