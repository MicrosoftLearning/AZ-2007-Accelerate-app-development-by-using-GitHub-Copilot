---
demo:
    title: 'Demo: Generate inline code documentation by using GitHub Copilot Chat'
    module: 'Module 2: Generate documentation using GitHub Copilot tools'
---

# Demo: Generate inline code documentation by using GitHub Copilot Chat

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Python 3.7 or higher installed on your system.
- A code editor such as Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects written in Python.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

Documenting your code is an important aspect of the software development process. Inline documentation (code comments) help developers understand the codebase, its purpose, and how to use it.

GitHub Copilot Chat can help you document your code quickly and accurately. You have a few options for generating inline documentation using GitHub Copilot Chat:

- Construct your own natural language prompt that can be used to generate specific documentation.
- Use the `/doc` command during an inline chat session to generate comments for selected code.
- Use the **Generate Docs** smart action to generate comments for selected code.

Properly documenting your code creates a more readable and maintainable codebase that's easier for other developers to understand and work with.

### Generate inline code documentation using the Chat view

In this demonstration, you use GitHub Copilot Chat to generate inline code documentation for the `APL2007M2Sample1` project.

Use the following steps to complete this section of the demo:

1. Ensure that you have the `APL2007M2Sample1` project open in Visual Studio Code.

1. Open the `main.py` file.

1. Select all of the code starting from the class declaration to the end of the file.

1. Open the Chat view.

1. To see how GitHub Copilot Chat would document the selected code, enter the following prompt:

    ```plaintext
    @workspace #selection generate inline code documentation for the selected code
    ```

1. Take a minute to review the suggested code documentation.

    The generated response should look similar to the following code sample:

    ```python
    class AsyncWebFetcherApp:
        def __init__(self, root):
            # Initialize the application with a root Tkinter window
            self.root = root
            self.root.title("Async Web Fetcher")

            # Create a start button and a results text box
            self.start_button = tk.Button(root, text="Start", command=self.on_start_button_click)
            self.start_button.pack()
            self.results_textbox = scrolledtext.ScrolledText(root, width=80, height=20)
            self.results_textbox.pack()

            # List of URLs to fetch
            self.url_list = [
                "https://docs.microsoft.com",
                "https://docs.microsoft.com/azure",
                # Additional URLs...
            ]

        def on_start_button_click(self):
            # Disable the start button and clear the results text box
            self.start_button.config(state=tk.DISABLED)
            self.results_textbox.delete(1.0, tk.END)
            asyncio.run(self.start_sum_page_sizes())

        async def start_sum_page_sizes(self):
            # Asynchronously fetch the size of each URL and display the results
            async with aiohttp.ClientSession() as session:
                total_size = 0
                tasks = [self.process_url(url, session) for url in self.url_list]
                results = await asyncio.gather(*tasks)
                for url, size in results:
                    self.results_textbox.insert(tk.END, f"{url}: {size} bytes\n")
                    total_size += size
                self.results_textbox.insert(tk.END, f"\nTotal size: {total_size} bytes\n")
            self.start_button.config(state=tk.NORMAL)

        async def process_url(self, url, session):
            # Fetch the content of a URL and return its size
            async with session.get(url) as response:
                content = await response.read()
                return url, len(content)
    ```

    The response includes suggested code comments and *a portion* of the associated code. Some of your code may be omitted for brevity. You could manually move code comments into the actual code file.

    Inline chat provides a more direct approach for adding comments to your code.

### Generate inline code documentation using inline chat

1. Scroll to the top of the `main.py` file.

1. Select the `on_start_button_click` method.

1. To open an inline chat, press **Ctrl+I**.

1. To generate inline documentation for the `on_start_button_click` method, enter the following prompt:

    ```plaintext
    /doc
    ```

1. Take a minute to review the code documentation generated.

    Notice that the suggested documentation for the `on_start_button_click` method includes a summary and descriptions of the two parameters. When a method includes a return value, a description of the return value is also included.

    > [!IMPORTANT]
    > Always review the GitHub Copilot's suggested updates before accepting. If you discover an issue in a suggested code update, you can either discard the update or attempt to correct the issue before accepting the suggested code update.

1. To discard the suggested update, select **Discard**.

    In the next section, you generate documentation for all of the methods at once.

### Generate inline code documentation using the **Generate Docs** smart action

The **Generate Docs** smart action is another way to generate inline code documentation. You can use this smart action to generate comments that describe the selected code.

Use the following steps to complete this section of the demo:

1. In the Visual Studio Code editor, select all of the methods *inside* the `AsyncWebFetcherApp` class.

1. Right-click the selected code, select **Copilot**, and then select **Generate Docs**.

    Wait for the documentation to be generated.

1. Review the suggested changes.

    > [!IMPORTANT]
    > If you find issues in the generated documentation, modify the suggested changes before continuing.

1. Select **Accept**.

    Each of the methods in the `AsyncWebFetcherApp` class now includes generated comments.

### Summary

In this demo, you used GitHub Copilot Chat to generate inline code documentation for the `APL2007M2Sample1` app. You learned how to generate inline code documentation using the Chat view, inline chat, and the **Generate Docs** smart action. By generating code comments, you can create a more readable and maintainable codebase that's easier for other developers to understand and work with. Inline code documentation is an essential part of software development that helps developers understand the codebase, its purpose, and how to use it. 