---
demo:
    title: 'Demo: Create unit tests by using GitHub Copilot Chat'
    module: 'Module 4: Develop unit tests using GitHub Copilot tools'
---

# Demo: Create unit tests by using GitHub Copilot Chat

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

Visual Studio Code and Python provide a rich set of features to help you create and manage unit tests for your Python projects. You can enable testing for your project, add test framework packages, run and manage unit tests, and generate unit test cases using GitHub Copilot Chat.

GitHub Copilot can help you generate unit tests for your code by providing inline chat suggestions.

In this demonstration, you create unit tests for a Python code project by using GitHub Copilot Chat in Visual Studio Code.

### Create a test file for your unit tests

Unit test files are typically created in a folder that's separate from the project that you're testing. This separation helps to keep the test code separate from the production code. In this demo, you create a test file for the `PrimeService` project.

To create a new test file, complete the following steps:

1. Open the **APL2007M4PrimeService** folder in Visual Studio Code.

1. Open the Explorer view in Visual Studio Code.

1. In the Explorer view, right-click the **APL2007M4PrimeService** folder, and then select **New File**.

1. Name the new file `test_prime_service.py`, and then press Enter.

1. Open the `test_prime_service.py` file in the editor.

1. Add the following boilerplate code to the `test_prime_service.py` file:

    ```python
    import unittest
    from main import PrimeService

    class TestPrimeService(unittest.TestCase):
        def setUp(self):
            self.prime_service = PrimeService()

        def test_is_prime_input_is_1_returns_false(self):
            self.assertFalse(self.prime_service.is_prime(1), "1 should not be prime")

    if __name__ == "__main__":
        unittest.main()
    ```

1. Save the `test_prime_service.py` file.

1. Run the test file to ensure that the boilerplate code is working correctly.

### Generate unit tests using inline chat

Use the following steps to complete this section of the demo:

1. In the Explorer view, open the `main.py` file.

1. Select the `is_prime` method.

1. Open an inline chat session, and then enter the following prompt:

    ```plaintext
    Create unit tests for the is_prime method using the unittest framework.
    ```

1. Take a minute to review the suggestions provided by inline chat.

    ```python
    def test_is_prime_input_is_2_returns_true(self):
        self.assertTrue(self.prime_service.is_prime(2), "2 should be prime")

    def test_is_prime_input_is_3_returns_true(self):
        self.assertTrue(self.prime_service.is_prime(3), "3 should be prime")

    def test_is_prime_input_is_4_returns_false(self):
        self.assertFalse(self.prime_service.is_prime(4), "4 should not be prime")

    def test_is_prime_negative_numbers_and_zero_return_false(self):
        for value in [-1, 0, 1]:
            with self.subTest(value=value):
                self.assertFalse(self.prime_service.is_prime(value), f"{value} should not be prime")
    ```

1. Notice that the Chat view and inline chat produce similar test coverage.

1. To discard the inline chat suggestion, select **Discard**, and then close the file tab created by the inline chat.

    Keep in mind that the unit tests suggested by GitHub Copilot during this demo may be incomplete. The next demo examines additional edge cases that you might consider testing.

### Summary

In this demo, you created unit tests for a Python code project by using GitHub Copilot Chat in Visual Studio Code. You created a test file, added a reference to the project that you wanted to test, and generated unit tests for the `is_prime` method in the `PrimeService` class. You used GitHub Copilot Chat to generate unit tests in the Chat view and the inline chat. 