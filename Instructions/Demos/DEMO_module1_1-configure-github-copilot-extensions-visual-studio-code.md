---
demo:
    title: 'Demo: Configure GitHub Copilot extensions for Visual Studio Code'
    module: 'Module 1: Get started with GitHub Copilot'
---

# Demo: Configure GitHub Copilot extensions for Visual Studio Code

## Instructions

The demo activities are designed for an environment that includes the following resources:

- Visual Studio Code.
- The C# Dev Kit extension for Visual Studio Code.
- The GitHub Copilot and GitHub Copilot Chat extensions for Visual Studio Code. A GitHub account with an active subscription for GitHub Copilot is required.
- Sample code projects created using C#.

**NOTE**: We recommend that instructors consider using their own GitHub account and GitHub Copilot subscription for the demos. This will enable you to control and customize your dev environment. It will also make it easier to adjust the demos to fit the needs of your classrooms.

**IMPORTANT**: If you choose to run the demos in the hosted lab environment rather than your instructor PC, you can unzip the sample apps in the hosted environment. You will need to configure the GitHub Copilot extensions in the hosted environment before you can run the demos. You may find that the hosted environment is slower than your local environment, so you may need to adjust the pace of the demos accordingly.

### Introduce the demo

GitHub Copilot settings are configured in your GitHub.com account and the Visual Studio Code environment. In Visual Studio Code, you access settings for GitHub Copilot and GitHub Copilot Chat using the GitHub Copilot status menu.

The settings in Visual Studio Code allow you to enable or disable GitHub Copilot for specific languages, configure the behavior of GitHub Copilot Chat, and customize the GitHub Copilot experience to suit your preferences. You can also configure GitHub Copilot settings on GitHub.com to manage your GitHub Copilot subscription, configure the retention of prompts and suggestions, and allow or block suggestions matching public code.

## Enable or disable GitHub Copilot

GitHub Copilot is enabled by default when you install the extension in Visual Studio Code. You can disable GitHub Copilot for a period of time if you need to.

To show the enable and disable options for the GitHub Copilot extension, follow these steps:

1. In Visual Studio Code, open the **Extensions** view.

1. In the list of installed extensions, scroll down until you find **GitHub Copilot**.

1. To display a dropdown menu for the GitHub Copilot extension that lists Enable and Disable options, select on the gear icon next to GitHub Copilot.

If you want to demonstrate the enable/disable options, you can select the disable option. However, be sure to re-enable GitHub Copilot before you continue with this demo.

## Configure GitHub Copilot and Copilot Chat in Visual Studio Code

The GitHub Copilot extensions are configured with default settings when you install the extensions in Visual Studio Code. You can customize these settings to suit your preferences.

Visual Studio Code provides two ways to access the settings for the GitHub Copilot extensions:

- You can use `Manage` icon to open the Visual Studio Code Settings tab. On the Settings tab, you can select **Extensions** and then select **Copilot**.
- You can use the GitHub Copilot status icon to access the GitHub Copilot status menu and then select **Edit Settings**.

Demonstrate using the GitHub Copilot status menu to access settings. This opens the Visual Studio Code Settings tab with settings filtered for GitHub Copilot. Using the status menu is the quickest way to access the settings for the GitHub Copilot extensions.

### Configure GitHub Copilot settings

To show the configuration settings for GitHub Copilot, follow these steps:

1. On the bottom panel of the Visual Studio Code window, to open the GitHub Copilot status menu, select the GitHub Copilot status icon.

    The GitHub Copilot status icon indicates whether GitHub Copilot is enabled or disabled. When enabled, the background color of the icon matches the color of the status bar. When disabled, the background color of the icon contrasts with the color of the status bar.

1. In the GitHub Copilot status menu, select **Edit Settings**.

1. Take a minute to review the list of available settings.

    Notice that the settings for both GitHub Copilot and GitHub Copilot Chat are listed. Also, under the Extensions label on the left, both extensions are labeled as Copilot. The first Copilot extension is for GitHub Copilot and the second is for GitHub Copilot Chat.

1. Under the Extensions label, select the first Copilot extension.

    Notice that the settings list is now filtered for GitHub Copilot only.

    The settings for GitHub Copilot include the following options:

    - Enable Auto Completions
    - Enable or disable Copilot completions for specified languages

1. Take a minute to review the settings for **Enable or disable Copilot completions for specified languages**.

    Notice that the settings for this option are configured using a list of languages and a value of **true** or **false** to enable or disable GitHub Copilot for each language. By default, GitHub Copilot is enabled for all languages. This setting is specified with the wildcard character `*` on the first row and the value **true**. The subsequent rows specify languages for which GitHub Copilot is enabled or disabled. For example, GitHub Copilot is enabled for **C#**, **JavaScript**, and **Python** and disabled for **Plaintext** and **Markdown**.

1. Under **Enable or disable Copilot completions for specified languages**, select **markdown**.

    Notice that the value for Markdown is set to **false**. This means that GitHub Copilot is disabled for Markdown files.

1. To enable Copilot for Markdown files, select **Edit Item** (pencil icon), select **false**, change the value to **true**, and then select **OK**.

    You can now use GitHub Copilot document projects using Markdown files.

1. Under the Extensions label, select the second Copilot extension.

    Notice that the settings list is now filtered for GitHub Copilot Chat only.

    The settings for GitHub Copilot Chat include **Preview** and **Experimental** options. Setting choices include the following options:

    - **Fix Test Failure**: This option is enabled by default so that GitHub Copilot can provide suggestions for fixing test failures.
    - **Follow Ups**: By default, this setting is set to **firstOnly**, which means that GitHub Copilot provides follow-up suggestions only after the first suggestion. The other options are **always** and **never**.
    - **Local Override**: By default, this option is set to **auto**, which means that GitHub Copilot uses the locale of the Visual Studio Code display language.
    - **Scope Selection**: This option is disabled by default. When enabled, the user is prompted for a scope symbol when the user uses `/explain` in Chat without anything selected in the Editor.
    - **Terminal Chat Location**: The default setting is chatView, which specifies the Chat View. The other options are for the Quick Chat area and the Terminal.
    - **Use Project Templates**: This option is enabled by default so that GitHub Copilot uses relevant GitHub project templates when the user uses `/new` in Chat.
    - **Enable Code Actions**: This option is enabled by default so that GitHub Copilot can provide code actions in the Editor.
    - **Trigger Automatically**: This option is enabled by default so that GitHub Copilot suggestions are shown automatically as you type.

    We recommend keeping the default settings during this training. This helps to ensure that you have the expected experience when working on the modules in this learning path. When you have completed the training, you can experiment with these settings to customize your experience with GitHub Copilot and Copilot Chat.

## Configure GitHub Copilot settings on GitHub.com

Your GitHub account settings on GitHub.com include options for configuring GitHub Copilot. These settings are used to manage your GitHub Copilot subscription, configure the retention of prompts and suggestions, and allow or block suggestions matching public code.

GitHub Copilot can be managed through personal accounts with GitHub Copilot Individual or through organization accounts with GitHub Copilot Business/Enterprise.

## Keyboard shortcuts for GitHub Copilot

You can use the default keyboard shortcuts in Visual Studio Code when using GitHub Copilot. Alternatively, you can rebind the shortcuts in the Keyboard Shortcuts editor using your preferred keyboard shortcuts for each specific command.
