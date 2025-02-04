---
demo:
    title: 'Demo: Improve code quality by using GitHub Copilot Chat'
    module: 'Module 5: Implement code improvements using GitHub Copilot tools'
---

# Demo: Improve code quality by using GitHub Copilot Chat

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

The term "code quality" refers to the overall quality of the codebase, including readability, maintainability, and modularity. Code quality is a measure of how "well-structured" your code is and how easily it can be understood, maintained, and extended.

> [!IMPORTANT]
> Explain to the students that this demo isn't about best practices for developing high-quality code. Instead, it focuses on how to use GitHub Copilot Chat to generate suggestions for improving code quality in a sample application. The suggestions do not represent best practices or comprehensive solutions for developing high-quality code. Developers should use their judgment and expertise to evaluate and implement the suggestions provided by GitHub Copilot Chat. Implementing suggestions proposed by GitHub Copilot does not replace the need for thorough code reviews and testing.

The following sections provide an overview of code refactoring and code quality that your students should be aware of.

#### Code refactoring and high-quality code

Code refactoring is the process of restructuring existing code without changing its external behavior. The goal of code refactoring is to improve the internal structure of the codebase, making it easier to understand, maintain, and extend. Code refactoring can help you produce high-quality code by enhancing readability, reducing complexity, improving modularity, and increasing reusability. Each of these factors helps to create a more manageable and maintainable codebase.

Developers should consider the following factors when working on code quality improvements:

- **Readability**: Improve or enhance the readability of code to make it easier for developers to understand.
- **Complexity**: Reduce code complexity to make the code easier to understand, manage, and maintain.
- **Modularity and reusability**: Break code down into smaller, reusable modules or components to make the code easier to manage and maintain.

The factors listed above represent three common areas that developers identify when discussing code quality. Other factors that can be associated with code quality include:

- **Testability**: The ease with which the code can be tested to ensure it works correctly. Often a byproduct of good design and modularity.
- **Extensibility**: The ease with which the code can be extended or enhanced to add new features or functionality. Often a byproduct of good design and modularity.

Code quality is not the only factor that developers consider during code reviews. Here are some more factors that developers often evaluate in addition to code quality:

- **Reliability**: The code's ability to perform its intended functions under specified conditions.
- **Performance**: How efficiently the code executes.
- **Security**: The code's ability to protect against unauthorized access and other security threats.

### Use GitHub Copilot Chat to improve code quality

In this section of the demo, you use GitHub Copilot Chat to improve the code quality of a sample Python application. The application is a simple bank account management system that includes methods for crediting and debiting accounts, transferring money between accounts, and calculating interest.

Use the following steps to complete this section of the demo:

1. Open the **APL2007M5BankAccount** project folder in Visual Studio Code.

1. Open the `main.py` file in the editor.

1. Review the code in the `main.py` file.

    Notice that the code is functional but could be improved in terms of readability, maintainability, and modularity.

1. Open the Chat view, and then enter the following prompt:

    ```plaintext
    Suggest improvements to the code quality of this file.
    ```

1. Take a minute to review the suggestions provided by GitHub Copilot Chat.

    The suggestions may include refactoring methods to reduce complexity, adding comments to improve readability, and breaking down large methods into smaller, reusable components.

1. Select one of the suggestions, and then ask GitHub Copilot Chat to provide a code snippet that implements the suggestion.

    For example, if GitHub Copilot Chat suggests breaking down a large method into smaller components, you can ask it to provide the refactored code.

1. Review the code snippet provided by GitHub Copilot Chat, and then decide whether to implement the suggestion.

    > [!IMPORTANT]
    > Always review the suggestions provided by GitHub Copilot Chat before implementing them. Use your judgment and expertise to evaluate whether the suggestions align with your project requirements and coding standards.

1. Implement the suggestion in the `main.py` file, and then test the application to ensure that it still works as expected.

### Summary

In this demo, you used GitHub Copilot Chat to generate suggestions that help you improve code quality in a sample application. You developed prompts that focused on improving code readability, maintainability, and modularity. You reviewed the suggestions provided by GitHub Copilot Chat and implemented the updates that helped to improve code quality. You also considered additional suggestions that could further improve your code. 