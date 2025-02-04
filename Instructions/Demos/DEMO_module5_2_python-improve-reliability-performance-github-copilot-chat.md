---
demo:
    title: 'Demo: Improve code reliability and performance by using GitHub Copilot Chat'
    module: 'Module 5: Implement code improvements using GitHub Copilot tools'
---

# Demo: Improve code reliability and performance by using GitHub Copilot Chat

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

Code reliability and performance are closely related aspects of software quality. They are interdependent in the following ways:

- Improvements in one area can positively affect the other.
- Deficiencies in one can lead to problems with the other.

> [!IMPORTANT]
> Explain to the students that this demo isn't about best practices for developing reliable or high-performing code. Instead, it focuses on how to use GitHub Copilot Chat to generate suggestions for improving code reliability and performance in a sample application. The suggestions do not represent best practices or comprehensive solutions for code reliability and performance. Developers should use their judgment and expertise to evaluate and implement the suggestions provided by GitHub Copilot Chat. Implementing suggestions proposed by GitHub Copilot does not replace the need for thorough code reviews and testing.

#### Code reliability and performance

Developers should strive for a balance between code reliability and performance. A successful balance produces the following mutually beneficial results:

- Applications that meet functional requirements.
- Applications that deliver a seamless and efficient user experience.

The following sections provide an overview of code reliability and performance, along with other factors that your students should be aware of.

#### Code reliability

Code reliability refers to the ability of the code to perform its intended functions under specified conditions. Reliable code is robust, predictable, and free of defects. It handles errors gracefully and recovers from unexpected conditions without crashing or producing incorrect results.

#### Code performance

Code performance refers to the efficiency with which the code executes. High-performing code minimizes resource usage, such as CPU, memory, and disk I/O, while delivering the desired functionality. It also minimizes latency and maximizes throughput.

### Use GitHub Copilot Chat to improve code reliability and performance

In this section of the demo, you use GitHub Copilot Chat to improve the reliability and performance of a sample Python application. The application is a simple bank account management system that includes methods for crediting and debiting accounts, transferring money between accounts, and calculating interest.

Use the following steps to complete this section of the demo:

1. Open the **APL2007M5BankAccount-Reliability** project folder in Visual Studio Code.

1. Open the `main.py` file in the editor.

1. Review the code in the `main.py` file.

    Notice that the code is functional but could be improved in terms of reliability and performance.

1. Open the Chat view, and then enter the following prompt:

    ```plaintext
    Suggest improvements to the reliability and performance of this file.
    ```

1. Take a minute to review the suggestions provided by GitHub Copilot Chat.

    The suggestions may include adding error handling to improve reliability, optimizing algorithms to improve performance, and using asynchronous programming to improve responsiveness.

1. Select one of the suggestions, and then ask GitHub Copilot Chat to provide a code snippet that implements the suggestion.

    For example, if GitHub Copilot Chat suggests adding error handling to a method, you can ask it to provide the updated method with error handling.

1. Review the code snippet provided by GitHub Copilot Chat, and then decide whether to implement the suggestion.

    > [!IMPORTANT]
    > Always review the suggestions provided by GitHub Copilot Chat before implementing them. Use your judgment and expertise to evaluate whether the suggestions align with your project requirements and coding standards.

1. Implement the suggestion in the `main.py` file, and then test the application to ensure that it still works as expected.

### Summary

In this demo, you used GitHub Copilot Chat to generate suggestions that help you improve code reliability and performance in a sample application. You developed prompts that directed GitHub Copilot to provide suggestions that improve exception handling, reduce unexpected issues, and improve unit test support. You also created prompts that focused on improving performance with asynchronous tasks or methods. 