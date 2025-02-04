---
demo:
    title: 'Demo: Improve code security by using GitHub Copilot Chat'
    module: 'Module 5: Implement code improvements using GitHub Copilot tools'
---

# Demo: Improve code security by using GitHub Copilot Chat

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

Code security refers to the measures taken to protect software from unauthorized access, data breaches, and other security threats. Code security is an essential aspect of software development that involves protecting applications and systems from security threats. Improving your code security can help you to protect your applications and systems from security threats.

> [!IMPORTANT]
> Explain to the students that this demo isn't about best practices for developing secure code. Instead, it focuses on how to use GitHub Copilot Chat to generate suggestions for improving code security in a sample application. The suggestions do not represent best practices or comprehensive solutions for code security. Developers should use their judgment and expertise to evaluate and implement the suggestions provided by GitHub Copilot Chat. Implementing suggestions proposed by GitHub Copilot does not replace the need for thorough code reviews and testing.

#### Code security

Ensuring code security is everyone's responsibility, not just the developer. However, developers play a crucial role by ensuring that the code they write follows secure coding practices. Secure coding practices help to ensure that software vulnerabilities can't be exploited by attackers. By following secure coding practices, developers can help to protect applications and systems from security threats.

### Use GitHub Copilot Chat to improve code security

In this section of the demo, you use GitHub Copilot Chat to improve the code security of a sample Python application. The application is a simple bank account management system that includes methods for crediting and debiting accounts, transferring money between accounts, and calculating interest.

Use the following steps to complete this section of the demo:

1. Open the **APL2007M5BankAccount-Security** project folder in Visual Studio Code.

1. Open the `main.py` file in the editor.

1. Review the code in the `main.py` file.

    Notice that the code is functional but could be improved in terms of security.

1. Open the Chat view, and then enter the following prompt:

    ```plaintext
    Suggest improvements to the security of this file.
    ```

1. Take a minute to review the suggestions provided by GitHub Copilot Chat.

    The suggestions may include adding input validation to prevent injection attacks, encrypting sensitive data, and implementing secure logging practices.

1. Select one of the suggestions, and then ask GitHub Copilot Chat to provide a code snippet that implements the suggestion.

    For example, if GitHub Copilot Chat suggests encrypting sensitive data, you can ask it to provide the updated code with encryption.

1. Review the code snippet provided by GitHub Copilot Chat, and then decide whether to implement the suggestion.

    > [!IMPORTANT]
    > Always review the suggestions provided by GitHub Copilot Chat before implementing them. Use your judgment and expertise to evaluate whether the suggestions align with your project requirements and coding standards.

1. Implement the suggestion in the `main.py` file, and then test the application to ensure that it still works as expected.

### Summary

In this demo, you used GitHub Copilot Chat to generate suggestions for improving code security in a sample application. You developed prompts that directed GitHub Copilot to provide suggestions for improving authentication, data protection, logging, and other security-related topics. You implemented the suggested updates to improve the security of the BankAccount class and the Program class in the **APL2007M5BankAccount-Security** project. 