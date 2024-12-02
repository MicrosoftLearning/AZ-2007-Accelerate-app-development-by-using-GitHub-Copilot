---
lab:
    title: 'Lab: Accelerate app development by using GitHub Copilot'
    type: 'Answer Key'
    module: 'Modules 2-5'
---

# Lab: Accelerate app development by using GitHub Copilot
# Student lab answer key

## Part 1: Analyze and document code using GitHub Copilot tools

### Before you start

#### Project overview

You're a software developer working for a regional IT department. Most of the applications that you work on support the local community. Recently, the community library's servers were damaged in an accident, and it will take weeks to get the authorization to replace them. Your department needs to develop a temporary solution that will enable librarians to perform basic functions.

Your team has met with the librarians. They need a minimal solution that enables them to provide library patrons with essential services like book loans and returns. Your team investigates the available resources and develops a plan. Initially, only you and one other coworker will be assigned to the project. The local government has closed the library until your temporary solution is available. You have three days develop a v1 solution that enables the library to reopen.

While your colleague begins working on the software, you use library records to create JSON files that represent the library's patron accounts, books, and book loans. By the end of the second day you're ready to begin helping with the code. The solution is a console application that can be run on one of the library's laptop computers. The librarians understand that there isn't time for a pretty interface, but stress that the app must be secure and reliable. You have one more day before you need to demonstrate version 1.0 of your app.

You'll use GitHub Copilot to help get the work done as efficiently as possible. If all goes well, your app will be used to support the library's book drives and other offsite functions in the future.

#### Lab scenario (part 1)

GitHub Copilot can help you understand and document a codebase by generating explanations and documentation.

In part 1 of this lab, you'll use GitHub Copilot to analyze and document the library application. You'll also create a GitHub repository for the library application and generate a README file for the repository using GitHub Copilot.

Part 1 includes the following exercises:

- Configure GitHub Copilot extensions for Visual Studio Code.
- Use GitHub Copilot to explain the library application codebase.
- Use Visual Studio Code to create a GitHub repository for the library application.
- Use GitHub Copilot extensions to create a README.md file for the repository.

### Exercise 1: Configure GitHub Copilot extensions for Visual Studio Code

You'll use your GitHub account to authorize Visual Studio Code to verify your GitHub Copilot subscription.

Use the following steps to install the GitHub Copilot extensions:

1. Open a browser window.

1. To open the GitHub Enterprise portal, navigate to the following URL:

    ```plaintext
    https://github.com/enterprises/Microsoft-APL/sso
    ```

1. Sign in to your GitHub account using the following credentials:

    Email/Username: `@lab.CloudPortalCredential(1).Username`

    Password: `@lab.CloudPortalCredential(1).Password`

1. Open Visual Studio Code.

1. On the left side menu, select **Extensions**.

1. In the Search Extensions in Marketplace text box, type **GitHub Copilot** and then press Enter.

1. In the filtered list of extensions, select the GitHub Copilot extension authored by GitHub.

1. On the GitHub Copilot extension page, select **Install**.

1. When you see the "Sign in to use GitHub Copilot notification, select **Sign in to GitHub**.

    If you see a dialog saying that GitHub Copilot wants to sign in using GitHub, select **Allow**.

    Since you're already signed in to your GitHub account in a browser window, a new Verify Session tab should open in your browser window.

1. On the Verify Session page, select **Continue**.

1. On the Authorize Visual Studio Code page, select **Authorize Visual Studio Code**.

1. To return to Visual Studio Code, select **Open**.

1. Close and then re-open Visual Studio Code.

    Restarting Visual Studio Code helps to ensure that GitHub Copilot is integrated in the Visual Studio Code user interface as expected.

1. Notice that the **Open Chat** button is now visible on the right side of the Command Center at the top if the Visual Studio Code window.

#### Exercise 1 summary

In this exercise, you installed the GitHub Copilot extension in Visual Studio Code. You also authorized Visual Studio Code to access your GitHub account. You're now ready to use GitHub Copilot to analyze and document the library application codebase.

### Exercise 2: Analyze the library application codebase

Before you create a code repository and README file, you should take some time to examine the codebase. It's important to understand the app architecture and key features before documenting the project. You should also run the application to ensure that it performs as expected.

#### Task 1: Load the library application in your development environment

Your colleague has developed an initial version of the library application and has made it available as a .zip file. To prepare for this lab, you need to perform the following actions:

- Download a zip file containing the solution.
- Extract the code files.
- Open the library application in Visual Studio Code and ensure that it builds successfully.

Use the following steps to prepare the library application:

1. Ensure that you have your web browser open, and then open a new browser tab.

1. To download the zip file containing your code project, navigate to the following URL:

    ```plaintext
    https://raw.githubusercontent.com/MicrosoftLearning/APL-2007-Accelerate-app-development-by-using-GitHub-Copilot/master/LearnModuleExercises/Downloads/GuidedProjectApp.zip
    ```

    The zip file containing your solution code, GuidedProjectApp.zip, should download automatically.

1. Once the download is complete, close the browser tab.

    Keep the browser page for you GitHub account open. You'll use it later in the lab.

1. Open Windows File Explorer and navigate to the Downloads folder.

1. Unzip the downloaded project files.

    Unzip the code project in your development environment. For example:

    1. On your local machine, navigate to your downloads folder.

    1. Right-click **GuidedProjectApp.zip**, and then select **Extract all**.

    1. Select **Show extracted files when complete**, and then select **Extract**.

    1. Make note of the extracted folder location.

1. Copy the extracted folder, AccelerateDevGitHubCopilot, to a location that's easy to access, such as your Windows Desktop folder.

1. Open the **AccelerateDevGitHubCopilot** folder in Visual Studio Code.

    For example:

    1. Open Visual Studio Code on your PC.

    1. In Visual Studio Code, on the **File** menu, select **Open Folder**.

    1. Navigate to the Windows Desktop folder, and then locate the **AccelerateDevGitHubCopilot** folder.

    1. Select **AccelerateDevGitHubCopilot** and then select **Select Folder**.

    1. Select **Yes, I trust the authors**.

1. In the Visual Studio Code EXPLORER view, select SOLUTION EXPLORER, and then verify the following project structure:

    - AccelerateDevGitHubCopilot\
        - src\
            - Library.ApplicationCore\
            - Library.Console\
            - Library.Infrastructure\
        - tests\
            - UnitTests\

1. Ensure that the solution builds successfully.

    For example, in the SOLUTION EXPLORER view, right-click **AccelerateDevGitHubCopilot**, and then select **Build**.

    You'll see several Warnings, but there shouldn't be any Errors. You'll run the application later in this exercise.

    > [!NOTE]
    > Do not install workload updates unless your instructor directs you to do so.

#### Task 2: Use GitHub Copilot to explain the library application codebase

GitHub Copilot can help you to understand an unfamiliar codebase by generating explanations at the solution and feature levels.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the AccelerateDevGitHubCopilot solution open in Visual Studio Code.

1. Open the Chat view.

    You can open the Chat view in the following ways:

    - Select the **Open Chat** button (located at the top of the Visual Studio Code window, just to the right of the command center).
    - Use the keyboard shortcut: **Ctrl+Alt+I**.
    - Open the GitHub Copilot status menu, and then select **GitHub Copilot Chat**.

1. Enter a prompt that uses GitHub Copilot's **@workspace** participant to generate a description of the project.

    For example, enter the following prompt in the Chat view:

    ```plaintext
    @workspace Describe this project
    ```

    If you see a dialog box asking you to sign in to GitHub, select **Allow** and then follow the instructions to sign in using your GitHub account.

1. Take a couple minutes to review the response.

    You should see a response similar to the following description:

    ```markdown
    This project is a library management system implemented in C#. It consists of three main components:
    
    1. **Library.ApplicationCore**: This is the core application library containing the main business logic, entities, enums, and interfaces. It includes:
    
        - Entities such as Book, Patron, Loan, etc.
        - Enums like MembershipRenewalStatus, LoanReturnStatus, and LoanExtensionStatus.
        - Services like LoanService and PatronService.
        - Interfaces like ILoanRepository, IPatronRepository, ILoanService, and IPatronService.

    2. **Library.Console**: This is a console application that interacts with the user. It includes:
    
        - The main entry point in Program.cs.
        - Configuration settings in appSettings.json.
        - Console interaction logic in ConsoleApp.cs.

    3. **Library.Infrastructure**: This library handles data persistence. It includes:
    
        - JSON-based repositories like JsonPatronRepository and JsonLoanRepository.
        - Data loading and saving logic in JsonData.

    Additionally, there are unit tests located in the UnitTests directory, which test the functionality of the core services using the NSubstitute mocking framework and xUnit.
    
    The project uses .NET 8.0 and is configured to build and test using GitHub Actions as defined in the build-test.yml file. The solution file is AccelerateDevGitHubCopilot.sln, which includes all the projects and their configurations.
    ```

1. Use the Solution Explorer view to expand the project folders.

1. Locate and open the **ConsoleApp.cs** file.

    The ConsoleApp.cs file is located in the src/Library.Console project.

1. Enter a prompt in the Chat view that generates a description of the ConsoleApp class.

    For example, enter the following prompt in the Chat view:

    ```plaintext
    @workspace #editor Describe the ConsoleApp class
    ```

1. Take a couple minutes to review the response.

    You should see a response similar to the following description:

    ```markdown
    The ConsoleApp class in ConsoleApp.cs is responsible for managing the console-based user interface of the library management system. It handles user interactions, processes user inputs, and coordinates actions with the underlying services and repositories.

    ### Fields
    - _currentState: Tracks the current state of the console application.
    - matchingPatrons: A list of patrons that match a search query.
    - selectedPatronDetails: Holds details of the currently selected patron.
    - selectedLoanDetails: Holds details of the currently selected loan.
    - _patronRepository: An instance of IPatronRepository for accessing patron data.
    - _loanRepository: An instance of ILoanRepository for accessing loan data.
    - _loanService: An instance of ILoanService for performing loan-related operations.
    - _patronService: An instance of IPatronService for performing patron-related operations.

    ### Constructor
    - ConsoleApp(ILoanService loanService, IPatronService patronService, IPatronRepository patronRepository, ILoanRepository loanRepository): Initializes the ConsoleApp with the provided services and repositories.

    ### Methods
    - Run(): The main entry point for running the console application.
    - PatronSearch(): Handles the logic for searching patrons.
    - ReadPatronName(): Reads the patron's name from the console input.
    - PrintPatronsList(List<Patron> matchingPatrons): Prints a list of matching patrons to the console.
    - PatronSearchResults(): Handles the logic for displaying and selecting from the search results.
    - ReadInputOptions(CommonActions options, out int optionNumber): Reads input options from the console.
    - WriteInputOptions(CommonActions options): Writes the available input options to the console.
    - PatronDetails(): Displays details of the selected patron.
    - LoanDetails(): Displays details of the selected loan and handles actions like extending or returning the loan.

    The class uses a state machine approach to manage different states of the console application, such as searching for patrons, displaying search results, showing patron details, and handling loan details.
    ```

1. Open the **Program.cs** file.

1. Enter a prompt in the Chat view that generates a description of the Program.cs file.

    For example, enter the following prompt in the Chat view:

    ```plaintext
    @workspace #editor Describe the Program.cs file
    ```

1. Take a couple minutes to review the response.

    You should see a response similar to the following description:

    ```markdown
    The Program.cs file is the entry point for the console application. It sets up the dependency injection container, configures services, and starts the ConsoleApp.
    
    1. **Dependency Injection Setup**:
        - Creates a ServiceCollection to register services.
        - Builds a configuration object from the appSettings.json file.
        - Registers various services and repositories with different lifetimes (singleton, scoped).
    
    2. **Service Registration**:
        - Registers the repositories: JsonPatronRepository and JsonLoanRepository.
        - Registers the services: LoanService and PatronService.
        - Registers the JsonData class as a singleton.
        - Registers the ConsoleApp class as a singleton.
    
    3. **Service Provider**:
        - Builds the service provider from the registered services.
        - Retrieves the ConsoleApp service and runs it asynchronously.

    This setup ensures that all dependencies are properly injected and configured before the application starts running.
    ```

1. Expand the Library.Infrastructure project, and then expand the Data folder.

1. Add the **JsonData.cs**, **JsonLoanRepository.cs**, and **JsonPatronRepository.cs** files to the Chat context.

    You can use a drag-and-drop operation to add the files from the Solution Explorer to the Chat view. You can also use the **Attach Context** button (paper clip) in the Chat view to add files to the Chat context.

1. Enter a prompt in the Chat view that generates an explanation of the data access classes.

    For example, enter the following prompt in the Chat view:

    ```plaintext
    @workspace /explain Explain how the data access classes work
    ```

1. Take a couple minutes to review the response.

    You should see a response similar to the following description:

    ```markdown
    The data access classes in this project are designed to handle the loading, saving, and manipulation of data stored in JSON files. These classes include JsonData, JsonPatronRepository, and JsonLoanRepository. Here's an explanation of how each class works:
    
    ### JsonData Class
    The JsonData class is responsible for loading and saving data from and to JSON files. It also provides methods to populate related entities.
    
    #### Key Responsibilities:
    1. **Loading Data**: The LoadData method loads data from JSON files into in-memory collections (Authors, Books, BookItems, Patrons, Loans).
    2. **Saving Data**: The SaveJson method saves data to JSON files. Specific methods like SaveLoans and SavePatrons handle saving loans and patrons, respectively.
    3. **Ensuring Data is Loaded**: The EnsureDataLoaded method ensures that data is loaded into memory before any operations are performed.
    4. **Populating Related Entities**: Methods like GetPopulatedPatron, GetPopulatedLoan, GetPopulatedBookItem, and GetPopulatedBook populate related entities to provide a complete view of the data.
    
    #### Example Methods:
    - **LoadData**: Loads all data from JSON files.
    - **SaveLoans**: Saves loan data to the JSON file.
    - **GetPopulatedPatron**: Populates a patron with related loans.
    - **SearchBookByTitle**: Searches for a book by its title.
    
    ### JsonPatronRepository Class
    The JsonPatronRepository class implements the IPatronRepository interface and provides methods to interact with patron data.

    #### Key Responsibilities:
    1. **Searching Patrons**: The SearchPatrons method searches for patrons by name. 
    2. **Getting a Patron**: The GetPatron method retrieves a patron by ID and populates related data.
    3. **Updating a Patron**: The UpdatePatron method updates patron information and saves it to the JSON file.
    
    #### Example Methods:
    - **SearchPatrons**: Searches for patrons whose names contain the search input.
    - **GetPatron**: Retrieves a patron by ID and populates related loans.
    - **UpdatePatron**: Updates patron information and saves it to the JSON file.
    
    ### JsonLoanRepository Class
    The JsonLoanRepository class implements the ILoanRepository interface and provides methods to interact with loan data.
    
    #### Key Responsibilities:
    1. **Getting a Loan**: The GetLoan method retrieves a loan by ID and populates related data.
    2. **Updating a Loan**: The UpdateLoan method updates loan information and saves it to the JSON file.
    
    #### Example Methods:
    - **GetLoan**: Retrieves a loan by ID and populates related book items and patrons.
    - **UpdateLoan**: Updates loan information and saves it to the JSON file.
    
    ### How They Work Together
    1. **Loading Data**: When the application starts, the JsonData class loads data from JSON files into memory.
    2. **Searching and Retrieving Data**: The JsonPatronRepository and JsonLoanRepository classes use the JsonData class to search and retrieve data. They ensure data is loaded before performing operations.
    3. **Updating Data**: When data is updated, the repository classes call methods on the JsonData class to save the updated data back to the JSON files.
    4. **Populating Related Entities**: The JsonData class provides methods to populate related entities, ensuring that when a patron or loan is retrieved, it includes related data like loans or book items.
    
    ### Example Workflow
    1. **Search for a Patron**:
        - The SearchPatrons method in JsonPatronRepository calls EnsureDataLoaded to ensure data is loaded.
        - It then searches the Patrons collection for matching names and returns the results.

    2. **Get a Loan**:
       - The GetLoan method in JsonLoanRepository calls EnsureDataLoaded to ensure data is loaded.
       - It retrieves the loan by ID and uses GetPopulatedLoan to include related book items and patrons.

    3. **Update a Patron**:
       - The UpdatePatron method in JsonPatronRepository calls EnsureDataLoaded to ensure data is loaded.
       - It updates the patron information and calls SavePatrons to save the updated data to the JSON file.

    By using these data access classes, the application can efficiently manage data stored in JSON files, ensuring that data is loaded, manipulated, and saved correctly.
    ```

1. Take a couple minutes to examine the JSON data files that are used to simulate library records.

    The JSON data files are located in the src/Library.Console/Json folder.

    The data files use ID properties to link entities. For example, a Loan object has a PatronId property that links to a Patron object with the same ID. The JSON files contain data for authors, books, book items, patrons, and loans.

    > [!NOTE]
    > Notice that Author names, book titles, and patron names have been anonymized for the purposes of this guided project.

#### Task 3: Build and run the application

Running the application will help you understand the user interface, key features of the application, and how app components interact.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the **Solution Explorer** view open.

    The Solution Explorer view is not the same as the Explorer view. The Solution Explorer view uses project and solution files as "directory" nodes to display the structure of the solution.

1. To run the application, right-click **Library.Console**, select **Debug**, and then select **Start New Instance**.

    If the **Debug** and **Start New Instance** options aren't displayed, ensure that you're using the Solution Explorer view and not the Explorer view.

    The following steps guide you through a simple use case.

1. When prompted for a patron name, type **One** and then press Enter.

    > [!NOTE]
    > The application uses a case-sensitive search process. You must enter "One" with a capital "O".

    You should see a list of patrons that match the search query.

1. At the "Input Options" prompt, type **2** and then press Enter.

    Entering **2** selects the second patron in the list.

    You should see the patron's name and membership status followed by book loan details.

1. At the "Input Options" prompt, type **1** and then press Enter.

    Entering **1** selects the first book in the list.

    You should see book details listed, including the due date and return status.

1. At the "Input Options" prompt, type **r** and then press Enter.

    Entering **r** returns the book.

1. Verify that the message "Book was successfully returned." is displayed.

    The message "Book was successfully returned." should be followed by the book details. Returned books are marked with **Returned: True**.

1. To begin a new search, type **s** and then press Enter.

1. When prompted for a patron name, type **One** and then press Enter.

1. At the "Input Options" prompt, type **2** and then press Enter.

1. Verify that first book loan is marked **Returned: True**.

1. At the "Input Options" prompt, type **q** and then press Enter.

1. Stop the debug session.

#### Exercise 2 summary

This exercise helped you understand the library application codebase and how the application interacts with the user. You used GitHub Copilot to generate explanations for the project structure, selected files, and data access classes. You also ran the application to see how the console interface works and how the application components interact.

### Exercise 3: Create the GitHub repository and empty README file

Creating the GitHub repository for your code will enable you to share your work with others and collaborate on the project.

#### Task 1: Create a GitHub repository

Use the following steps to complete this section of the exercise:

1. Ensure that you have your GitHub account open in a browser window.

    If necessary, open a browser window and use the following information to login:

    URL: `https://github.com/enterprises/Microsoft-APL/sso`

    Email/Username: `@lab.CloudPortalCredential(1).Username`

    Password: `@lab.CloudPortalCredential(1).Password`

1. Open your GitHub account menu, and then select **Your repositories**.

    You should see a message indicating that you don't have any repositories yet.

1. To construct Git that can be used to configure Git with the credentials associated with your GitHub account, open Notepad and then build the following Git commands:

    ```bash
    git config --global user.email "lab assigned email"
    git config --global user.name "user name"
    ```

    Replace "lab assigned email" with the email defined in the lab environment: +++@lab.CloudPortalCredential(1).Username+++

    Replace "user name" with your own name.

1. Switch to the Visual Studio Code window.

1. Open Visual Studio Code's integrated terminal.

    On the Terminal menu, select **New Terminal**.

1. To configure Git using the credentials associated with your GitHub account, enter the two commands that you constructed in Notepad.

1. In Visual Studio Code, open the Source Control view.

1. Select **Publish to GitHub**.

    If a dialog box opens asking to sign in using your GitHub account, complete the following steps:

    1. Select **Allow**.
    1. Select the account that you're using in this lab environment.
    1. If necessary, select **Publish to GitHub** again.

1. Accept the default name for the repository (AccelerateDevGitHubCopilotSelect) and select **Publish to GitHub private repository**.

    You may be asked to authorize your GitHub account again. Follow the onscreen instructions to authorize your account in the browser if necessary. This can result in your repository being published using the "first commit" commit message.

1. In the Source Control view, enter a commit message, such as "Initial commit", and then select **Publish Branch**.

1. Notice that Visual Studio Code displays a status messages during the publish process.

    When the publish process is finished, you'll see a message informing you that your code was successfully published to the GitHub repository that you specified.

#### Task 2: Create an empty README file in GitHub

Use the following steps to complete this section of the exercise:

1. Switch to the browser window displaying your GitHub account.

1. Open the new AccelerateDevGitHubCopilot repository in your GitHub account.

    If you don't see your AccelerateDevGitHubCopilot repository, refresh the page. If you still don't see the repository, try the following steps:

    1. Switch to Visual Studio Code.
    1. Open your notifications (a notification was generated when the new repository was published).
    1. Select **Open on GitHub** to open your repository.

1. On the Code tab of your AccelerateDevGitHubCopilot repository, select **Add a README**.

1. In the README.md editor, type **Coming soon** and then select **Commit changes**.

1. In the Commit changes dialog, select **Commit changes**.

#### Task 3: Pull the changes to your local repository

Use the following steps to complete this section of the exercise:

1. Switch to Visual Studio Code and ensure that the Source Control view is open.

1. Open the **More Actions** menu, and then select **Pull**.

    The More Actions menu can be opened using the ellipsis in the top-right corner of the Source Control view.

1. Open the EXPLORER view (collapse the SOLUTION EXPLORER and use Visual Studio Code's default file/folder explorer), and then expand the **AccelerateDevGitHubCopilot** folder.

1. Open the README.md file.

    You should see the message "Coming soon".

    > [!NOTE]
    > You could have created the README file content directly in Visual Studio Code and then pushed the updates to the GitHub repository.

You'll be using GitHub Copilot Chat to update your repository's README file in the next exercise.

#### Exercise 3 summary

This exercise helped you create a GitHub repository for the library application and an empty README file. You also pulled the changes to your local repository to ensure that you have the latest updates.

### Exercise 4: Create the project documentation for the README file

The README file is an essential part of any GitHub repository. The README provides information based on the needs of the project, project contributors, and stakeholders.

For this guided project exercise, your README file should include the following sections:

- **Project Title**: A brief, clear title for the project.
- **Description**: A detailed explanation of what the project is and what it does.
- **Project Structure**: A breakdown of the project structure, including key folders and files.
- **Key Classes and Interfaces**: A list of key classes and interfaces in the project.
- **Usage**: Instructions on how to use the project, often including code examples.
- **License**: The license that the project is under.

#### Task 1: Use GitHub Copilot to generate project documentation

In this section of the exercise, you'll use GitHub Copilot to create project documentation and add it to your README.md file.

Use the following steps to complete this section of the exercise:

1. Open the Chat view.

    When you're interested in specific code or files, you can use drag-and-drop operations to add files to the Chat view context. In this case, you're interested in the overall solution, so you'll use the `@workspace` participant rather than adding individual files.

1. To generate project documentation for your README file, enter the following prompt:

    ```plaintext
    @workspace Generate the contents of a README.md file for the code repository. Use "Library App" as the project title. The README file should include the following sections: Description, Project Structure, Key Classes and Interfaces, Usage, License. Format all sections as raw markdown. Use a bullet list with indents to represent the project structure. Do not include ".gitignore" or the ".github", "bin", and "obj" folders.
    ```

    > [!NOTE]
    > Using multiple prompts, one for each section of the README file would produce more detailed results. A single prompt is used in this exercise to simplify the process.

1. Review the response to ensure each section is formatted as markdown.

    > [!NOTE]
    > You can update readme sections individually to provide more detailed information or if they aren't formatted correctly. You can also copy GitHub Copilot's response to the README file and then make corrections directly in the markdown file.

1. With the markdown file open in the editor, open the GitHub Copilot status menu, and then select **Enable completions for markdown**.

1. Copy the suggested documentation sections to the README.md file.

    You can use GitHub Copilot to generate suggestions for markdown documentation. This feature can help you format the markdown file correctly. For example, you can open the inline chat and ask GitHub Copilot to correct the formatting of the markdown documentation.

1. Adjust the formatting manually if needed, and then save the updated README.md file.

    You should have a README file that includes the project title, description, project structure, key classes and interfaces, usage instructions, and license information.

    ```markdown
    # Library App
    
    ## Description
    Library App is a console-based application for managing library operations such as patron management, book loans, and membership renewals. It uses a JSON-based data storage system and provides various services to handle library functionalities.
    
    ## Project Structure
    - AccelerateDevGitHubCopilot.sln
    - README.md
    - src
      - Library.ApplicationCore/
        - Entities/
          - `Author.cs`
          - `Book.cs`
          - `BookItem.cs`
          - `Loan.cs`
          - `Patron.cs`
        - Enums/
          - `LoanExtensionStatus.cs`
          - `LoanReturnStatus.cs`
          - `MembershipRenewalStatus.cs`
        - Interfaces/
          - `IPatronRepository.cs`
          - `IPatronService.cs`
          - `ILoanRepository.cs`
          - `ILoanService.cs`
        - `Library.ApplicationCore.csproj`
        - Services/
          - `PatronService.cs`
          - `LoanService.cs`
      - Library.Console/
        - `appSettings.json`
        - `CommonActions.cs`
        - `ConsoleApp.cs`
        - `ConsoleState.cs`
        - `Library.Console.csproj`
        - `Program.cs`
      - Library.Infrastructure/
        - Data/
          - `JsonData.cs`
          - `JsonLoanRepository.cs`
          - `JsonPatronRepository.cs`
        - `Library.Infrastructure.csproj`
    - tests
      - UnitTests/
        - ApplicationCore/
          - LoanService/
            - `ReturnLoan.cs`
            - `ExtendLoan.cs`
          - PatronService/
            - `RenewMembership.cs`
        - `UnitTests.csproj`
    
    ## Key Classes and Interfaces
    - **Entities**
      - **Author**: Represents an author with properties like Id and Name.
      - **Book**: Represents a book with properties like Id, Title, AuthorId, Genre, ImageName, and ISBN.
      - **BookItem**: Represents a specific copy of a book with properties like Id, BookId, AcquisitionDate, and Condition.
      - **Loan**: Represents a loan with properties like Id, BookItemId, PatronId, LoanDate, DueDate, and ReturnDate.
      - **Patron**: Represents a library patron with properties like Id, Name, MembershipStart, MembershipEnd, and Loans.
    
    - **Enums**
      - **LoanExtensionStatus**: Enum for loan extension statuses.
      - **LoanReturnStatus**: Enum for loan return statuses.
      - **MembershipRenewalStatus**: Enum for membership renewal statuses.
    
    - **Interfaces**
      - **IPatronRepository**: Interface for patron repository with methods like GetPatron, SearchPatrons, and UpdatePatron.
      - **IPatronService**: Interface for patron service with method RenewMembership.
      - **ILoanRepository**: Interface for loan repository with methods like GetLoan and UpdateLoan.
      - **ILoanService**: Interface for loan service with methods like ReturnLoan and ExtendLoan.
    
    - **Services**
      - **PatronService**: Implements IPatronService to handle patron-related operations.
      - **LoanService**: Implements ILoanService to handle loan-related operations.
    
    - **Console**
      - **ConsoleApp**: Main console application class that handles user interactions and application flow.
      - **ConsoleState**: Enum for different states of the console application.
      - **CommonActions**: Enum for common actions in the console application.
    
    - **Infrastructure**
      - **JsonData**: Handles loading and saving data to JSON files.
      - **JsonLoanRepository**: Implements ILoanRepository to manage loan data.
      - **JsonPatronRepository**: Implements IPatronRepository to manage patron data.
    
    ## Usage
    1. Clone the repository.
    2. Open the solution file AccelerateDevGitHubCopilot.sln in Visual Studio.
    3. Build the solution to restore dependencies.
    4. Run the Library.Console project to start the console application.
    5. Follow the on-screen instructions to search for patrons, view patron details, extend loans, return books, and renew memberships.
    
    ## License
    This project is licensed under the MIT License.
    ```

#### Task 2: Commit and push the README file updates

Use the following steps to complete this section of the exercise:

1. Open Visual Studio Code's Source Control view.

1. To have GitHub Copilot generate a commit message, select the icon on the right side of the message box.

    You should see a commit message similar to the following message:

    ```plaintext
    Update README.md with project description, structure, key classes, usage instructions, and license information
    ```

1. Stage and Commit the file updates.

1. Sync (or Push) your updates to the GitHub repository.

#### Task 3: Check your work

To check your work, complete the following steps:

1. Open the GitHub repository for the AccelerateDevGitHubCopilot project.

1. Use the **Code** tab to review the updated README.md file.

    You may need to refresh the page in the browser to see the updated README file.

1. Ensure that the project structure described in the README file aligns the folder structure of the repository.

1. Review the commit history and locate the commit message generated by GitHub Copilot.

#### Exercise 4 summary

This exercise helped you create project documentation for the README file using GitHub Copilot. You used GitHub Copilot to generate the project description, project structure, key classes and interfaces, usage instructions, and license information. You also committed and pushed the README file updates to the GitHub repository.

## Part 2: Develop code features using GitHub Copilot tools

### Before you start

#### Project overview

You and your coworker meet to discuss your goals for the library application. You want to improve the user experience for the librarians and patrons. You discuss several new features that could be added to the application.

You agree to work on the following features:

- Book availability: Enable a librarian to determine the availability status of a book. This feature should display a message indicating if a book is available for loan or the return due date if the book is currently on loan to another patron.

- Book loans: Enable a librarian to loan a book to a patron (if the book is available). This feature should display the option for a patron to receive a book on loan, update Loans.json with the new loan, and display updated the loan details for the patron.

- Book reservations: Enable a librarian to reserve a book for a patron (unless the book is already reserved). This feature should implement a new book reservation process. This feature may require creating a new Reservations.json file along with the new classes and interfaces required to support the reservation process.

Each of you will work on one of the new features and then regroup. You'll work on the feature to determine the availability status of a book. Your coworker will work on the feature to loan a book to a patron. The final feature, to reserve a book for a patron, will be developed after the other two features are completed.

#### Lab scenario (part 2)

GitHub Copilot can help you develop new features for the library application.

In part 2 of this lab, you'll use GitHub Copilot to generate code suggestions that help you implement the new features more quickly and accurately.

Part 2 includes the following exercises:

- Develop a new "book availability" feature.
- Merge your changes into the main branch of the repository.

### Exercise 5: Develop a new "book availability" feature

The book availability feature should include the following code updates:

- Implement a new CommonActions.SearchBooks action that enables a librarian to select the option to search for a book.
- Create a new SearchBooks method in ConsoleApp.cs. The SearchBooks method should read a user provided book title. Check if a book is available for loan, and display a message stating either "book.title is available for loan" or "book.title is on loan to another patron. The return due date is loan.DueDate.

During this exercise, you'll complete the following tasks:

- Create a "book availability" branch in your code repository.
- Use GitHub Copilot suggestions to help implement a new SearchBooks common action that can be selected by a librarian.
- Use GitHub Copilot suggestions to help develop the SearchBooks method that reads a user provided book title, checks if a book is available for loan, and displays a message indicating the availability status of the book.

#### Task 1: Create a new branch in the repository

Before you start developing the new "book availability" feature, you need to create a new branch in the repository. This enables you to work on the new feature without affecting the main branch of the repository. You can merge the new feature into the main branch when it's ready.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the AccelerateDevGitHubCopilot solution open in Visual Studio Code.

1. Select the Source Control view and ensure that the local repository is synchronized with the remote repository (Pull or Sync).

1. In the bottom-left corner of the window, select **main**.

1. To create a new branch, type **book availability** and then select **+ Create new branch**.

1. To push the new branch to the remote repository, select **Publish Branch**.

#### Task 2: Implement a new "SearchBooks" common action

In this section of the exercise, you use GitHub Copilot to help you implement a menu option named SearchBooks. Librarians will choose the SearchBooks action to check the availability status of a book.

Here are the file updates that you complete during this task:

- Update the CommonActions enum in CommonActions.cs: Add a new SearchBooks action to the CommonActions enum.
- Update the WriteInputOptions method in ConsoleApp.cs: Add support for displaying the new CommonActions.SearchBooks option.
- Update the ReadInputOptions method in ConsoleApp.cs: Add support for reading (selecting) the new CommonActions.SearchBooks option.
- Update the PatronDetails method in ConsoleApp.cs: Add support for processing the new CommonActions.SearchBooks option when it's selected.

Use the following steps to complete this section of the exercise:

1. Open the SOLUTION EXPLORER view.

1. Open the CommonActions.cs file, and then select the **CommonActions** enum.

    You need to add a new SearchBooks action to CommonActions.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to include a new `SearchBooks` action.
    ```

    GitHub Copilot should suggest a code update that adds the new SearchBooks action to the CommonActions enum.

1. Review the suggested update and then select **Accept**.

    ```csharp

    public enum CommonActions
    {

        Repeat = 0,
        Select = 1,
        Quit = 2,
        SearchPatrons = 4,
        RenewPatronMembership = 8,
        ReturnLoanedBook = 16,
        ExtendLoanedBook = 32,
        SearchBooks = 64

    }

    ```

1. Open the ConsoleApp.cs file.

1. Find and then select the **WriteInputOptions** method.

    You need to add support for the new CommonActions.SearchBooks option. Display the option to check if a book is available for loan.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to include an option for the `CommonActions.SearchBooks` action. Use the letter "b" and the message "to check for book availability".
    ```

    GitHub Copilot should suggest a code update that adds a new "if" block for the SearchBooks action.

1. Review the suggested update and then select **Accept**.

    The suggested update should be similar to the following code snippet:

    ```csharp

    static void WriteInputOptions(CommonActions options)
    {

        Console.WriteLine("Input Options:");
        if (options.HasFlag(CommonActions.ReturnLoanedBook))
        {
            Console.WriteLine(" - \"r\" to mark as returned");
        }
        if (options.HasFlag(CommonActions.ExtendLoanedBook))
        {
            Console.WriteLine(" - \"e\" to extend the book loan");
        }
        if (options.HasFlag(CommonActions.RenewPatronMembership))
        {
            Console.WriteLine(" - \"m\" to extend patron's membership");
        }
        if (options.HasFlag(CommonActions.SearchPatrons))
        {
            Console.WriteLine(" - \"s\" for new search");
        }
        if (options.HasFlag(CommonActions.SearchBooks))
        {
            Console.WriteLine(" - \"b\" to check for book availability");
        }
        if (options.HasFlag(CommonActions.Quit))
        {
            Console.WriteLine(" - \"q\" to quit");
        }
        if (options.HasFlag(CommonActions.Select))
        {
            Console.WriteLine("Or type a number to select a list item.");
        }

    }

    ```

1. Scroll up slightly to find the **ReadInputOptions** method.

1. Select the **ReadInputOptions** method.

    You need to add support for the new CommonActions.SearchBooks option. Include a case that handles the user selecting the SearchBooks action.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to include an option for the `CommonActions.SearchBooks` action.
    ```

    GitHub Copilot should suggest a code update that adds a new "case" that handles the user selecting the SearchBooks action.

1. Review the suggested update and then select **Accept**.

    The suggested update should be similar to the following code snippet:

    ```csharp

    static CommonActions ReadInputOptions(CommonActions options, out int optionNumber)
    {

        CommonActions action;
        optionNumber = 0;
        do
        {
            Console.WriteLine();
            WriteInputOptions(options);
            string? userInput = Console.ReadLine();

            action = userInput switch
            {
                "q" when options.HasFlag(CommonActions.Quit) => CommonActions.Quit,
                "s" when options.HasFlag(CommonActions.SearchPatrons) => CommonActions.SearchPatrons,
                "m" when options.HasFlag(CommonActions.RenewPatronMembership) => CommonActions.RenewPatronMembership,
                "e" when options.HasFlag(CommonActions.ExtendLoanedBook) => CommonActions.ExtendLoanedBook,
                "r" when options.HasFlag(CommonActions.ReturnLoanedBook) => CommonActions.ReturnLoanedBook,
                "b" when options.HasFlag(CommonActions.SearchBooks) => CommonActions.SearchBooks,
                _ when int.TryParse(userInput, out optionNumber) => CommonActions.Select,
                _ => CommonActions.Repeat
            };

            if (action == CommonActions.Repeat)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        } while (action == CommonActions.Repeat);
        return action;

    }

    ```

1. Scroll down to find and then select the **PatronDetails** method.

    There are two things that you need to accomplish:

    - You need to add CommonActions.SearchBooks to options before calling ReadInputOptions.
    - You also need to add an else if to handle the SearchBooks action. The else if block should call a new method named SearchBooks.

    You can address both of these together.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to add `CommonActions.SearchBooks` to `options` before calling `ReadInputOptions`. Add an `else if` block to handle the `SearchBooks` action. The `else if` block should call a new method named `SearchBooks`.
    ```

    GitHub Copilot should suggest a code update that adds CommonActions.SearchBooks to options before calling ReadInputOptions.

1. Review the suggested update and then select **Accept**.

    ```csharp

    async Task<ConsoleState> PatronDetails()
    {

        Console.WriteLine($"Name: {selectedPatronDetails.Name}");
        Console.WriteLine($"Membership Expiration: {selectedPatronDetails.MembershipEnd}");
        Console.WriteLine();
        Console.WriteLine("Book Loans:");
        int loanNumber = 1;
        foreach (Loan loan in selectedPatronDetails.Loans)
        {
            Console.WriteLine($"{loanNumber}) {loan.BookItem!.Book!.Title} - Due: {loan.DueDate} - Returned: {(loan.ReturnDate != null).ToString()}");
            loanNumber++;
        }

        CommonActions options = CommonActions.SearchPatrons | CommonActions.Quit | CommonActions.Select | CommonActions.RenewPatronMembership | CommonActions.SearchBooks;
        CommonActions action = ReadInputOptions(options, out int selectedLoanNumber);
        if (action == CommonActions.Select)
        {
            if (selectedLoanNumber >= 1 && selectedLoanNumber <= selectedPatronDetails.Loans.Count())
            {
                var selectedLoan = selectedPatronDetails.Loans.ElementAt(selectedLoanNumber - 1);
                selectedLoanDetails = selectedPatronDetails.Loans.Where(l => l.Id == selectedLoan.Id).Single();
                return ConsoleState.LoanDetails;
            }
            else
            {
                Console.WriteLine("Invalid book loan number. Please try again.");
                return ConsoleState.PatronDetails;
            }
        }
        else if (action == CommonActions.Quit)
        {
            return ConsoleState.Quit;
        }
        else if (action == CommonActions.SearchPatrons)
        {
            return ConsoleState.PatronSearch;
        }
        else if (action == CommonActions.RenewPatronMembership)
        {
            var status = await _patronService.RenewMembership(selectedPatronDetails.Id);
            Console.WriteLine(EnumHelper.GetDescription(status));
            // reloading after renewing membership
            selectedPatronDetails = (await _patronRepository.GetPatron(selectedPatronDetails.Id))!;
            return ConsoleState.PatronDetails;
        }
        else if (action == CommonActions.SearchBooks)
        {
            return await SearchBooks();
        }

        throw new InvalidOperationException("An input option is not handled.");

    }

    ```

    > [!NOTE]
    > Inline chat suggestions may also create stub code for the SearchBooks method.

#### Task 3: Develop the SearchBooks method

The SearchBooks method should read a user provided book title, check if a book is available for loan, and display a message indicating the availability status of the book. The method should use the Books.json and Loans.json files to find the matching book title and determine the availability status of the book.

Use the following steps to complete this section of the exercise:

1. Take a minute to consider the process requirements for the SearchBooks method.

    What does the method need to do? What should it return? Does it require parameters?

    The SearchBooks method should implement the following process:

    1. Prompt the user for a book title.
    1. Read the user provided book title.
    1. Check if a book is available for loan
    1. Display a message stating one of the following options:

        - "book.title is available for loan"
        - "book.title is on loan to another patron. The return due date is loan.DueDate.

    To build the message options, your code will need to access the following JSON files:

    - Books.json is needed to find the matching Title and BookId.
    - Loans.json is needed to find the ReturnDate and DueDate for the matching BookItemId. The BookItemId is the same as the BookId in Books.json.

1. Ensure that you have the following **SearchBooks** method created in the ConsoleApp.cs file:

    ```csharp

    async Task<ConsoleState> SearchBooks()
    {

        return ConsoleState.PatronDetails;

    }

    ```

    > [!NOTE]
    > Be sure to remove any code comments created by GitHub Copilot. Unnecessary and inaccurate comments can negatively influence GitHub Copilot's suggestions.

1. Select the **SearchBooks** method.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to obtain a book title. Prompt the user to "Enter a book title to search for". Read the user input and ensure the book title isn't null.
    ```

    GitHub Copilot should suggest a code update that captures the user supplied book title.

1. Review the suggested update and then select **Accept**.

    ```csharp

    async Task<ConsoleState> SearchBooks()
    {

        string? bookTitle = null;
        while (String.IsNullOrWhiteSpace(bookTitle))
        {
            Console.Write("Enter a book title to search for: ");
            bookTitle = Console.ReadLine();
        }

        // Perform book search logic here

        return ConsoleState.PatronDetails;

    }

    ```

1. Select the **SearchBooks** method.

    > [!NOTE]
    > GitHub Copilot may create a separate method to handle user input of a book title. You can continue to develop the primary logic in the SearchBooks method.

1. Open the Chat view.

1. Add the following files to the Chat context: ConsoleApp.cs, JsonData.cs, JsonLoanRepository.cs, Books.json, Loans.json, BookItems.json, .

1. Enter the following prompt:

    ```plaintext
    @workspace  Explain how to update the `SearchBooks` method and ConsoleApps class to find a matching book title in the `Books.json` file. Use the user supplied book title to find a matching book. If a book is found, use Loans.json to check if the book is available for loan. If the book has been returned, display a message stating "`book.title` is available for loan". If the book is on loan, display a message stating "`book.title` is on loan to another patron. The return due date is `loan.DueDate`".
    ```

1. Take a minute to review the suggested updates.

    GitHub Copilot should propose updates similar to the following suggestions:

    To update the SearchBooks method and ConsoleApp class to find a matching book title in the Books.json file and check if the book is available for loan, follow these steps:

    a. Add a method to search for books by title in the JsonData class.
    b. Update the SearchBooks method in the ConsoleApp class to use this new method.
    c. Check the loan status of the book and display the appropriate message.

    Here is the updated code:

    Step 1: Add a method to search for books by title in the JsonData class

    ```csharp

    public class JsonData
    {

        // Existing code...
    
        public Book? SearchBookByTitle(string title)
        {
            return Books?.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

    }

    ```

    Step 2: Update the SearchBooks method in the ConsoleApp class

    ```csharp

    public class ConsoleApp
    {

        // Existing fields...
    
        JsonData _jsonData;
    
        public ConsoleApp(ILoanService loanService, IPatronService patronService, IPatronRepository patronRepository, ILoanRepository loanRepository, JsonData jsonData)
        {
            _patronRepository = patronRepository;
            _loanRepository = loanRepository;
            _loanService = loanService;
            _patronService = patronService;
            _jsonData = jsonData;
        }
    
        // Existing methods...
    
        async Task<ConsoleState> SearchBooks()
        {
            string bookTitle = ReadBookTitle();
    
            Book? book = _jsonData.SearchBookByTitle(bookTitle);
    
            if (book == null)
            {
                Console.WriteLine($"No book found with title: {bookTitle}");
                return ConsoleState.PatronDetails;
            }
    
            Loan? loan = _jsonData.Loans?.FirstOrDefault(l => l.BookItemId == book.Id && l.ReturnDate == null);
    
            if (loan == null)
            {
                Console.WriteLine($"{book.Title} is available for loan.");
            }
            else
            {
                Console.WriteLine($"{book.Title} is on loan to another patron. The return due date is {loan.DueDate}.");
            }
    
            return ConsoleState.PatronDetails;
        }
    
        // Existing methods...

    }

    ```

    Step 3: Update the Program.cs to pass JsonData to ConsoleApp

    ```csharp

    using Microsoft.Extensions.DependencyInjection;
    using Library.Infrastructure.Data;
    using Library.ApplicationCore;
    using Microsoft.Extensions.Configuration;
    
    var services = new ServiceCollection();
    
    var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json")
    .Build();
    
    services.AddSingleton<IConfiguration>(configuration);
    
    services.AddScoped<IPatronRepository, JsonPatronRepository>();
    services.AddScoped<ILoanRepository, JsonLoanRepository>();
    services.AddScoped<ILoanService, LoanService>();
    services.AddScoped<IPatronService, PatronService>();
    
    services.AddSingleton<JsonData>();
    services.AddSingleton<ConsoleApp>();
    
    var servicesProvider = services.BuildServiceProvider();
    
    var consoleApp = servicesProvider.GetRequiredService<ConsoleApp>();
    consoleApp.Run().Wait();

    ```

    With these changes, the SearchBooks method in the ConsoleApp class will now search for a book by title in the Books.json file and check its loan status in the Loans.json file. If the book is available for loan, it will display a message stating that the book is available. If the book is on loan, it will display a message stating that the book is on loan and provide the return due date.

1. Add the suggested SearchBookByTitle method to the end of the **JsonData** class.

    ```csharp

    public Book? SearchBookByTitle(string title)
    {
        return Books?.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    ```

    > [!NOTE]
    > GitHub Copilot may suggest using LINQ queries in the SearchBooks method to determine loan status, or it could suggest adding more methods to the `JsonData` class. The instructions that follow are based on GitHub Copilot suggestions that use LINQ queries in the SearchBooks method.

1. Update the **Program.cs** file using the suggested updates.

    ```csharp

    using Microsoft.Extensions.DependencyInjection;
    using Library.Infrastructure.Data;
    using Library.ApplicationCore;
    using Microsoft.Extensions.Configuration;
    
    var services = new ServiceCollection();
    
    var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json")
    .Build();
    
    services.AddSingleton<IConfiguration>(configuration);
    
    services.AddScoped<IPatronRepository, JsonPatronRepository>();
    services.AddScoped<ILoanRepository, JsonLoanRepository>();
    services.AddScoped<ILoanService, LoanService>();
    services.AddScoped<IPatronService, PatronService>();
    
    services.AddSingleton<JsonData>();
    services.AddSingleton<ConsoleApp>();
    
    var servicesProvider = services.BuildServiceProvider();
    
    var consoleApp = servicesProvider.GetRequiredService<ConsoleApp>();
    consoleApp.Run().Wait();

    ```

1. Add the _jsonData field declaration to the ConsoleApp class before the class constructor.

    ```csharp

    JsonData _jsonData;

    ```

1. Add a JsonData jsonData parameter to the ConsoleApp class constructor and use it to initialize the _jsonData field inside the constructor.

    The updated class constructor should look like the following code snippet:

    ```csharp

    public ConsoleApp(ILoanService loanService, IPatronService patronService, IPatronRepository patronRepository, ILoanRepository loanRepository, JsonData jsonData)
    {

        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
        _loanService = loanService;
        _patronService = patronService;
        _jsonData = jsonData;

    }

    ```

1. Notice that JsonData isn't recognized in the ConsoleApp class.

    You need to add "using Library.Infrastructure.Data;" to the top of the ConsoleApp.cs file.

1. Ensure that the following "using" statement is added to the top of the ConsoleApp.cs file.

    ```csharp

    using Library.Infrastructure.Data;

    ```

1. Use the code suggestions to update the **SearchBooks** method:

    The suggested code should use the SearchBookByTitle method (or a LINQ query) to search for the book by title. If the book is found, a LINQ query is used to determine if the book is on loan. The code also includes logic to display the availability status of the book based on the search results. The logic used to display response messages can be implemented in several ways. An example is provided in the code snippet below.

    The following code snippet shows one possible implementation of the SearchBooks method:

    ```csharp

    async Task<ConsoleState> SearchBooks()
    {

        string bookTitle = ReadBookTitle();

        Book? book = _jsonData.SearchBookByTitle(bookTitle);

        if (book == null)
        {
            Console.WriteLine($"No book found with title: {bookTitle}");
            return ConsoleState.PatronDetails;
        }

        Loan? loan = _jsonData.Loans?.FirstOrDefault(l => l.BookItemId == book.Id && l.ReturnDate == null);

        if (loan == null)
        {
            Console.WriteLine($"{book.Title} is available for loan.");
        }
        else
        {
            Console.WriteLine($"{book.Title} is on loan to another patron. The return due date is {loan.DueDate}.");
        }

        return ConsoleState.PatronDetails;

    }

    ```

1. Select the **SearchBooks** method.

1. Open the Chat view, and then enter the following prompt:

    ```plaintext
    Explain the LINQ queries and the evaluation of the book's availability status.
    ```

1. Take a minute to review the explanation provided by GitHub Copilot.

    For the query that checks whether the book is on loan, you should see a description that's similar to the following explanation:

    ```markdown
    **Search for the Loan Status of the Book**
    ```

    ```csharp

    Loan? loan = _jsonData.Loans?.FirstOrDefault(l => l.BookItemId == book.Id && l.ReturnDate == null);

    ```

    ```markdown
    - _jsonData.Loans: Accesses the list of loans from the JsonData class.

    - ?.: The null-conditional operator ensures that if _jsonData.Loans is null, the entire expression will return null without throwing a NullReferenceException.

    - FirstOrDefault: A LINQ method that returns the first element in the collection that matches the specified condition, or null if no such element is found.

    - Lambda Expression: l => l.BookItemId == book.Id && l.ReturnDate == null

        - l.BookItemId == book.Id: Checks if the BookItemId of the loan matches the Id of the book being searched.

        - l.ReturnDate == null: Checks if the loan's ReturnDate is null, indicating that the book is currently on loan and has not been returned.

    - Result: If a matching loan is found, it is assigned to the loan variable. If no matching loan is found, loan is null.

    **Evaluation of the Book's Availability Status**

    After executing the LINQ queries, the method evaluates the availability status of the book:

      - If loan is null, the book has been returned. The method prints that the book is available for loan.
      - If loan is not null, the book is currently on loan (no return date). The method prints that the book is on loan and provides the date when the book should be returned.

    ```

1. Verify the logic implemented by the **Check if the Book is on Loan** query.

    Null-Conditional Operator: The "?." operator is a null-conditional operator. It ensures that if _jsonData.Loans is null, the entire expression will evaluate to null without throwing a NullReferenceException.

    Lambda Expression: The lambda expression "l => l.BookItemId == book.Id && l.ReturnDate == null" defines the condition for the FirstOrDefault method. It checks each loan object "l" to see if its BookItemId matches the Id of the book object and if its ReturnDate is null.

    This code attempts to find the first loan in the _jsonData.Loans collection where the BookItemId matches the Id of the given book and the ReturnDate is null. If no such loan is found or if "_jsonData.Loans" is null, loan will be set to null.

    > [!NOTE]
    > Most modern libraries have multiple copies of the same book. This code assumes that there is only one copy of each book. If the library has multiple copies of the same book, the code will need to be updated to handle multiple loans for the same book. For the purposes of this training, we are assuming that there is only one copy of each book and that the logic provided is sufficient.

1. Build the solution to ensure that there are no errors.

    You'll see Warning messages, but there shouldn't be any errors.

    To build the solution in the Solution Explorer view, right-click **AccelerateDevGitHubCopilot** and then select **Build**.

#### Exercise 5 summary

You used GitHub Copilot to help you implement a new feature for the library application. You created a new branch in the repository and then used GitHub Copilot to generate code suggestions that helped you implement the new feature more quickly and accurately. You added a new SearchBooks action to CommonActions, updated the WriteInputOptions and ReadInputOptions methods in ConsoleApp.cs, and created a new SearchBooks method to determine the availability status of a book.

### Exercise 6: Merge your changes into the main branch of the repository

You created a new feature that enables a librarian to determine the availability status of a book. Now you need verify that the feature works as expected and merge your changes into the main branch of the repository.

During this exercise, you'll complete the following tasks:

- Verify that your new feature works as expected
- Sync your changes with the remote repository
- Create a pull request to merge your changes into the main branch of the repository

#### Task 1: Verify that your new feature works as expected

Since you don't have automated tests, manual testing can be used to verify that the new feature works as expected. Using a data source that can be verified is important. In this case, you use the Books.json and Loans.json files to verify that the new feature reports the availability status of a book correctly.

Use the following steps to complete this section of the exercise:

1. Open the Solution Explorer view.

1. To run the application, right-click **Library.Console**, select **Debug**, and then select **Start New Instance**.

1. When prompted for a patron name, type **One** and then press Enter.

    You should see a list of patrons that match the search query.

1. At the "Input Options" prompt, type **2** and then press Enter.

    Entering **2** selects the second patron in the list.

    You should see the patron's name and membership status followed by book loan details.

1. At the "Input Options" prompt, type **b** and then press Enter.

    Entering **b** selects the option to search for a book's availability status.

    You should see a prompt to enter a book title.

1. Type **Book One** and then press Enter.

    In the original data that you downloaded, **Book One** is currently on loan to **Patron Forty-Nine**, so it shouldn't be available.

1. Verify that the application displays a message indicating that the book is on loan to another patron.

    You may need to scroll up to see the message.

1. Verify that **Book Nine** has been returned by **Patron One**.

    In the previous exercise, during a test of the Library application, you had **Patron One** return **Book Nine**. If the application shows that **Book Nine** hasn't been returned by **Patron One**, use the input options to select and return **Book Nine** before continuing.

    > [!NOTE]
    > The Library.Console.csproj file ensures that the JSON data files are copied to the output directory when the application is built. However, performing Clean or Rebuild operations will essentially reset the data. Repeated Build operations do not reset the data in the output directory ("/bin/Debug/net8.0/").

1. At the "Input Options" prompt, type **b** and then press Enter.

1. Type **Book Nine** and then press Enter.

1. Verify that the application displays a message indicating that the book is available for loan.

1. At the "Input Options" prompt, type **q** and then press Enter.

1. Stop the debug session.

1. Open the **Loans.json** file.

    The Loans.json file is used to track the loan status of each book. You can use the Loans.json file to verify that the availability status of Book One and Book Nine is correct.

    The updated Loans.json file should be located in either the "Library.Console\bin\Debug\net8.0\Json" folder or "Library.Console\Json" folder.

    - If you're using the Visual Studio Code debugger to run the app, the updated Loans.json file should be located in the "Library.Console\bin\Debug\net8.0\Json" folder.

    - If you're using a "dotnet run" command from the "AccelerateDevGitHubCopilot\src\Library.Console" folder to run the app, the updated Loans.json file should be located in the "Library.Console\Json" folder.

1. Verify that loan ID 37 and loan ID 46 are both for Book One ("BookItemId": 1).

    - Loan ID 37 should have a ReturnDate value (2024-01-17)
    - Loan ID 46 shouldn't have a ReturnDate value. The ReturnDate value should be null.

    The ReturnDate value is used to determine whether the book is currently on loan. If the ReturnDate value is null, the book is considered to be on loan.

1. Verify that loan ID 22 is for Book Nine ("BookItemId": 9) and that the ReturnDate value is set to today's date.

    If you're running in the debugger and you cleaned the solution after making changes to the Loans.json file, those changes are lost. After you clean the solution, the Loans.json file is reset to the original data the next time you run the application. You can manually update the Loans.json file to test the availability status of Book One and Book Nine.

#### Task 2: Sync your changes with the remote repository

You can use the Source Control view in Visual Studio Code to commit your changes to the local repository. After you commit your changes, you can sync them with the remote repository.

Use the following steps to complete this section of the exercise:

1. Select the Source Control view.

1. Ensure that the CommonActions.cs, ConsoleApp.cs, and JsonData.cs files listed under **Changes**.

    If GitHub Copilot used LINQ queries to determine the availability status of a book directly within the SearchBooks method, you may not see JsonData.cs listed under **Changes**.

1. Use GitHub Copilot to generate a message for the **Commit**.

1. To stage and commit your changes, select **Commit** and then select **Yes**.

1. Sync (or Push) changes to the remote repository.

#### Task 3: Create a pull request to merge your changes into the main branch of the repository

You can use a pull request to suggest changes to the main branch of the repository. After you create a pull request, you can review the changes, verify that the checks pass, and then merge the changes into the main branch. GitHub Copilot can help you generate a summary of the pull request to help reviewers understand your changes.

Use the following steps to complete this section of the exercise:

1. Open your GitHub repository in a web browser.

1. Open the **Pull requests** tab.

1. Select **New pull request**.

1. Under **Compare changes**, ensure that **base** is configured for the **main** branch.

1. Ensure that **compare** is configured for the **book-availability** branch.

    After you configure the branches, a comparison of the changes between **main** and **book-availability** is displayed. You should see the changes you made to the CommonActions.cs, ConsoleApp.cs, and JsonDaa.cs files.

1. Select **Create pull request**.

1. Enter a title for the pull request.

    Members of an enterprise with a subscription to GitHub Copilot Enterprise, can use GitHub Copilot to generate a summary description for a pull request. The detailed summary helps reviewers understand your changes.

1. Use GitHub Copilot to generate a summary of a pull request.

    To generate the summary, select the Copilot actions button, and then select **Summary**.

    You can use the Preview tab to review the pull request summary generated by GitHub Copilot.

1. Ensure that the title and description reflect your code updates, and then select **Create pull request**.

1. Wait for the checks to complete, and then verify that all checks passed and that there are no conflicts with the base branch.

    It can take a minute for the checks to complete. You need to address any issues that are identified before you can merge the changes into the main branch.

1. To merge your changes into the main branch, select **Merge pull request**, and then select **Confirm merge**.

    Notice that you can delete the book-availability branch after merging the changes.

1. Open Visual Studio Code.

1. Switch to the **main** branch of the repository.

1. **Pull** the changes from the remote repository.

1. Verify that the changes you made in the **book-availability** branch are now in the **main** branch.

    The changes you made to the CommonActions.cs and ConsoleApp.cs files should be present in the main branch.

#### Exercise 6 summary

In this exercise, you tested you code and then merged your changes into the main branch of the repository. You committed your changes to the local repository, synced them with the remote repository, and then created a pull request to merge your changes into the main branch of the repository. You used GitHub Copilot to generate a summary of the pull request to help reviewers understand your changes.

## Part 3: Develop unit tests using GitHub Copilot tools

### Before you start

#### Project overview

Your colleague created a test project named UnitTests. The existing unit tests partially cover the service classes in the Library.ApplicationCore project. The Library.ApplicationCore project contains the business logic for a library management system. The UnitTests project uses the xUnit framework to write and run unit tests. The project also uses the NSubstitute library to create mock objects for testing.

You need to extend the UnitTests project to cover the data access classes in the Library.Infrastructure project.

#### Lab scenario (part 3)

GitHub Copilot can help you write unit tests for your code. There are several ways to use GitHub Copilot to generate unit tests:

- **Generate test cases**: You can use GitHub Copilot to generate test cases for your code. Copilot can suggest test cases based on the code you have written. You can then use these test cases to create unit tests for your code.
- **Generate test methods**: Copilot can also generate test methods for your code. You can use these test methods to create unit tests for your code.
- **Generate test assertions**: Copilot can suggest assertions that you can use in your unit tests. These assertions can help you verify the behavior of your code.
- **Generate test mocks**: Copilot can generate mock objects that you can use in your unit tests. These mock objects can help you isolate the code you're testing from its dependencies.
- **Generate test data**: Copilot can generate test data that you can use in your unit tests. This test data can help you test your code with different inputs.
- **Generate test setup code**: Copilot can generate setup code for your unit tests. This code can help you set up the test environment before running your tests.
- **Generate test teardown code**: Copilot can generate teardown code for your unit tests. This code can help you clean up the test environment after running your tests.

In part 3 of this lab, you develop unit tests for the Library.Infrastructure project.

Part includes the following exercise:

- Use GitHub Copilot to evaluate and extend the UnitTests project.

### Exercise 7: Use GitHub Copilot to evaluate and extend the UnitTests project

In this exercise, you use GitHub Copilot to complete the following tasks:

1. Use GitHub Copilot to evaluate the existing UnitTests project.

1. Extend the UnitTests project to begin testing data access classes.

#### Task 1: Use GitHub Copilot to evaluate the existing UnitTests project

The UnitTests project currently implements the following folder structure:

- UnitTests\
  - ApplicationCore\
    - LoanService\
      - ExtendLoan.cs
      - ReturnLoan.cs
    - PatronService\
      - RenewMembership.cs
  - LoanFactory.cs
  - PatronFactory.cs

This structure mirrors and supports the Services portion of the ApplicationCore project.

- ApplicationCore\
  - Services\
    - LoanService.cs: Contains the ExtendLoan and ReturnLoan methods.
    - PatronService.cs: Contains the RenewMembership method.

Evaluating the existing unit tests will help you to develop unit tests for the data access classes in the Library.Infrastructure project.

Use the following steps to complete this section of the exercise:

1. Open the Chat view.

1. Add the following files to the Chat context: **LoanFactory.cs**, **PatronFactory.cs**, **ExtendLoan.cs**, **ReturnLoan.cs**, **RenewMembership.cs**, **LoanService.cs**, **PatronService.cs**.

    The files are located in the "tests/UnitTests", "tests/UnitTests/ApplicationCore/LoanService", "tests/UnitTests/ApplicationCore/PatronService", and "src/Library.ApplicationCore/Services" folders.

1. Enter the following prompt:

    ```plaintext
    @workspace Explain the approach to unit testing that's been implemented in this workspace.
    ```

    This prompt asks GitHub Copilot to explain the approach to unit testing in the context of the workspace. Several files are included in the prompt to provide context for the response.

1. Take a minute to review the response from GitHub Copilot.

    You should see an explanation that's similar to the following description:

    - Mocking dependencies: The tests use NSubstitute to create mock implementations of interfaces.
    - Test organization: Tests are organized into separate files based on the methods being tested. For example, ExtendLoan and ReturnLoan methods are tested in separate files under the LoanService folder.
    - Assertions: Assertions are used to verify the expected outcome of each test.
    - Test scenarios: The tests cover various scenarios for each method, such as returning different statuses based on the input.
    - Isolation: Each test is isolated from others to prevent side effects.
    - Factory methods: Factory methods are used to create test data consistently.

1. Enter the following prompt:

    ```plaintext
    @workspace What are the benefits of this approach to unit testing?
    ```

1. Take a minute to review the response from GitHub Copilot.

    You should see an explanation that identifies a list of benefits that's similar to the following list:

    - Isolation of Dependencies: Using mocks isolates the unit of work from its dependencies.
    - Repeatability and Consistency: Factory methods provide a consistent way to create test data.
    - Readability and Maintainability: Descriptive test methods and clear arrangement of test steps improve the readability of tests.
    - Comprehensive Coverage: Testing various scenarios ensures that the code is robust and handles different edge cases.
    - Separation of Concerns: The separation of test data creation from the test logic itself keeps the tests clean and focused on the behavior being tested.
    - Immediate Feedback: Running unit tests provides immediate feedback on the correctness of the code.

1. Add the following files to the Chat context: **ExtendLoan.cs**, **ReturnLoan.cs**, **RenewMembership.cs**, **LoanFactory.cs**, **PatronFactory.cs**, **LoanService.cs**, **PatronService.cs**.

1. Enter the following prompt:

    ```plaintext
    @workspace How can I extend the `UnitTests` project to begin testing methods in the `Library.Infrastructure` project? Provide a process overview.
    ```

    This prompt asks GitHub Copilot to provide a process overview for extending the UnitTests project to begin testing methods in the Library.Infrastructure project. Several files are included in the prompt to provide context for the response.

1. Take a minute to review the response from GitHub Copilot.

    You should see an explanation that's similar to the following description:

    ```markdown
    1. Add Project Reference:

      - Open the UnitTests.csproj file located at tests/UnitTests/UnitTests.csproj.
      - Add a reference to the Library.Infrastructure project.

    2. Identify methods to test:

      - Identify the methods in the Library.Infrastructure project that need to be tested. For example, if you want to test the LoanService class, identify the methods in the LoanService class that need to be tested.

    3. Create Test Classes:

      - Create new test classes in the tests/UnitTests directory to test the methods in the Library.Infrastructure project. For example, if you want to test LoanService, create a file named LoanServiceTests.cs.

    4. Write Unit Tests:

      - In the newly created test classes, write unit tests for the methods in the Library.Infrastructure project. Use the xUnit framework for writing tests and NSubstitute for mocking dependencies.

    5. Run Tests:

      - Use Visual Studio Code's integrated terminal or the Test Explorer to run the tests.
      - Ensure that the tests are discovered and executed correctly.
    ```

#### Task 2: Extend the UnitTests project to begin testing data access classes

In this section of the exercise, you use GitHub Copilot to help you create unit tests for the Library.Infrastructure project.

The Library.Infrastructure project contains data access classes that interact with the file system to load and save data. The project includes the following classes:

- JsonData: A class that loads and saves JSON data.
- JsonLoanRepository: A class that implements the ILoanRepository interface and uses the JsonData class to load and save loan data.
- JsonPatronRepository: A class that implements the IPatronRepository interface and uses the JsonData class to load and save patron data.

You'll start by writing unit tests for the JsonLoanRepository class.

Use the following steps to complete this section of the exercise:

1. Add the following project file to the Chat context: **UnitTests.csproj**.

1. Enter the following prompt in the Chat view:

    ```plaintext
    @workspace Explain how to add a reference to the Library.Infrastructure project inside `UnitTests.csproj`.
    ```

    This prompt asks GitHub Copilot to explain how to add a reference to the Library.Infrastructure project inside the UnitTests.csproj file.

1. Use the GitHub Copilot response to update the UnitTests.csproj file.

    The updated UnitTests.csproj file should look similar to the following XML code:

    ```xml

    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
        <IsPackable>false</IsPackable>
        <IsTestProject>true</IsTestProject>
      </PropertyGroup>
      <ItemGroup>
        <PackageReference Include="coverlet.collector" Version="6.0.0" />
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
        <PackageReference Include="NSubstitute" Version="5.1.0" />
        <PackageReference Include="xunit" Version="2.5.3" />
        <PackageReference Include="xunit.runner.visualstudio" Version="2.5.3" />
      </ItemGroup>
      <ItemGroup>
        <Using Include="Xunit" />
      </ItemGroup>
      <ItemGroup>
        <ProjectReference Include="..\..\src\Library.ApplicationCore\Library.ApplicationCore.csproj" />
        <ProjectReference Include="..\..\src\Library.Infrastructure\Library.Infrastructure.csproj" />
      </ItemGroup>
    </Project>

    ```

1. Open the **JsonLoanRepository.cs** file.

    JsonLoanRepository.cs is located in the "src/Library.Infrastructure/Data/" folder.

1. Take a minute to review the **JsonLoanRepository.cs** file.

    ```csharp

    using Library.ApplicationCore;
    using Library.ApplicationCore.Entities;
    
    namespace Library.Infrastructure.Data;
    
    public class JsonLoanRepository : ILoanRepository
    {

        private readonly JsonData _jsonData;
    
        public JsonLoanRepository(JsonData jsonData)
        {
            _jsonData = jsonData;
        }
    
        public async Task<Loan?> GetLoan(int id)
        {
            await _jsonData.EnsureDataLoaded();
    
            foreach (Loan loan in _jsonData.Loans!)
            {
                if (loan.Id == id)
                {
                    Loan populated = _jsonData.GetPopulatedLoan(loan);
                    return populated;
                }
            }
            return null;
        }
    
        public async Task UpdateLoan(Loan loan)
        {
            Loan? existingLoan = null;
            foreach (Loan l in _jsonData.Loans!)
            {
                if (l.Id == loan.Id)
                {
                    existingLoan = l;
                    break;
                }
            }
    
            if (existingLoan != null)
            {
                existingLoan.BookItemId = loan.BookItemId;
                existingLoan.PatronId = loan.PatronId;
                existingLoan.LoanDate = loan.LoanDate;
                existingLoan.DueDate = loan.DueDate;
                existingLoan.ReturnDate = loan.ReturnDate;
    
                await _jsonData.SaveLoans(_jsonData.Loans!);
    
                await _jsonData.LoadData();
            }
        }

    }

    ```

1. Notice the following details about the **JsonLoanRepository** class:

    - The JsonLoanRepository class contains two methods: GetLoan and UpdateLoan.
    - The JsonLoanRepository class uses a JsonData object to load and save loan data.

    You'll start by writing unit tests for the GetLoan method.

1. Create the following folder structure under the **UnitTests** project.

    - Infrastructure\
        - JsonLoanRepository\

    This folder structure mirrors the approach used for the Library.ApplicationCore unit tests.

1. Create a class file named **GetLoan** in the JsonLoanRepository folder.

1. Take a minute to consider the field and class constructor requirements for the GetLoan unit tests.

    The JsonLoanRepository.GetLoan method receives a loan ID parameter when it's called. The method uses "_jsonData.EnsureDataLoaded" to get the latest JSON data, and "_jsonData.Loans" to search for a matching loan. If the method finds a matching loan ID, it returns a populated loan object (populated). If the method is unable to find a matching loan ID, it returns null.

    For the GetLoan unit tests:

    - You can use a mock loan repository object ("_mockLoanRepository") to help test the case where a matching ID is found. Load the mock with the ID you want to find. The ReturnLoanTest class demonstrates how to mock the ILoanRepository interface and instantiate a mock loan repository object.

    - You can use a non-mock loan repository object ("_jsonLoanRepository") to test the case where no matching ID is found. Just specify a loan ID that you know isn't in the file (anything over 100 should work).

    - You'll need a JsonData object to create a non-mock JsonLoanRepository object. Since the UnitTests project doesn't have access to the JsonData object created by the ConsoleApp project, you'll need to create one using the IConfiguration interface.

1. Add the following files to the Chat context: **JsonLoanRepository.cs**, **ReturnLoan.cs**, **LoanService.cs**, **LoanFactory.cs**, **JsonData.cs**.

1. Enter the following prompt:

    ```plaintext
    @workspace Create fields and a class constructor for the `GetLoan.cs` file. The class will be used to create unit tests for the GetLoan method in the `JsonLoanRepository.cs` file. Create the following private readonly fields: `_mockLoanRepository`, `_jsonLoanRepository`, `_configuration`, and `_jsonData`. Instantiate the fields in the `GetLoanTest` constructor. Use `ConfigurationBuilder` to create a `_configuration` object that can be used to instantiate the JsonData object.
    ```

    This prompt asks GitHub Copilot to suggest fields and a class constructor.

1. Take a minute to review the response from GitHub Copilot.

    You should see a code suggestion that's similar to the following code snippet:

    ```csharp

    using NSubstitute;
    using Library.ApplicationCore;
    using Library.ApplicationCore.Entities;
    using Library.ApplicationCore.Interfaces;
    using Library.Infrastructure.Data;
    using Microsoft.Extensions.Configuration;
    
    namespace UnitTests.Infrastructure.JsonLoanRepository;
    
    public class GetLoanTest
    {

        private readonly ILoanRepository _mockLoanRepository;
        private readonly JsonLoanRepository _jsonLoanRepository;
        private readonly IConfiguration _configuration;
        private readonly JsonData _jsonData;
    
        public GetLoanTest()
        {
            _mockLoanRepository = Substitute.For<ILoanRepository>();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _jsonData = new JsonData(_configuration);
            _jsonLoanRepository = new JsonLoanRepository(_jsonData);
        }
    
        // Add test methods here

    }

    ```

1. Use the code suggestion provided by GitHub Copilot to update **GetLoan.cs**.

1. Notice the following issues:

    - There is a conflict between the namespace and the use of JsonLoanRepository in the code. You should update the namespace in GetLoans.cs to follow the pattern used in the ReturnLoan.cs and RenewMembership.cs files.

    - If ILoanRepository isn't recognized in your code, you may need to add a using directive for Library.ApplicationCore to the top of the file.

    - If the _configuration object isn't instantiated correctly, you may need to update the code line containing ConfigurationBuilder. You can simplify the code to use "_configuration = new ConfigurationBuilder().Build();".

    - If a "using Library.ApplicationCore.Interfaces" is suggested by GitHub Copilot, you can delete it from the top of the file.

1. Update the **GetLoan.cs** file to match the following code snippet:

    ```csharp

    using NSubstitute;
    using Library.ApplicationCore;
    using Library.ApplicationCore.Entities;
    using Library.Infrastructure.Data;
    using Microsoft.Extensions.Configuration;

    namespace UnitTests.Infrastructure.JsonLoanRepositoryTests;

    public class GetLoanTest
    {

        private readonly ILoanRepository _mockLoanRepository;
        private readonly JsonLoanRepository _jsonLoanRepository;
        private readonly IConfiguration _configuration;
        private readonly JsonData _jsonData;

        public GetLoanTest()
        {
            _mockLoanRepository = Substitute.For<ILoanRepository>();
            _configuration = new ConfigurationBuilder().Build();
            _jsonData = new JsonData(_configuration);
            _jsonLoanRepository = new JsonLoanRepository(_jsonData);
        }

    }

    ```

1. Add the following files to the Chat context: **JsonLoanRepository.cs**, **ReturnLoan.cs**, **LoanService.cs**, **LoanFactory.cs**, **JsonData.cs**, **Loans.json**.

1. Select the contents of the GetLoan.cs file, and then enter the following prompt in the Chat view:

    ```plaintext
    @workspace Update the selection to include a unit test for the `JsonLoanRepository.GetLoan` method. The unit test should test the case where a loan ID is found in the data. Use `_mockLoanRepository` to arrange the expected return loan. Use `_jsonLoanRepository` to return an actual loan. Asserts should verify that the return loan ID matches the expected loan ID. Use a loan ID that exists in the `Loans.json` file.
    ```

    This prompt asks GitHub Copilot to suggest a unit test for the JsonLoanRepository.GetLoan method. The unit test should test the case where a loan ID is found in the data. The test should use "_mockLoanRepository" to arrange the expected return loan, "_jsonLoanRepository" to return an actual loan, and asserts to verify that the return loan ID matches the expected loan ID. The loan ID should exist in the Loans.json file.

1. Take a minute to review the response from GitHub Copilot.

    You should see a code suggestion that's similar to the following code snippet:

    ```csharp

    using NSubstitute;
    using Library.ApplicationCore;
    using Library.ApplicationCore.Entities;
    using Library.Infrastructure.Data;
    using Microsoft.Extensions.Configuration;
    using Xunit;

    namespace UnitTests.Infrastructure.JsonLoanRepositoryTests;

    public class GetLoanTest
    {

        private readonly ILoanRepository _mockLoanRepository;
        private readonly JsonLoanRepository _jsonLoanRepository;
        private readonly IConfiguration _configuration;
        private readonly JsonData _jsonData;

        public GetLoanTest()
        {
            _mockLoanRepository = Substitute.For<ILoanRepository>();
            _configuration = new ConfigurationBuilder().Build();
            _jsonData = new JsonData(_configuration);
            _jsonLoanRepository = new JsonLoanRepository(_jsonData);
        }

        [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when loan ID is found")]
        public async Task GetLoan_ReturnsLoanWhenLoanIdIsFound()
        {
            // Arrange
            var loanId = 1; // Use a loan ID that exists in the Loans.json file
            var expectedLoan = new Loan { Id = loanId, BookItemId = 101, PatronId = 202, LoanDate = DateTime.Now, DueDate = DateTime.Now.AddDays(14) };
            _mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);
            await _jsonData.EnsureDataLoaded(); // Ensure data is loaded

            // Act
            var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

            // Assert
            Assert.NotNull(actualLoan);
            Assert.Equal(expectedLoan.Id, actualLoan?.Id);
        }
    }

    ```

1. Use the code suggestion provided by GitHub Copilot to update **GetLoan.cs**.

    The JsonLoanRepository.GetLoan method calls "_jsonData.EnsureDataLoaded" to ensure that the JSON data is loaded. You can delete the code line that calls "_jsonData.EnsureDataLoaded" in the test method if it's included.

    If the Loan class isn't recognized in your code, ensure that you have a "using Library.ApplicationCore.Entities" statement at the top of the GetLoan.cs file. The Loan class is located in the Library.ApplicationCore.Entities namespace.

1. Build the AccelerateDevGitHubCopilot solution to ensure there are no errors.

1. Use GitHub Copilot's autocompletion feature to create a test for the case where the loan ID isn't found.

    Create a blank line after the GetLoan_ReturnsLoanWhenLoanIdIsFound method.

    Accept the autocompletion suggestions to create a new test method.

1. Take a minute to review the response from GitHub Copilot.

    GitHub Copilot's autocompletion feature will probably mock an expected loan even though it isn't needed. You can delete the code that mocks an expected loan, but you need a loan ID that doesn't exist in the Loans.json file.

    You should see a code suggestion that's similar to one of the following code snippets:

    ```csharp

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when loan ID is not found")]
    public async Task GetLoan_ReturnsNullWhenLoanIdIsNotFound()
    {

        // Arrange
        var loanId = 999; // Use a loan ID that does not exist in the Loans.json file
        var expectedLoan = new Loan { Id = loanId, BookItemId = 101, PatronId = 202, LoanDate = DateTime.Now, DueDate = DateTime.Now.AddDays(14) };
        _mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.Null(actualLoan);

    }

    ```

1. Accept the autocompletion suggestion that assigns a loanId value that isn't in the data set.

    If none of the suggestions assign loanId numbers that aren't in the data set, you can use the **Ctrl+Enter** keyboard shortcut to list additional suggestions.

1. Notice that the unit tests require access to the JSON data files.

    The JsonLoanRepository.GetLoan method uses a JsonData object to load and save loan data.

    The JSON data files are located in the "Library.Console\Json" folder. You need to update the UnitTests.csproj file to include these files in the test project.

1. Add the following XML snippet to the **UnitTests.csproj** file:

    ```xml

    <ItemGroup>
        <None Include="..\..\src\Library.Console\Json\**\*">
            <Link>Json\%(RecursiveDir)%(FileName)%(Extension)</Link>
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
    </ItemGroup>

    ```

    This ensures that the JSON data files are copied to the output directory when the tests are run.

#### Task 3: Check your work

There are several ways to run the unit tests for the JsonLoanRepository class. You can use Visual Studio Code's Test Explorer, the integrated terminal, or the "dotnet test" command.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the GetLoans.cs file open in editor.

1. Build the solution and ensure that there are no errors.

    Right-click **AccelerateDevGitHubCopilot** and then select **Build**.

1. Notice the "green play button" to the left of the test methods.

1. Open Visual Studio Code's Test Explorer view.

    To open the Test Explorer view, select the beaker-shaped icon on the left-side Activity bar. The Test Explorer is labeled "Testing" in the user interface.

    The Test Explorer is a tree view that shows all the test cases in your workspace. You can run/debug your test cases and view the test results using Test Explorer.

1. Expand **UnitTests** and the underlying nodes to locate **GetLoanTest**.

1. Run the **JsonLoanRepository.GetLoan: Returns loan when loan ID is found** test case.

1. Notice the test results in the Test Explorer view and the Editor.

    You should see a green checkmark that indicates the test passed.

1. Use the Editor to run the **JsonLoanRepository.GetLoan: Returns null when loan ID is not found** test case.

1. Notice the test results in the Test Explorer view and the Editor.

    To run the test from the Editor, select the green play button to the left of the test method.

1. Ensure that the **JsonLoanRepository.GetLoan: Returns null when loan ID is not found** test passes.

    You should see a green checkmark to the left of both tests.

#### Exercise 7 summary

In this exercise, you used GitHub Copilot to evaluate the existing UnitTests project and extend the project to begin testing the data access classes in the Library.Infrastructure project. You added a reference to the Library.Infrastructure project in the UnitTests.csproj file and created unit tests for the JsonLoanRepository class. You used GitHub Copilot to help you write the unit tests for the GetLoan method in the JsonLoanRepository class. You ran the unit tests using Visual Studio Code's Test Explorer and verified that the tests passed.

## Part 4: Refactor and improve code sections using GitHub Copilot tools

### Before you start

#### Project overview

You and your coworker have completed the initial development phase of the project and are now investigating ways to refactor and improve your codebase.

Code refactoring is a process that restructures existing code without changing its external behavior. Refactoring is often used to improve a specific aspect of your code. GitHub Copilot can help you refactor your code by suggesting changes that improve the code's quality, reliability, performance, and security.

#### Lab scenario (part 4)

In part 4 of this lab, you use GitHub Copilot to refactor the following code sections:

- You refactor the EnumHelper class to use dictionaries instead of reflection. Using dictionaries improves performance by reducing the overhead of reflection. Eliminating reflection also improves code readability, maintainability, and security.

- You refactor the data access methods to use LINQ (Language Integrated Query) rather than foreach loops. Using LINQ provides a more concise and readable way to query collections, databases, and XML documents. Using LINQ can improve code readability, maintainability, and performance.

Part includes the following exercises:

- Use GitHub Copilot to refactor the EnumHelper class.
- Use GitHub Copilot to improve the data access classes with LINQ.

### Exercise 8: Use GitHub Copilot to refactor the EnumHelper class

Reflection is a powerful feature that allows you to inspect and manipulate objects at runtime. However, reflection can be slow and there are potential security risks associated with reflection that should be considered.

The existing EnumHelper class uses reflection to retrieve the description attribute of an enum value. You can refactor the EnumHelper class to use dictionaries instead of reflection. Using dictionaries can improve performance and eliminate any security concerns associated with using reflection.

In this exercise, you use GitHub Copilot to help you refactor the EnumHelper class.

Use the following steps to complete this exercise:

1. Use the Solution Explorer view to open the EnumHelper.cs file.

    ```csharp

    using System.ComponentModel;
    using System.Reflection;

    namespace Library.ApplicationCore.Enums;

    public static class EnumHelper
    {

        public static string GetDescription(Enum value)
        {
            if (value == null)
                return string.Empty;
    
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString())!;

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

    }

    ```

1. Open the Chat view, and then add the following files to the Chat context: **EnumHelper.cs**, **LoanExtensionStatus.cs**, **LoanReturnStatus.cs**, **MembershipRenewalStatus.cs**.

1. Enter the following prompt:

    ```plaintext
    @workspace I want to refactor the `EnumHelper` class using dictionaries rather than reflection to get enum description attributes. I want a separate dictionary for each enum. The enum values are in the `LoanExtensionStatus.cs`, `LoanReturnStatus.cs`, and `MembershipRenewalStatus.cs` files. Explain how to update the EnumHelper class to use dictionaries and provide the updated code.
    ```

    This prompt asks GitHub Copilot to provide an explanation of how to update the EnumHelper class to use dictionaries instead of reflection. It also asks for the updated code that uses dictionaries for each enum value.

1. Take a minute to review the explanation provided by GitHub Copilot.

    The explanation should be similar to the following description:

    ```markdown
    To refactor the EnumHelper class to use dictionaries for each enum, you need to create a dictionary for each enum type that maps the enum values to their descriptions. This will eliminate the need for reflection at runtime.

    Here's how you can update the EnumHelper class:

    1. Create dictionaries for each enum type.
    2. Populate these dictionaries with the enum values and their corresponding descriptions.
    3. Update the GetDescription method to use these dictionaries.

    Below is the updated code for the EnumHelper class:

    ```

    ```csharp

    using System.ComponentModel;
    using System.Collections.Generic;

    namespace Library.ApplicationCore.Enums
    {

        public static class EnumHelper
        {
            private static readonly Dictionary<MembershipRenewalStatus, string> MembershipRenewalStatusDescriptions = new()
            {
                { MembershipRenewalStatus.Success, "Membership renewal was successful." },
                { MembershipRenewalStatus.PatronNotFound, "Patron not found." },
                { MembershipRenewalStatus.TooEarlyToRenew, "It is too early to renew the membership." },
                { MembershipRenewalStatus.LoanNotReturned, "Cannot renew membership due to an outstanding loan." },
                { MembershipRenewalStatus.Error, "Cannot renew membership due to an error." }
            };

            private static readonly Dictionary<LoanReturnStatus, string> LoanReturnStatusDescriptions = new()
            {
                { LoanReturnStatus.Success, "Book was successfully returned." },
                { LoanReturnStatus.LoanNotFound, "Loan not found." },
                { LoanReturnStatus.AlreadyReturned, "Cannot return book as the book is already returned." },
                { LoanReturnStatus.Error, "Cannot return book due to an error." }
            };

            private static readonly Dictionary<LoanExtensionStatus, string> LoanExtensionStatusDescriptions = new()
            {
                { LoanExtensionStatus.Success, "Book loan extension was successful." },
                { LoanExtensionStatus.LoanNotFound, "Loan not found." },
                { LoanExtensionStatus.LoanExpired, "Cannot extend book loan as it already has expired. Return the book instead." },
                { LoanExtensionStatus.MembershipExpired, "Cannot extend book loan due to expired patron's membership." },
                { LoanExtensionStatus.LoanReturned, "Cannot extend book loan as the book is already returned." },
                { LoanExtensionStatus.Error, "Cannot extend book loan due to an error." }
            };

            public static string GetDescription(Enum value)
            {
                if (value == null)
                    return string.Empty;

                return value switch
                {
                    MembershipRenewalStatus status => MembershipRenewalStatusDescriptions[status],
                    LoanReturnStatus status => LoanReturnStatusDescriptions[status],
                    LoanExtensionStatus status => LoanExtensionStatusDescriptions[status],
                    _ => value.ToString()
                };
            }
        }

    }

    ```

    ```markdown

    This refactored EnumHelper class uses dictionaries to store the descriptions for each enum type. The GetDescription method now uses pattern matching to determine the type of the enum and retrieves the description from the appropriate dictionary. This approach avoids the use of reflection and improves performance.

    ```

    > [!NOTE]
    > If GitHub Copilot doesn't populate the dictionaries with the correct descriptions, ensure that the GitHub Copilot extension isn't requesting a restart. If it is, restart the extension and try the prompt again.

1. Use GitHub Copilot's suggested EnumHelper class to update your EnumHelper.cs file.

1. Ensure that your updated EnumHelper class is using the enum values from the LoanExtensionStatus.cs, LoanReturnStatus.cs, and MembershipRenewalStatus.cs files.

    Open each of the enum files and verify that the enum values in the dictionaries are correct. If there are discrepancies, have GitHub Copilot update the dictionaries for each enum individually. For example, you can use the following prompt for the LoanExtensionStatus enum:

    ```plaintext
    @workspace Use the description values in LoanExtensionStatus.cs to update the LoanExtensionStatus dictionary in the EnumHelper class. Provide the updated code for the LoanExtensionStatus dictionary in the EnumHelper class.
    ```

    If necessary, use the same approach for the LoanReturnStatus and MembershipRenewalStatus enums.

1. Take a minute to review the **GetDescription** method.

    ```csharp

    public static string GetDescription(Enum value)
    {

        if (value == null)
            return string.Empty;

        return value switch
        {
            MembershipRenewalStatus status => MembershipRenewalStatusDescriptions[status],
            LoanReturnStatus status => LoanReturnStatusDescriptions[status],
            LoanExtensionStatus status => LoanExtensionStatusDescriptions[status],
            _ => value.ToString()
        };

    }

    ```

    This code uses pattern matching to determine the type of the enum and retrieve the description from the appropriate dictionary. The switch statement checks the type of the enum value and returns the corresponding description from the dictionary. If the enum value is not found in the dictionary, the method returns the enum value as a string.

    If you ask GitHub Copilot to refactor this code and eliminate the lambda expressions, it becomes easier to read:

    ```csharp

    public static string GetDescription(Enum value)
    {

        if (value == null)
            return string.Empty;

        switch (value)
        {
            case MembershipRenewalStatus status:
                return MembershipRenewalStatusDescriptions[status];
            case LoanReturnStatus status:
                return LoanReturnStatusDescriptions[status];
            case LoanExtensionStatus status:
                return LoanExtensionStatusDescriptions[status];
            default:
                return value.ToString();
        }

    }

    ```

1. Build your solution to ensure that there are no errors.

    You'll see warnings. You can ignore them for now.

#### Exercise 8 summary

In this exercise, you used GitHub Copilot to refactor the EnumHelper class to use dictionaries instead of reflection. Using dictionaries improves performance by reducing the overhead of reflection. Eliminating reflection also improves code readability, maintainability, and security.

### Exercise 9: Use GitHub Copilot to improve the data access classes with LINQ

LINQ (Language Integrated Query) is a powerful feature in C# that allows you to query collections, databases, and XML documents in a uniform way. LINQ provides a more concise and readable way to query data compared to traditional foreach loops.

This exercise includes the following tasks:

- Refactor the methods in JsonData.cs to use LINQ.
- Refactor the methods in JsonLoanRepository.cs to use LINQ.
- Refactor the methods in JsonPatronRepository.cs to use LINQ.

#### Task 1: Refactor the methods in JsonData.cs to use LINQ

The JsonData class includes the following data access methods: GetPopulatedPatron, GetPopulatedLoan, GetPopulatedBookItem, GetPopulatedBook. These methods use foreach loops to iterate over collections and populate objects. You can refactor these methods to use LINQ to improve code readability and maintainability.

Use the following steps to complete this section of the exercise:

1. Open the JsonData.cs file.

1. Select the **GetPopulatedPatron** method.

    The GetPopulatedPatron method is designed to create a fully populated Patron object. It copies the basic properties of the Patron and populates its Loans collection with detailed Loan objects.

    ```csharp

    public Patron GetPopulatedPatron(Patron p)
    {

        Patron populated = new Patron
        {
            Id = p.Id,
            Name = p.Name,
            ImageName = p.ImageName,
            MembershipStart = p.MembershipStart,
            MembershipEnd = p.MembershipEnd,
            Loans = new List<Loan>()
        };

        foreach (Loan loan in Loans!)
        {
            if (loan.PatronId == p.Id)
            {
                populated.Loans.Add(GetPopulatedLoan(loan));
            }
        }

        return populated;

    }

    ```

1. Open an inline chat, and then enter a prompt that refactor's the method using LINQ.

    ```plaintext
    #selection refactor selection to `return new Patron` using LINQ
    ```

1. Take a minute to review the suggested update.

    The suggested update should look similar to the following code:

    ```csharp

    public Patron GetPopulatedPatron(Patron p)
    {

        return new Patron
        {
            Id = p.Id,
            Name = p.Name,
            ImageName = p.ImageName,
            MembershipStart = p.MembershipStart,
            MembershipEnd = p.MembershipEnd,
            Loans = Loans!
                .Where(loan => loan.PatronId == p.Id)
                .Select(GetPopulatedLoan)
                .ToList()
        };

    }

    ```

    First off, a LINQ query is used to replace the "foreach (Loan loan in Loans!)" loop. With the LINQ code in place, you can use an object initializer to assign object properties to the new Patron object. This alleviates the need for a separate populated instance of the Patron object. Overall, the updated code is shorter and more readable.

    The code uses the input patron "p" to assign some basic properties to the new Patron object. Then it populates the Loans collection with loans that are associated with the input Patron, transforming each loan using the GetPopulatedLoan method.

    You can break down the LINQ code line that populates the Loans collection:

    - `Loans!`: The "Loans!" expression accesses the Loans collection. The "!" operator is a null-forgiving operator, indicating that the developer is confident that Loans is not null. You should ensure that Loans is properly initialized before calling the GetPopulatedPatron method.
    - `.Where(loan => loan.PatronId == p.Id)`: This code filters the loans to include only those that belong to the input patron "p".
    - `.Select(GetPopulatedLoan)`: This code transforms each filtered loan using the GetPopulatedLoan method.
    - `.ToList()`: Converts the result to a List of Loan objects.

1. To accept the suggested update, select **Accept**.

    Now that you've seen how to refactor the GetPopulatedPatron method, you can refactor the GetPopulatedLoan, GetPopulatedBookItem, and GetPopulatedBook methods to use LINQ as well.

1. Refactor the **GetPopulatedLoan**, **GetPopulatedBookItem**, and **GetPopulatedBook** methods using the same approach.

    For example, use the following prompts to refactor the three methods:

    For the **GetPopulatedLoan** method:

    ```plaintext
    #selection refactor selection to `return new Loan` using LINQ. Use `GetPopulatedBookItem` for the `BookItem` property. Use `Single` for BookItem and Patron properties.
    ```

    For the **GetPopulatedBookItem** method:

    ```plaintext
    #selection refactor selection to `return new BookItem` using LINQ. Use `GetPopulatedBook` and `Single` for the `BookItem` property.
    ```

    For the **GetPopulatedBook** method:

    ```plaintext
    #selection refactor selection to `return new Book` using LINQ. Use `Where` and `Select` for `Author` property. Use `First` author.
    ```

1. After accepting the suggested updates, take a minute to review your code changes.

    You updated code should look similar to the following code:

    ```csharp

    public Loan GetPopulatedLoan(Loan l)
    {

        return new Loan
        {
            Id = l.Id,
            BookItemId = l.BookItemId,
            PatronId = l.PatronId,
            LoanDate = l.LoanDate,
            DueDate = l.DueDate,
            ReturnDate = l.ReturnDate,
            BookItem = GetPopulatedBookItem(BookItems!.Single(bi => bi.Id == l.BookItemId)),
            Patron = Patrons!.Single(p => p.Id == l.PatronId)
        };
    }

    public BookItem GetPopulatedBookItem(BookItem bi)
    {
        return new BookItem
        {
            Id = bi.Id,
            BookId = bi.BookId,
            AcquisitionDate = bi.AcquisitionDate,
            Condition = bi.Condition,
            Book = GetPopulatedBook(Books!.Single(b => b.Id == bi.BookId))
        };
    }

    public Book GetPopulatedBook(Book b)
    {
        return new Book
        {
            Id = b.Id,
            Title = b.Title,
            AuthorId = b.AuthorId,
            Genre = b.Genre,
            ISBN = b.ISBN,
            ImageName = b.ImageName,
            Author = Authors!.Where(a => a.Id == b.AuthorId).Select(a => new Author {
                Id = a.Id,
                Name = a.Name
            }).First()
        };

    }

    ```

1. Use the **Explain** smart action to see an explanation of the LINQ queries.

    The **Explain** smart action provides a detailed explanation of the LINQ queries used in the code.

    For example, you can use the **Explain** smart action on the GetPopulatedBook method to see an explanation of the LINQ query used to populate the Author property of the Book object.

    ```csharp

    Author = Authors!.Where(a => a.Id == b.AuthorId).Select(a => new Author {
        Id = a.Id,
        Name = a.Name
    }).First()

    ```

    The **Explain** smart action provides a detailed explanation of the LINQ query used to populate the Author property of the Book object.

    For example, the explanation might look like this:

    ```plaintext
    The active selection is a C# code snippet that assigns a value to the Author property. This value is derived from a collection of Author objects named Authors. The code uses LINQ (Language Integrated Query) to filter and transform the data within this collection.
    
    First, the Authors! expression uses the null-forgiving operator (!) to indicate that Authors is not null, even if the compiler might think otherwise. This is a way to suppress nullable warnings. The Where method is then called on the Authors collection to filter the elements. The lambda expression a => a.Id == b.AuthorId is used to find all Author objects where the Id matches the AuthorId property of another object b.
    
    After filtering, the Select method is used to project each filtered Author object into a new Author object. This is done by creating a new instance of the Author class and copying the Id and Name properties from the original Author object.
    
    Finally, the First method is called to retrieve the first element from the resulting sequence. This means that the Author property will be assigned the first Author object that matches the filter criteria and has been projected into a new Author instance.
    
    This approach ensures that the Author property is set to a new Author object with the same Id and Name as the first matching Author in the Authors collection.
    ```

1. Build your solution to ensure that there are no errors.

    You'll see warnings. You can ignore them for now.

#### Task 2: Refactor the methods in JsonLoanRepository.cs to use LINQ

The JsonLoanRepository class includes the GetLoan and UpdateLoan data access methods. You'll refactor these two methods, replacing foreach loops with LINQ to improve code readability and maintainability.

Use the following steps to complete this section of the exercise:

1. Open the **JsonLoanRepository.cs** file.

1. Select the **GetLoan** method.

    The GetLoan method is designed to retrieve a loan by its ID.

    ```csharp

    public async Task<Loan?> GetLoan(int id)
    {

        await _jsonData.EnsureDataLoaded();

        foreach (Loan loan in _jsonData.Loans!)
        {
            if (loan.Id == id)
            {
                Loan populated = _jsonData.GetPopulatedLoan(loan);
                return populated;
            }
        }

        return null;

    }

    ```

1. Open the inline chat, and then enter a prompt that refactors the method using LINQ.

    For example, enter the following prompt:

    ```plaintext
    #selection refactor selection using LINQ with `_jsonData.Loans!. Use `Where`, `Select` and `GetPopulatedLoan` to return `FirstOrDefault`.
    ```

1. Take a minute to review the suggested update.

    The suggested update should look similar to the following code:

    ```csharp

    public async Task<Loan?> GetLoan(int id)
    {

        await _jsonData.EnsureDataLoaded();

        Loan? loan = _jsonData.Loans!
            .Where(l => l.Id == id)
            .Select(l => _jsonData.GetPopulatedLoan(l))
            .FirstOrDefault();

        return loan;

    }

    ```

    The updated code uses LINQ to filter the loans collection to include only the loan with the specified ID. Notice that loan should be declared as nullable (`Loan? loan`). It then transforms the loan using the GetPopulatedLoan method and returns the first result. If no matching loan is found, FirstOrDefault returns null. The method then returns this loan object, which may be null if no loan with the specified "id" exists. This approach ensures that the returned loan is fully populated with all necessary related data, providing a comprehensive view of the loan record.

    This code could be further simplified:

    ```csharp

    public async Task<Loan?> GetLoan(int id)
    {

        await _jsonData.EnsureDataLoaded();

        return _jsonData.Loans!
            .Where(l => l.Id == id)
            .Select(l => _jsonData.GetPopulatedLoan(l))
            .FirstOrDefault();

    }

    ```

1. To accept the updated GetLoan method, select **Accept**.

1. Select the **UpdateLoan** method.

    ```csharp

    public async Task UpdateLoan(Loan loan)
    {

        Loan? existingLoan = null;
        foreach (Loan l in _jsonData.Loans!)
        {
            if (l.Id == loan.Id)
            {
                existingLoan = l;
                break;
            }
        }

        if (existingLoan != null)
        {
            existingLoan.BookItemId = loan.BookItemId;
            existingLoan.PatronId = loan.PatronId;
            existingLoan.LoanDate = loan.LoanDate;
            existingLoan.DueDate = loan.DueDate;
            existingLoan.ReturnDate = loan.ReturnDate;

            await _jsonData.SaveLoans(_jsonData.Loans!);

            await _jsonData.LoadData();
        }

    }

    ```

1. Open the inline chat, and then enter a prompt that refactors the method using LINQ.

    For example, enter the following prompt:

    ```plaintext
    #selection refactor selection using LINQ find an existing loan `_jsonData.Loans!. Replace existing loan.
    ```

1. Take a minute to review the suggested update.

    The suggested update should look similar to the following code:

    ```csharp

    public async Task UpdateLoan(Loan loan)
    {

        Loan? existingLoan = _jsonData.Loans!.FirstOrDefault(l => l.Id == loan.Id);

        if (existingLoan != null)
        {
            existingLoan.BookItemId = loan.BookItemId;
            existingLoan.PatronId = loan.PatronId;
            existingLoan.LoanDate = loan.LoanDate;
            existingLoan.DueDate = loan.DueDate;
            existingLoan.ReturnDate = loan.ReturnDate;

            await _jsonData.SaveLoans(_jsonData.Loans!);

            await _jsonData.LoadData();
        }

    }

    ```

    The updated code uses LINQ to find the existing loan in the loans collection. It then updates the existing loan with the new loan data. The method then saves the updated loans collection and reloads the data. This approach ensures that the loan data is updated correctly and that the changes are persisted to the data store.

    You can also add the code to ensure the data is loaded before the method is executed:

    ```csharp

    public async Task UpdateLoan(Loan loan)
    {

        await _jsonData.EnsureDataLoaded();

        Loan? existingLoan = _jsonData.Loans!.FirstOrDefault(l => l.Id == loan.Id);

        if (existingLoan != null)
        {
            existingLoan.BookItemId = loan.BookItemId;
            existingLoan.PatronId = loan.PatronId;
            existingLoan.LoanDate = loan.LoanDate;
            existingLoan.DueDate = loan.DueDate;
            existingLoan.ReturnDate = loan.ReturnDate;

            await _jsonData.SaveLoans(_jsonData.Loans!);

            await _jsonData.LoadData();
        }

    }

    ```

1. To accept the updated UpdateLoan method, select **Accept**.

1. Build your solution to ensure that there are no errors.

    You'll see warnings. You can ignore them for now.

#### Task 3: Refactor the methods in JsonPatronRepository to use LINQ

The JsonPatronRepository class includes the SearchPatrons, GetPatron, and UpdatePatron methods, and it's a great candidate for optimization. You'll refactor these methods, replacing foreach loops with LINQ to improve code readability and maintainability.

Use the following steps to complete this section of the exercise:

1. Open the **JsonPatronRepository.cs** file.

1. Select the **SearchPatrons** method.

    The SearchPatrons method is designed to search for patrons by name.

    ```csharp

    public async Task<List<Patron>> SearchPatrons(string searchInput)
    {

        await _jsonData.EnsureDataLoaded();

        List<Patron> searchResults = new List<Patron>();
        foreach (Patron patron in _jsonData.Patrons)
        {
            if (patron.Name.Contains(searchInput))
            {
                searchResults.Add(patron);
            }
        }
        searchResults.Sort((p1, p2) => String.Compare(p1.Name, p2.Name));

        searchResults = _jsonData.GetPopulatedPatrons(searchResults);

        return searchResults;

    }

    ```

1. Open the inline chat, and then enter a prompt that refactors the method using LINQ.

    For example, enter the following prompt:

    ```plaintext
    #selection refactor selection using LINQ with `_jsonData.Patrons!. Replace the loop with `Where`, `OrderBy`, and `GetPopulatedPatrons`.
    ```

1. Take a minute to review the suggested update.

    The suggested update should look similar to the following code:

    ```csharp

    public async Task<List<Patron>> SearchPatrons(string searchInput)
    {

        await _jsonData.EnsureDataLoaded();

        List<Patron> searchResults = _jsonData.Patrons!
            .Where(patron => patron.Name.Contains(searchInput))
            .OrderBy(patron => patron.Name)
            .ToList();

        searchResults = _jsonData.GetPopulatedPatrons(searchResults);

        return searchResults;

    }

    ```

1. To accept the updated SearchPatrons method, select **Accept**.

1. Select the **GetPatron** method.

    The GetPatron method is designed to return the patron matching the specified "id".

    ```csharp

    public async Task<Patron?> GetPatron(int id)
    {

        await _jsonData.EnsureDataLoaded();

        foreach (Patron patron in _jsonData.Patrons!)
        {
            if (patron.Id == id)
            {
                Patron populated = _jsonData.GetPopulatedPatron(patron);
                return populated;
            }
        }
        return null;

    }

    ```

1. Open the inline chat, and then enter a prompt that refactors the method using LINQ.

    For example, enter the following prompt:

    ```plaintext
    #selection refactor selection using LINQ with `_jsonData.Patrons!. Use `Where`, `Select` and `GetPopulatedPatron` to return `FirstOrDefault`
    ```

1. Take a minute to review the suggested update.

    The suggested update should look similar to the following code:

    ```csharp

    public async Task<Patron?> GetPatron(int id)
    {

        await _jsonData.EnsureDataLoaded();

        var patron = _jsonData.Patrons!
            .Where(p => p.Id == id)
            .Select(p => _jsonData.GetPopulatedPatron(p))
            .FirstOrDefault();

        return patron;

    }

    ```

    This code could be simplified further:

    ```C#

    public async Task<Patron?> GetPatron(int id)
    {

        await _jsonData.EnsureDataLoaded();

        return _jsonData.Patrons!
            .Where(p => p.Id == id)
            .Select(p => _jsonData.GetPopulatedPatron(p))
            .FirstOrDefault();

    }

    ```

1. To accept the updated GetPatron method, select **Accept**.

1. Select the **UpdatePatron** method.

    The UpdatePatron method is designed to update the patron with the specified "id".

    ```csharp

    public async Task UpdatePatron(Patron patron)
    {

        await _jsonData.EnsureDataLoaded();
        var patrons = _jsonData.Patrons!;
        Patron existingPatron = null;
        foreach (var p in patrons)
        {
            if (p.Id == patron.Id)
            {
                existingPatron = p;
                break;
            }
        }
        if (existingPatron != null)
        {
            existingPatron.Name = patron.Name;
            existingPatron.ImageName = patron.ImageName;
            existingPatron.MembershipStart = patron.MembershipStart;
            existingPatron.MembershipEnd = patron.MembershipEnd;
            existingPatron.Loans = patron.Loans;
            await _jsonData.SavePatrons(patrons);
            await _jsonData.LoadData();
        }

    }

    ```

1. Open the inline chat, and then enter a prompt that refactors the method using LINQ.

    For example, enter the following prompt:

    ```plaintext
    #selection refactor selection using LINQ to find `patron` in `_jsonData.Patrons!. Replace existing patron with `patron`.
    ```

1. Take a minute to review the suggested update.

    The suggested update should look similar to the following code:

    ```csharp

    public async Task UpdatePatron(Patron patron)
    {

        await _jsonData.EnsureDataLoaded();
        var patrons = _jsonData.Patrons!;
        var existingPatron = patrons.FirstOrDefault(p => p.Id == patron.Id);
        if (existingPatron != null)
        {
            existingPatron.Name = patron.Name;
            existingPatron.ImageName = patron.ImageName;
            existingPatron.MembershipStart = patron.MembershipStart;
            existingPatron.MembershipEnd = patron.MembershipEnd;
            existingPatron.Loans = patron.Loans;
            await _jsonData.SavePatrons(patrons);
            await _jsonData.LoadData();
        }

    }

    ```

1. To accept the updated UpdatePatron method, select **Accept**.

#### Task 4: Check your work

Use the following steps to check your work:

1. To clean the solution, right-click **AccelerateAppDevGitHubCopilot**, and then select **Clean**.

    This action removes any build artifacts from the previous build. Cleaning the solution will effectively reset the JSON data files to their original values during (in the output directory).

1. Build the application and ensure there are no errors.

1. Run the application.

    You can run the application from the Solution Explorer view by right-clicking the **Library.Console** project, selecting **Debug**, and then selecting **Start New Instance**.

1. When prompted for a patron name, type **One** and then press Enter.

1. At the "Matching Patrons" prompt, type **2** and then press Enter.

1. At the "Book Loans" prompt, type **1** and then press Enter.

1. At the "Input Options" prompt, type **r** and then press Enter.

1. Verify that the message **"Book was successfully returned."** is displayed.

1. To begin a new search, type **s** and then press Enter.

1. When prompted for a patron name, type **One** and then press Enter.

1. At the "Matching Patrons" prompt, type **2** and then press Enter.

1. Verify that first book loan is marked **Returned: True**.

1. At the "Input Options" prompt, type **q** and then press Enter.

1. Stop the application.

#### Exercise 9 summary

In this exercise, you refactored the data access methods in the JsonData, JsonLoanRepository, and JsonPatronRepository classes to use LINQ. These changes improve code readability, maintainability, and performance.
