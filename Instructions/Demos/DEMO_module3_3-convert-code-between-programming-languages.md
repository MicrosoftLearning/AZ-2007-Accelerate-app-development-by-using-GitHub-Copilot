---
demo:
    title: 'Demo: Convert code from one programming language to another'
    module: 'Module 3: Develop code features using GitHub Copilot tools'
---

# Demo: Convert code from one programming language to another

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Visual Studio Code.
- The C# Dev Kit extension for Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects created using C#.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

GitHub Copilot can help you to convert code from one programming language to another. For example, you can ask GitHub Copilot to convert a function or code snippet to another programming language.

You can complete the following types of code conversions by using GitHub Copilot:

- Convert an entire code file to another programming language.
- Convert a function to another programming language.
- Convert a code snippet to another programming language.

Each of the chat interfaces (Chat view, Quick Chat window, and inline chat) can be used to convert code between programming languages. Your choice of chat interface depends on your preference and the complexity of the code that you want to convert.

Suppose you're just getting started on the `QuarterlyIncomeReport` project. You discuss the project goals with a colleague. They mention that they have a Python file that could provide some of the features that you're looking for. They point you the repository for the Python code. You decide to open the Python code project in Visual Studio Code and use the Chat view to convert the Python code to C#.

## Convert code between programming languages by using the Chat view

1. Open the **APL2007M3Python** project folder in Visual Studio Code.

    This project contains a Python version of the `QuarterlyIncomeReport` project that you've worked on during this module. You can have GitHub Copilot explain the code to you using the Chat view or Explain This smart action.

1. Run the Python application.

    Notice that the output from the Python application is essentially the same as the output from the C# application that you created earlier.

1. Open the `main.py` Python file.

    The Python file contains a function that generates sales data. You want to convert this Python code to C#.

1. Select the entire file contents.

1. Open the Chat view and then enter the following prompt:

    ```plaintext
    Convert #selection to C#
    ```

1. Take a moment to review the response from GitHub Copilot.

    The response should contain the C# version of the Python code that you selected.

1. Open a second instance of Visual Studio Code.

1. Open the Chat view, enter the following prompt:

    ```plaintext
    @workspace /new console application in C# NET8 named APL2007M3B. Only .cs and .csproj files. Enable ImplicitUsings and Nullable
    ```

    If Copilot responds with an error message about the "path argument", try the same prompt again.

1. Select **Create Workspace**

1. In the Open Folder dialog, select the **Desktop** folder and then select **Select as Parent Folder**.

    wait for the workspace to be created.

1. When the workspace is created, select **Program.cs**, and delete the file contents.

1. Switch to the instance of Visual Studio Code that contains the Python code.

1. Scroll to the top of the Chat view and click the **Copy** button to copy the generated C# code to the clipboard.

1. Switch to the instance of Visual Studio Code that contains the C# code.

1. Paste the C# code into the Program.cs file.

1. Save the Program.cs file.

1. Run the C# application.

    Notice that the output from the C# application is essentially the same as the output from the Python application.

    If you have time, take a few minutes to review the differences between the converted C# code and the C# code from the previous unit.

## Convert code between programming languages by using the inline chat

1. Switch back to the Visual Studio Code instance containing the Python project that you opened earlier.

1. Select the code in the main.py file.

1. Open the inline chat and enter the following prompt:

    ```plaintext
    Convert #selection to C#
    ```

1. Review the response from GitHub Copilot and then select **Accept**.

    The Python file should now contain C# code.

1. Copy the generated C# code to the clipboard.

1. Close the main.py file without saving the changes.

1. Switch to the Visual Studio Code instance that contains the C# project and open the Program.cs file.

1. To overwrite the existing C# code, paste the C# code from the clipboard (converted from Python using inline chat) over the contents of the Program.cs file.

1. Save the Program.cs file.

1. Run the C# application.

    Notice that the output from the C# application is essentially the same as the output from the Python application.

When you use GitHub Copilot to convert code between programming languages, try using both the Chat view and the inline chat. Although both tools share the same AI model, their results may differ. Trying both tools can help you to determine which tool is best for your specific use case.

> [!NOTE]
> Programming languages often have an associated "programming style", and some languages may have unique features or code libraries. When you’re converting large sections of code from one programming language to another, it’s important to fully understand the target programming language and the intension of the code. GitHub Copilot suggestions should always be reviewed before accepting.

### Summary

In this demo, you used GitHub Copilot to convert Python code to C#. You used the Chat view and the inline chat to convert the Python code to C#. You then ran the C# application to verify that the output was the same as the output from the Python application. By using GitHub Copilot to convert code between programming languages, you can quickly adapt code from one language to another. Remember to review the converted code to ensure that it meets your requirements and that it follows the programming style of the target language.
