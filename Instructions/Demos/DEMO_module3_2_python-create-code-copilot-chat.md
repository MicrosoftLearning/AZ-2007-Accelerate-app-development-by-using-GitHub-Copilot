---
demo:
    title: 'Demo: Create code by using GitHub Copilot Inline Chat'
    module: 'Module 3: Develop code features using GitHub Copilot tools'
---

# Demo: Create code by using GitHub Copilot Inline Chat

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

The GitHub Copilot Chat extension for Visual Studio Code includes three chat interfaces:

- The **Chat view** provides an AI assistant that's available to help you at any time.
- A **Quick Chat** window can be used to ask a quick question and then get back into what you're doing.
- The **inline chat** interface opens directly in the editor for contextual interactions while you're coding.

The Chat view and Quick Chat window enable interactive multi-turn conversations with the AI. Both of these interfaces provide a way to ask questions, get help with a coding problem, and generate code. During a conversation, GitHub Copilot responses include natural language text, code blocks, and other elements. When code blocks are provided in a response, you can copy them or inject them directly into your code editor.

The inline chat interface is designed to provide contextual help and code suggestions while you're coding.

In this demonstration, you use GitHub Copilot's inline chat feature to generate new code features. The demonstration is a continuation of the project scenario in the previous demonstration. Use the prepared sample app, `APL2007M3SalesReport-InlineChat`, to start the demo. During the demo you'll update the `SalesData` data structure and the `generate_sales_data` method. You'll also update the `quarterly_sales_report` method to include additional calculations and display options.

#### Review the coding tasks and project goals

This demonstration focuses on using GitHub Copilot to accelerate the following tasks:

1. You will update the `SalesData` data structure and `generate_sales_data` method to produce a data sample that resembles "actual" data.

    - `date_sold`: no changes are required.
    - `department_name`: The string values should be randomly selected from a list of 8 departments. For each department name, create a 4-character abbreviation that can be included in the product ID.
    - `product_id`: The product ID values should be formatted using the pattern "`DDDD-###-SS-CC-MMM`" where the components of the ID are defined as follows:

        - a 4-character code representing the department.
        - a 3-digit number representing the product.
        - a 2-character code representing the product size.
        - a 2-character code representing the product color.
        - a 3-character code representing the manufacturing site (randomly selected from a list of 10 manufacturing sites). The codes should be a 2-letter ISO country code followed by a digit (e.g., US1, CA2, MX3, etc.).

    - `quantity_sold`: no changes are required.
    - `unit_price`: Raise the lower bound of the price range to 25 and the upper bound to 300.
    - `base_cost`: Add a field for the manufacturing cost of the item. The base cost values should be generated using a randomly generated discount off the unit price (5 to 20 percent).
    - `volume_discount`: Add a field for a volume discount percentage. The value assigned to `volume_discount` should be the integer component of 10 percent of the `quantity_sold` (10% of 19 units = 1% volume discount).
    - Increase the number of records generated to 10,000.

1. You will update the `quarterly_sales_report` method as follows:

    1. When displaying the sales results, list the results in a logical order. For example, when listing total sales by quarter, the quarters should be listed in order from Q1 to Q4.
    1. Display currency values using regional settings.
    1. Include calculations for quarterly profit and profit percentage.
    1. Include calculations for quarterly sales, profit, and profit percentage by department.

#### Explain your approach to developing prompts for GitHub Copilot Chat

GitHub Copilot's inline chat feature uses the prompt you submit to understand the task or problem you're trying to solve. The prompts should be specific and concise. Good prompts produce better responses.

When you develop prompts for GitHub Copilot, consider the following best practices:

- Be specific and keep it simple: Provide clear and concise prompts that describe the task or problem you're trying to solve. Avoid using complex language or jargon that could confuse the AI.
- Use natural language: Write prompts in a conversational tone. Use natural language that you would use when talking to a colleague or team member.
- Break down complex tasks: If the task is complex, break it down into smaller steps. Provide prompts for each step to help GitHub Copilot generate the correct code.
- Provide context: Include relevant information that helps GitHub Copilot understand the task or problem you're trying to solve. Include details about the data, variables, or code blocks that are relevant to the prompt.
- Use chat participants, slash commands, and chat variables: GitHub Copilot's inline chat feature supports chat participants, slash commands, and chat variables. Use these features to interact with GitHub Copilot and provide additional context for your prompts.

### Generate data structures using inline chat

Projects generally begin with the features or parameters that are either fixed or known. Selecting a data source or creating sample data is often a good place to start.

In this section of the demo, you use data structures to help create simulated sales data. The data provides useful context for GitHub Copilot when you update the `quarterly_sales_report` method.

> [!NOTE]
> In an actual business project, you'd probably use historical data rather than generating simulated data. In this training, generating simulated data provides an opportunity to practice using the GitHub Copilot tools. Simulating data isn't suggested as a best practice for business projects.

Your project goals indicate that you need to work on the following data structures:

- You need a list of 8 department names. Each department name should be abbreviated using a 4-character string. Pick an industry for your fictional company such as Clothing or Sports Equipment, and then have GitHub Copilot generate a dictionary of department names and 4-char codes.
- You need a list of 10 manufacturing sites. Each site should be represented by a 3-character code. The codes can be a 2-letter ISO country code followed by a digit (e.g., US1, CA2, MX3, etc.). Have GitHub Copilot generate a dictionary of 10 manufacturing sites using 3-4 country codes.
- You need to update the `SalesData` data structure. You need to include the new fields for: department code, manufacturing site code. You also need to change the data type for `product_id` from `int` to `string`.

To create and update the data structure, complete the following steps:

1. Open the **APL2007M3SalesReport-InlineChat** project folder in Visual Studio Code.

1. Ensure that the application runs and produces a report that resembles the following output:

    ```plaintext
    Quarterly Sales Report
    ----------------------
    Q3: $690095.71
    Q4: $600536.33
    Q2: $678194.79
    Q1: $595963.05
    ```

    Since the data is randomly generated, the numeric values will vary with each run.

1. Open the `main.py` file.

1. Position the cursor on a blank line below the `SalesData` data structure.

1. To open the inline chat interface, press **Ctrl+I** on the keyboard.

1. Enter the following prompt:

    ```plaintext
    I need a public struct ProdDepartments that contains a static string array for 8 clothing industry departments. Create separate string array containing 4-character abbreviations for each department name. The abbreviation must be unique. The department names should represent real department names for the clothing industry.
    ```

    If you had a specific list of field names, you could provide them in the prompt. For example, actual company data could be used to specify the department names.

1. Review the suggestions provided by GitHub Copilot.

    As long as the prompt is clear and specific, GitHub Copilot should provide a useful suggestion. If the suggestion isn't what you expected, you can reject it and try again. In this case, the names of the departments aren't important, so you can probably accept the suggestion.

    Your data structure should resemble the following code:

    ```python
    class ProdDepartments:
        department_names = ["Men's Clothing", "Women's Clothing", "Children's Clothing", "Accessories", "Footwear", "Outerwear", "Sportswear", "Undergarments"]
        department_abbreviations = ["MENS", "WOMN", "CHLD", "ACCS", "FOOT", "OUTR", "SPRT", "UNDR"]
    ```

1. To accept the suggestion, press the Tab key or select **Accept**.

    You can also use the inline chat feature to document the new code. Select the code, press **Ctrl+I** to open inline chat, enter `/doc`, review the suggested inline documentation, and then accept the update.

### Summary

In this demo, you used the inline chat feature to update the `generate_sales_data` and `quarterly_sales_report` methods. You added new fields to the `SalesData` data structure and then updated the `generate_sales_data` method to generate data for the new fields. You also updated the `quarterly_sales_report` method to include calculations for quarterly profit and profit percentage. You also added calculations for quarterly sales, profit, and profit percentage by department. 