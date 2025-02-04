---
demo:
    title: 'Demo: Generate code explanations using GitHub Copilot Chat'
    module: 'Module 2: Generate documentation using GitHub Copilot tools'
---

# Demo: Generate code explanations using GitHub Copilot Chat

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

GitHub Copilot Chat uses conversational AI assistance and smart commands to help you with coding-related tasks. One example is the ability to explain unfamiliar and complex code.

You can use GitHub Copilot Chat to generate explanations for a number of reasons. For example:

- GitHub Copilot Chat can explain an entire workspace or specific project files when you join an existing project.
- GitHub Copilot Chat can explain specific code lines or sections when code is complex or difficult to understand.
- GitHub Copilot Chat can explain errors in your code and suggest ways to fix them.
- GitHub Copilot Chat can explain how to add features to your project and provide code snippets that demonstrate how to implement the new code.

### Workspace and project file explanations

GitHub Copilot Chat can help you understand new projects or specific project files. You can use a combination `@workspace`, `/explain`, and `#file` in the Chat view or a Quick Chat window to generate an explanation of your project or specific project files.

Use the following steps to complete this section of the demo:

1. Open the **APL2007M2Sample1** folder in Visual Studio Code.

    1. Open Visual Studio Code on your PC.
    1. In Visual Studio Code, on the **File** menu, select **Open Folder**.
    1. Navigate to the working directory, open the **SampleAppPy** folder, and locate the **APL2007M2Sample1** folder.
    1. Select **APL2007M2Sample1** and then select **Select Folder**.

    The Visual Studio Code EXPLORER view should show a APL2007M2Sample1 code project containing the following files:

    - `main.py`
    - `README.md`

1. On Visual Studio Code's top menu bar, select **Open Chat**.

    The Open Chat button is located on the menu bar at the top of the Visual Studio Code window, just to the right of the Searchbox. It displays a small GitHub Copilot logo.

1. Use the following command to ask Copilot Chat to explain the `APL2007M2Sample1` project:

    ```plaintext
    @workspace Explain this project
    ```

1. Take a minute to review the response in the Chat view.

    GitHub Copilot Chat generates an explanation of the APL2007M2Sample1 project that's similar to the following response:

    > [!IMPORTANT]
    > GitHub Copilot Chat uses an AI model to generate responses. The responses you receive are similar to the responses shown in this training, but they aren't identical.

1. At the bottom of the Chat view, notice that GitHub Copilot Chat has suggested a follow-up question.

    The response you receive may include a different follow-up question.

    GitHub Copilot Chat builds a history of your chat conversation. The history helps GitHub Copilot Chat understand your interests. As you build a chat history, the AI model learns from your interactions and provides more relevant follow-up questions. Exploring "random" follow-up questions isn't recommended.

1. Open the `main.py` file in the editor.

1. Use the following command to ask Copilot to explain the `main.py` file:

    ```plaintext
    @workspace /explain #file:main.py
    ```

1. Take a minute to review the response in the Chat view.

    Notice that GitHub Copilot Chat generates a detailed explanation of the `main.py` file. The explanation includes information about the file's purpose, structure, and key components. You may also see a section that describes potential issues and improvements.

    Once again, GitHub Copilot Chat suggests a follow-up question.

    > [!IMPORTANT]
    > GitHub Copilot Chat maintains a history of your chat conversation. As you continue to ask questions, it refines its responses accordingly. The context of your questions, especially in regard to your code project, influences GitHub Copilot Chat's subsequent responses. This helps it to provide more accurate and relevant responses. It also means the response you receive for a particular question is likely to vary based on your conversation history.

### Selected code explanations

Even experienced developers encounter code that's difficult to understand. Rather than spending time trying to decipher complex code, you can ask GitHub Copilot Chat to provide an explanation. Chat view, inline chat, and smart actions can each be used to generate explanations for selected code lines or sections.

In this section of the demo, you use the **Explain** smart action to generate an explanation of selected code lines.

1. Ensure that you have the `main.py` file open in the editor.

1. Scroll down to locate the `start_sum_page_sizes` method.

    ```python
    async def start_sum_page_sizes(self):
        async with aiohttp.ClientSession() as session:
            total_size = 0
            tasks = [self.process_url(url, session) for url in self.url_list]
            results = await asyncio.gather(*tasks)
            for url, size in results:
                self.results_textbox.insert(tk.END, f"{url}: {size} bytes\n")
                total_size += size
            self.results_textbox.insert(tk.END, f"\nTotal size: {total_size} bytes\n")
        self.start_button.config(state=tk.NORMAL)
    ```

1. Select the following code lines, and then use the **Explain** smart action to generate an explanation.

    To select the **Explain** smart action, right-click the selected code lines, select **Copilot**, and then select **Explain** from the context menu.

    ```python
    tasks = [self.process_url(url, session) for url in self.url_list]
    results = await asyncio.gather(*tasks)
    ```

1. Take a minute to review the response in the Chat view.

1. Notice the level of detail included in the explanation.

    GitHub Copilot Chat generates detailed explanations that include information about the selected code lines, their purpose, and how they work. Responses include code snippets and natural language descriptions that help you understand the code.

### Summary

In this demo, you used GitHub Copilot Chat to generate explanations for code lines, errors, and new features. GitHub Copilot Chat provides a powerful set of features that can help you ramp up on new project quickly. By using the inline chat and Chat view, you can get help from GitHub Copilot Chat without leaving the Visual Studio Code environment. GitHub Copilot Chat's AI model generates accurate and useful responses that can help you become a more efficient and effective developer. 