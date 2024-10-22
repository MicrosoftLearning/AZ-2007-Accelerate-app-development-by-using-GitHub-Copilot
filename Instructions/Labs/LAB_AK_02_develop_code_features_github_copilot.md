---
lab:
    title: 'Lab: Develop code features using GitHub Copilot tools'
    type: 'Answer Key'
    module: 'Module 2: Generate documentation using GitHub Copilot tools'
---

# Lab: Develop code features using GitHub Copilot tools
# Student lab answer key

## Instructions

### Before you start

#### Project overview

You and your coworker meet to discuss your goals for the library application. You want to improve the user experience for the librarians and patrons. You discuss several new features that could be added to the application.

You agree to work on the following features:

- Book availability: Enable a librarian to determine the availability status of a book. This feature should display a message indicating if a book is available for loan or the return due date if the book is currently on loan to another patron.

- Book loans: Enable a librarian to loan a book to a patron (if the book is available). This feature should display the option for a patron to receive a book on loan, update Loans.json with the new loan, and display updated the loan details for the patron.

- Book reservations: Enable a librarian to reserve a book for a patron (unless the book is already reserved). This feature should implement a new book reservation process. This feature may require creating a new Reservations.json file along with the new classes and interfaces required to support the reservation process.

Each of you will work on one of the new features and then regroup. You'll work on the feature to determine the availability status of a book. Your coworker will work on the feature to loan a book to a patron. The final feature, to reserve a book for a patron, will be developed after the other two features are completed.

#### Lab scenario

GitHub Copilot can help you develop new features for the library application. In this lab, you'll use GitHub Copilot to generate code suggestions that help you implement the new features more quickly and accurately.

This lab includes the following exercises:

- Develop a new "book availability" feature.
- Merge your changes into the main branch of the repository.

### Exercise 1: Develop a new "book availability" feature

The book availability feature should include the following code updates:

- Implement a new `CommonActions.SearchBooks` action that enables a librarian to select the option to search for a book.
- Create a new `SearchBooks` method in ConsoleApp.cs. The `SearchBooks` method should read a user provided book title. Check if a book is available for loan, and display a message stating either "`book.title` is available for loan" or "`book.title` is on loan to another patron. The return due date is `loan.DueDate`.

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

1. To create a new branch, type **book availability** and then select **+ Create New Branch**.

1. To push the new branch to the remote repository, select **Publish Branch**.

#### Task 2: Implement a new "SearchBooks" common action

In this section of the exercise, you use GitHub Copilot to help you implement a menu option named SearchBooks. Librarians will choose the SearchBooks action to check the availability status of a book.

Complete the following steps to implement the new `SearchBooks` common action:

- Update the `CommonActions` enum: Add a new `SearchBooks` action to the `CommonActions` enum.
- Update the `WriteInputOptions` method in ConsoleApp.cs: Add support for displaying the new `CommonActions.SearchBooks` option.
- Update the `ReadInputOptions` method in ConsoleApp.cs: Add support for reading (selecting) the new `CommonActions.SearchBooks` option.
- Update the `PatronDetails` method in ConsoleApp.cs: Add support for processing the new `CommonActions.SearchBooks` option when it's selected.

Use the following steps to complete this section of the exercise:

1. Open the SOLUTION EXPLORER view.

1. Open the CommonActions.cs file, and then select the `CommonActions` enum.

    You need to add a new `SearchBooks` action to `CommonActions`.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to include a new `SearchBooks` action.
    ```

    GitHub Copilot should suggest a code update that adds the new `SearchBooks` action to the `CommonActions` enum.

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

1. Find and then select the `WriteInputOptions` method.

    You need to add support for the new `CommonActions.SearchBooks` option. Display the option to check if a book is available for loan.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to include an option for the `CommonActions.SearchBooks` action. Use the letter "b" and the message "to check for book availability".
    ```

    GitHub Copilot should suggest a code update that adds a new `if` block for the `SearchBooks` action.

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

1. Scroll up slightly to find and then select the `ReadInputOptions` method.

    You need to add support for the new `CommonActions.SearchBooks` option. Include a case that handles the user selecting the `SearchBooks` action.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to include an option for the `CommonActions.SearchBooks` action.
    ```

    GitHub Copilot should suggest a code update that adds a new `case` that handles the user selecting the `SearchBooks` action.

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

1. Scroll down to find and then select the `PatronDetails` method.

    There are two things that you need to accomplish:

    - You need to add `CommonActions.SearchBooks` to `options` before calling `ReadInputOptions`.
    - You also need to add an `else if` to handle the `SearchBooks` action. The `else if` block should call a new method named `SearchBooks`.

    You can address both of these using a single prompt.

1. Open the inline chat and then enter the following prompt:

    ```plaintext
    Update selection to add `CommonActions.SearchBooks` to `options` before calling `ReadInputOptions`. Add an `else if` block to handle the `SearchBooks` action. The `else if` block should call a new method named `SearchBooks`.
    ```

    GitHub Copilot should suggest a code update that adds `CommonActions.SearchBooks` to `options` before calling `ReadInputOptions`.

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
    > Inline chat suggestions may also create stub code for the `SearchBooks` method.

#### Task 3: Develop the `SearchBooks` method

The SearchBooks method should read a user provided book title, check if a book is available for loan, and display a message indicating the availability status of the book. The method should use the `Books.json` and `Loans.json` files to find the matching book title and determine the availability status of the book.

Use the following steps to complete this section of the exercise:

1. Take a minute to consider the process requirements for the `SearchBooks` method.

    What does the method need to do? What should it return? Does it require parameters?

    The `SearchBooks` method should implement the following process:

    1. Prompt the user for a book title.
    1. Read the user provided book title.
    1. Check if a book is available for loan
    1. Display a message stating one of the following options:

        - "`book.title` is available for loan"
        - "`book.title` is on loan to another patron. The return due date is `loan.DueDate`.

    To build the message options, your code will need to access the following JSON files:

    - `Books.json` is needed to find the matching `Title` and `BookId`.
    - `Loans.json` is needed to find the `ReturnDate` and `DueDate` for the matching `BookItemId`. The `BookItemId` is the same as the `BookId` in `Books.json`.

1. Ensure that you have the following `SearchBooks` method created in the ConsoleApp.cs file:

    ```csharp
    async Task<ConsoleState> SearchBooks()
    {

        return ConsoleState.PatronDetails;
    }
    ```

    > [!NOTE]
    > Be sure to remove any code comments created by GitHub Copilot. Unnecessary and inaccurate comments can negatively influence GitHub Copilot's suggestions.

1. Select the `SearchBooks` method.

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

1. Select the `SearchBooks` method.

1. Open the Chat view and then enter the following prompt:

    ```plaintext
    @workspace #file:ConsoleApp.cs #file:JsonData.cs #file:JsonLoanRepository.cs #file:Books.json #file:Loans.json Explain how to update the `SearchBooks` method to find a matching book title in the `Books.json` file. Use the user supplied book title to find a matching book. If a book is found, use Loans.json to check if the book is available for loan. If the book has been returned, display a message stating "`book.title` is available for loan". If the book is on loan, display a message stating "`book.title` is on loan to another patron. The return due date is `loan.DueDate`".
    ```

1. Take a minute to review the suggested updates.

    GitHub Copilot should create a suggestion similar to the following code snippet:

    ```csharp
    using Library.Infrastructure.Data;
    using Library.ApplicationCore.Entities;
    
    public class ConsoleApp
    {
        private readonly JsonData _jsonData;
        private readonly JsonLoanRepository _loanRepository;
    
        public ConsoleApp(JsonData jsonData, JsonLoanRepository loanRepository)
        {
            _jsonData = jsonData;
            _loanRepository = loanRepository;
        }
    
        async Task<ConsoleState> SearchBooks()
        {
            string? bookTitle = null;
            while (String.IsNullOrWhiteSpace(bookTitle))
            {
                Console.Write("Enter a book title to search for: ");
                bookTitle = Console.ReadLine();
            }
    
            await _jsonData.EnsureDataLoaded();
    
            // Search for the book by title
            var book = _jsonData.Books?.FirstOrDefault(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
    
            if (book != null)
            {
                // Check if the book is on loan
                var loan = _jsonData.Loans?.FirstOrDefault(l => l.BookItemId == book.Id && l.ReturnDate == null);
    
                if (loan == null)
                {
                    Console.WriteLine($"{book.Title} is available for loan.");
                }
                else
                {
                    Console.WriteLine($"{book.Title} is on loan to another patron. The return due date is {loan.DueDate}.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
    
            return ConsoleState.PatronDetails;
        }
    }
    ```

    Notice that the suggestions apply to the `ConsoleApp` class as well as the `SearchBooks` method.

1. Notice the following suggestions that apply to the `ConsoleApp` class:

    1. You should see one or more `using` statements listed at the top of the code snippet.

        You need to add `using Library.Infrastructure.Data;` to the top of the `ConsoleApp.cs` file. If other `using` statements are suggested, verify that they're required before adding them.

    1. One or more field declarations are specified at the top of the class.

        You need to add the `private readonly JsonData _jsonData;` field declaration to the `ConsoleApp` class. The `ILoanRepository _loanRepository;` field declaration is already present.

    1. The `ConsoleApp` class constructor uses the `JsonData` parameter.

        You need to add the `JsonData` parameter to the `ConsoleApp` constructor. Keep all existing constructor parameters.

1. Add the `using Library.Infrastructure.Data;` statement to the top of the `ConsoleApp.cs` file.

1. Add the `private readonly JsonData _jsonData;` field declaration to the `ConsoleApp` class before the class constructor.

1. Add a `JsonData jsonData` parameter to the `ConsoleApp` class constructor and use it to initialize the `_jsonData` field inside the constructor.

    The updated class constructor should look like the following code snippet:

    ```csharp
    public ConsoleApp(JsonData jsonData, ILoanService loanService, IPatronService patronService, IPatronRepository patronRepository, ILoanRepository loanRepository)
    {
        _jsonData = jsonData;        
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
        _loanService = loanService;
        _patronService = patronService;
    }
    ```

1. Use the code suggestions to update the `SearchBooks` method:

    The suggested code should use LINQ queries to search for the book by title and to check if the book is on loan. The code also includes logic to display the availability status of the book based on the search results. The logic suggested by GitHub Copilot to display response messages can be implemented in several ways. Two examples are provided in the code snippets below.

    The following code snippet shows one possible (GitHub Copilot suggested) implementation for the `SearchBooks` method:

    ```csharp
    async Task<ConsoleState> SearchBooks()
    {
        string? bookTitle = null;
        while (String.IsNullOrWhiteSpace(bookTitle))
        {
            Console.Write("Enter a book title to search for: ");
            bookTitle = Console.ReadLine();
        }

        await _jsonData.EnsureDataLoaded();

        // Search for the book by title
        var book = _jsonData.Books?.FirstOrDefault(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));

        if (book != null)
        {
            // Check if the book is on loan
            var loan = _jsonData.Loans?.FirstOrDefault(l => l.BookItemId == book.Id && l.ReturnDate == null);

            if (loan == null)
            {
                Console.WriteLine($"{book.Title} is available for loan.");
            }
            else
            {
                Console.WriteLine($"{book.Title} is on loan to another patron. The return due date is {loan.DueDate}.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }

        return ConsoleState.PatronDetails;
    }
    ```

    The following code snippet shows a second possible (GitHub Copilot suggested) implementation for the `SearchBooks` method:

    ```csharp
    async Task<ConsoleState> SearchBooks()
    {
        string? bookTitle = null;
        while (String.IsNullOrWhiteSpace(bookTitle))
        {
            Console.Write("Enter a book title to search for: ");
            bookTitle = Console.ReadLine();
        }

        await _jsonData.EnsureDataLoaded();

        var book = _jsonData.Books?.FirstOrDefault(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine($"No book found with the title '{bookTitle}'.");
            return ConsoleState.PatronDetails;
        }

        var loan = _jsonData.Loans?.FirstOrDefault(l => l.BookItemId == book.Id && l.ReturnDate == null);
        if (loan == null)
        {
            Console.WriteLine($"'{book.Title}' is available for loan.");
        }
        else
        {
            Console.WriteLine($"'{book.Title}' is on loan to another patron. The return due date is {loan.DueDate}.");
        }

        return ConsoleState.PatronDetails;
    }
    ```

1. Select the `SearchBooks` method.

1. Open the Chat view, and then enter the following prompt:

    ```plaintext
    @workspace #file:ConsoleApp.cs #selection Explain the LINQ queries and the evaluation of the book's availability status.
    ```

1. Take a minute to review the explanation provided by GitHub Copilot.

    You should see something similar to the following explanation:

    ```markdown
    **LINQ Query 1: Search for the Book by Title**

    1. Purpose: This query searches for a book in the `_jsonData.Books` collection that matches the bookTitle entered by the user.

    2. Details:

        - `_jsonData.Books`: This is the collection of books loaded from the JSON data.
        - `FirstOrDefault`: This method returns the first element that matches the condition or `null` if no such element is found.
        - `b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase)`: This lambda expression defines the condition to match the book title, ignoring case differences.

    **LINQ Query 2: Check if the Book is on Loan**

    1. Purpose: This query checks if the found book is currently on loan.

    2. Details:

      - `_jsonData.Loans`: This is the collection of loans loaded from the JSON data.
      - `FirstOrDefault`: This method returns the first loan that matches the condition or `null` if no such loan is found.
      - `l => l.BookItemId == book.Id && l.ReturnDate == null`: This lambda expression defines the condition to match loans where the `BookItemId` is the same as the `book.Id` and the `ReturnDate` is null (indicating the book is still on loan).

    **Evaluation of the Book's Availability Status**

    After executing the LINQ queries, the method evaluates the availability status of the book:

    1. Book Found:

      - If `book` is not `null`, it means a book with the entered title was found.
      - The method then checks if the book is on loan by evaluating the `loan` variable.

    2. Book Availability:

      - If `loan` is `null`, it means the book is not currently on loan, and the method prints that the book is available for loan.
      - If `loan` is not `null`, it means the book is on loan, and the method prints that the book is on loan along with the return due date.

    3. Book Not Found:

      - If `book` is `null`, it means no book with the entered title was found, and the method prints "Book not found."
    ```

1. Verify the logic implemented by the **Check if the Book is on Loan** query.

    Null-Conditional Operator: The `?.` operator is a null-conditional operator. It ensures that if `_jsonData.Loans` is `null`, the entire expression will evaluate to `null` without throwing a `NullReferenceException`.

    Lambda Expression: The lambda expression `l => l.BookItemId == book.Id && l.ReturnDate == null` defines the condition for the `FirstOrDefault` method. It checks each `loan` object `l` to see if its `BookItemId` matches the `Id` of the `book` object and if its `ReturnDate` is `null`.

    This code attempts to find the first `loan` in the `_jsonData.Loans` collection where the `BookItemId` matches the `Id` of the given `book` and the `ReturnDate` is `null`. If no such `loan` is found or if `_jsonData.Loans` is `null`, `loan` will be set to `null`.

    > [!NOTE]
    > Most modern libraries have multiple copies of the same book. This code assumes that there is only one copy of each book. If the library has multiple copies of the same book, the code will need to be updated to handle multiple loans for the same book. For the purposes of this training, we are assuming that there is only one copy of each book and that the logic provided is sufficient.

1. Build the solution to ensure that there are no errors.

    You'll see Warning messages, but there shouldn't be any errors.

    To build the solution in the SOLUTION EXPLORER view, right-click **AccelerateDevGitHubCopilot** and then select **Build**.

#### Summary

You used GitHub Copilot to help you implement a new feature for the library application. You created a new branch in the repository and then used GitHub Copilot to generate code suggestions that helped you implement the new feature more quickly and accurately. You added a new `SearchBooks` action to `CommonActions`, updated the `WriteInputOptions` and `ReadInputOptions` methods in `ConsoleApp.cs`, and created a new `SearchBooks` method to determine the availability status of a book.

### Exercise 2: Merge your changes into the main branch of the repository

You completed the new feature that enables a librarian to determine the availability status of a book. Now you need to merge your changes into the main branch of the repository. 

During this exercise, you'll complete the following tasks:

- Verify that your new feature works as expected
- Sync your changes with the remote repository
- Create a pull request to merge your changes into the main branch of the repository

#### Task 1: Verify that your new feature works as expected

Since you don't have automated tests, manual testing can be used to verify that the new feature works as expected. Using a data source that can be verified is important. In this case, you use the `Books.json` and `Loans.json` files to verify that the new feature reports the availability status of a book correctly.

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

1. Verify that **Book Nine** has been returned by **Patron One**.

    In the previous exercise, during a test of the Library application, you had **Patron One** return **Book Nine**. If the application shows that **Book Nine** hasn't been returned by **Patron One**, use the input options to select and return **Book Nine** before continuing.

    > [!NOTE]
    > The `Library.Console.csproj` file ensures that the JSON data files are copied to the output directory when the application is built. However, performing Clean or Rebuild operations will essentially reset the data. Repeated Build operations do not reset the data in the output directory (`/bin/Debug/net8.0/`).

1. At the "Input Options" prompt, type **b** and then press Enter.

1. Type **Book Nine** and then press Enter.

1. Verify that the application displays a message indicating that the book is available for loan.

1. At the "Input Options" prompt, type **q** and then press Enter.

1. Stop the debug session.

1. Open the `Loans.json` file.

    The `Loans.json` file is used to track the loan status of each book. You can use the `Loans.json` file to verify that the availability status of Book One and Book Nine is correct.

    The updated `Loans.json` file should be located in either the `Library.Console\bin\Debug\net8.0\Json` folder or `Library.Console\Json` folder.

    - If you're using the Visual Studio Code debugger to run the app, the updated `Loans.json` file should be located in the `Library.Console\bin\Debug\net8.0\Json` folder.

    - If you're using a `dotnet run` command from the `AccelerateDevGitHubCopilot\src\Library.Console>` folder to run the app, the updated `Loans.json` file should be located in the `Library.Console\Json` folder.

1. Verify that loan ID 37 and loan ID 46 are both for Book One (`"BookItemId": 1`).

    - Loan ID 37 should have a `ReturnDate` value (2024-01-17)
    - Loan ID 46 shouldn't have a `ReturnDate` value. The `ReturnDate` value should be `null`.

    The `ReturnDate` value is used to determine whether the book is currently on loan. If the `ReturnDate` value is `null`, the book is considered to be on loan.

1. Verify that loan ID 22 is for Book Nine (`"BookItemId": 9`) and that the `ReturnDate` value is set to today's date.

    If you're running in the debugger and you cleaned the solution after making changes to the `Loans.json` file, those changes are lost. After you clean the solution, the `Loans.json` file is reset to the original data the next time you run the application. You can manually update the `Loans.json` file to test the availability status of Book One and Book Nine.

#### Task 2: Sync your changes with the remote repository

You can use the Source Control view in Visual Studio Code to commit your changes to the local repository. After you commit your changes, you can sync them with the remote repository.

Use the following steps to complete this section of the exercise:

1. Select the Source Control view.

1. Ensure that the `CommonActions.cs` and `ConsoleApp.cs` files listed under **Changes**.

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

    After you configure the branches, a comparison of the changes between **main** and **book-availability** is displayed. You should see the changes you made to the `CommonActions.cs` and `ConsoleApp.cs` files.

1. Select **Create pull request**.

1. Enter a title for the pull request.

1. Use GitHub Copilot to generate a summary of a pull request.

    Members of an enterprise with a subscription to GitHub Copilot Enterprise, can use GitHub Copilot to generate a summary of a pull request. The summary to help reviewers understand your changes, or to quickly understand the changes in a pull request you're reviewing.

1. Ensure that the title and description reflect your code updates, and then select **Create pull request**.

1. Wait for the checks to complete, and then verify that all checks passed and that there are no conflicts with the base branch.

    It can take a minute for the checks to complete. You need to address any issues that are identified before you can merge the changes into the main branch.

1. To merge your changes into the main branch, select **Merge pull request**, and then select **Confirm merge**.

    Notice that you can delete the `book-availability` branch after merging the changes.

1. Open Visual Studio Code.

1. Switch to the **main** branch of the repository.

1. **Pull** the changes from the remote repository.

1. Verify that the changes you made in the **book-availability** branch are now in the **main** branch.

    The changes you made to the `CommonActions.cs` and `ConsoleApp.cs` files should be present in the `main` branch.

#### Summary

In this exercise, you tested you code and then merged your changes into the main branch of the repository. You committed your changes to the local repository, synced them with the remote repository, and then created a pull request to merge your changes into the main branch of the repository. You used GitHub Copilot to generate a summary of the pull request to help reviewers understand your changes.
