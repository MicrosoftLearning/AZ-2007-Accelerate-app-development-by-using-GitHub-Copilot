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



/* 
using Library.Console;
using Library.Infrastructure.Data;
using Library.ApplicationCore.Enums;
using Library.ApplicationCore.Entities;
using Library.ApplicationCore;

*/
/* 
ConsoleState _currentState = ConsoleState.PatronSearch;

List<Patron> matchingPatrons = new List<Patron>();

Patron? selectedPatronDetails = null;

Loan selectedLoanDetails = null!;
*/

/* 
JsonData _jsonData = new JsonData();

IPatronRepository _patronRepository = new JsonPatronRepository(_jsonData);

ILoanRepository _loanRepository = new JsonLoanRepository(_jsonData);

ILoanService _loanService = new LoanService(_loanRepository);

ConsoleApp consoleApp = new ConsoleApp(_loanService, _patronRepository, _loanRepository);
consoleApp.Run();
*/

/* 
List<Patron> _patronsStub = new List<Patron> {
    new Patron {
        Name = "John Doe",
        Loans = new List<Loan> {
            new Loan {
                BookItem = new BookItem {
                    Book = new Book {
                        Title = "The Hobbit",
                        Author = new Author {
                            Name = "J.R.R. Tolkien"
                        },
                        ImageName = "The Hobbit.jpg",
                        Genre = "Fantasy",
                        ISBN = "978-0-395-19395-6"
                    }
                },
                DueDate = DateTime.Now.AddDays(7),
                ReturnDate = null
            }
        }
    }
    };
*/

/* 
while (true)
{
    switch (_currentState)
    {
        case ConsoleState.PatronSearch:
            _currentState = PatronSearch();
            break;
        case ConsoleState.PatronSearchResults:
            _currentState = PatronSearchResults();
            break;
        case ConsoleState.PatronDetails:
            _currentState = PatronDetails();
            break;
        case ConsoleState.LoanDetails:
            _currentState = LoanDetails();
            break;
    }
}
*/
/* 
ConsoleState PatronSearch()
{
    string searchInput = ReadPatronName();

    //matchingPatrons = SearchPatrons(searchInput);
    matchingPatrons = _patronRepository.SearchPatrons(searchInput);

    // Guard-style clauses for edge cases
    if (matchingPatrons.Count > 20)
    {
        Console.WriteLine("More than 20 patrons satisfy the search, please provide more specific input...");
        return ConsoleState.PatronSearch;
    }
    else if (matchingPatrons.Count == 0)
    {
        Console.WriteLine("No matching patrons found.");
        return ConsoleState.PatronSearch;
    }

    Console.WriteLine("Matching Patrons:");
    PrintPatronsList(matchingPatrons);
    return ConsoleState.PatronSearchResults;
}

static string ReadPatronName()
{
    string? searchInput = null;
    while (String.IsNullOrWhiteSpace(searchInput))
    {
        Console.Write("Enter a string to search for patrons by name: ");

        searchInput = Console.ReadLine();
    }
    return searchInput;
}

static void PrintPatronsList(List<Patron> matchingPatrons)
{
    int patronNumber = 1;
    foreach (Patron patron in matchingPatrons)
    {
        Console.WriteLine($"{patronNumber}) {patron.Name}");
        patronNumber++;
    }
}

ConsoleState PatronSearchResults()
{
    CommonActions options = CommonActions.Select | CommonActions.SearchPatrons | CommonActions.Quit;
    CommonActions action = ReadInputOptions(options, out int selectedPatronNumber);
    if (action == CommonActions.Select)
    {
        if (selectedPatronNumber >= 1 && selectedPatronNumber <= matchingPatrons.Count)
        {
            var selectedPatron = matchingPatrons.ElementAt(selectedPatronNumber - 1);
            selectedPatronDetails = _patronRepository.GetPatron(selectedPatron.Id)!;
            return ConsoleState.PatronDetails;
        }
        else
        {
            Console.WriteLine("Invalid patron number. Please try again.");
            return ConsoleState.PatronSearchResults;
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

    throw new InvalidOperationException("An input option is not handled.");
}

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
            "r" when options.HasFlag(CommonActions.ReturnLoanedBook) => CommonActions.ReturnLoanedBook,
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

static void WriteInputOptions(CommonActions options)
{
    Console.WriteLine("Input Options:");
    if (options.HasFlag(CommonActions.ReturnLoanedBook))
    {
        Console.WriteLine(" - \"r\" to mark as returned");
    }
    if (options.HasFlag(CommonActions.SearchPatrons))
    {
        Console.WriteLine(" - \"s\" for new search");
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


ConsoleState PatronDetails()
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

    CommonActions options = CommonActions.SearchPatrons | CommonActions.Quit | CommonActions.Select;
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

    throw new InvalidOperationException("An input option is not handled.");
}


ConsoleState LoanDetails()
{
    Console.WriteLine($"Book title: {selectedLoanDetails.BookItem!.Book!.Title}");
    Console.WriteLine($"Book Author: {selectedLoanDetails.BookItem!.Book!.Author!.Name}");
    Console.WriteLine($"Due date: {selectedLoanDetails.DueDate}");
    Console.WriteLine($"Returned: {(selectedLoanDetails.ReturnDate != null).ToString()}");
    Console.WriteLine();

    CommonActions options = CommonActions.SearchPatrons | CommonActions.Quit | CommonActions.ReturnLoanedBook;
    CommonActions action = ReadInputOptions(options, out int selectedLoanNumber);

    if (action == CommonActions.ReturnLoanedBook)
    {
        var status = _loanService.ReturnLoan(selectedLoanDetails.Id);

        Console.WriteLine(EnumHelper.GetDescription(status));
        _currentState = ConsoleState.LoanDetails;
        // reload loan after returning
        selectedLoanDetails = _loanRepository.GetLoan(selectedLoanDetails.Id);
        return ConsoleState.LoanDetails;
    }
    else if (action == CommonActions.Quit)
    {
        return ConsoleState.Quit;
    }
    else if (action == CommonActions.SearchPatrons)
    {
        return ConsoleState.PatronSearch;
    }

    throw new InvalidOperationException("An input option is not handled.");
}
*/


#region Data Access
/* 
List<Patron> SearchPatrons(string searchInput)
{
    _jsonData.EnsureDataLoaded();

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


Patron? GetPatron(int id)
{
    _jsonData.EnsureDataLoaded();

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
*/

/*  
Loan? GetLoan(int id)
{
    _jsonData.EnsureDataLoaded();

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
*/

/* 
Enum ReturnLoan(int id)
{
    selectedLoanDetails.ReturnDate = DateTime.Now;
    UpdateLoan(selectedLoanDetails);
    return LoanReturnStatus.Success;
}
*/
 
/*
void UpdateLoan(Loan loan)
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

        _jsonData.SaveLoans(_jsonData.Loans!);

        _jsonData.LoadData();
    }
}
*/
#endregion