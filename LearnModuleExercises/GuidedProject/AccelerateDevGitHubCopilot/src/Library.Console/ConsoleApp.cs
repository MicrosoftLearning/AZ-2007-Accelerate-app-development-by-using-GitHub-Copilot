using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.ApplicationCore.Enums;
using Library.Console;

public class ConsoleApp
{
    ConsoleState _currentState = ConsoleState.PatronSearch;

    List<Patron> matchingPatrons = new List<Patron>();

    Patron? selectedPatronDetails = null;
    Loan selectedLoanDetails = null!;

    IPatronRepository _patronRepository;
    ILoanRepository _loanRepository;
    ILoanService _loanService;
    IPatronService _patronService;

    public ConsoleApp(ILoanService loanService, IPatronService patronService, IPatronRepository patronRepository, ILoanRepository loanRepository)
    {
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
        _loanService = loanService;
        _patronService = patronService;
    }

    public async Task Run()
    {
        while (true)
        {
            switch (_currentState)
            {
                case ConsoleState.PatronSearch:
                    _currentState = await PatronSearch();
                    break;
                case ConsoleState.PatronSearchResults:
                    _currentState = await PatronSearchResults();
                    break;
                case ConsoleState.PatronDetails:
                    _currentState = await PatronDetails();
                    break;
                case ConsoleState.LoanDetails:
                    _currentState = await LoanDetails();
                    break;
            }
        }
    }

    async Task<ConsoleState> PatronSearch()
    {
        string searchInput = ReadPatronName();

        matchingPatrons = await _patronRepository.SearchPatrons(searchInput);

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

    async Task<ConsoleState> PatronSearchResults()
    {
        CommonActions options = CommonActions.Select | CommonActions.SearchPatrons | CommonActions.Quit;
        CommonActions action = ReadInputOptions(options, out int selectedPatronNumber);
        if (action == CommonActions.Select)
        {
            if (selectedPatronNumber >= 1 && selectedPatronNumber <= matchingPatrons.Count)
            {
                var selectedPatron = matchingPatrons.ElementAt(selectedPatronNumber - 1);
                selectedPatronDetails = await _patronRepository.GetPatron(selectedPatron.Id)!;
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
                "m" when options.HasFlag(CommonActions.RenewPatronMembership) => CommonActions.RenewPatronMembership,
                "e" when options.HasFlag(CommonActions.ExtendLoanedBook) => CommonActions.ExtendLoanedBook,
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
        if (options.HasFlag(CommonActions.Quit))
        {
            Console.WriteLine(" - \"q\" to quit");
        }
        if (options.HasFlag(CommonActions.Select))
        {
            Console.WriteLine("Or type a number to select a list item.");
        }
    }

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

        CommonActions options = CommonActions.SearchPatrons | CommonActions.Quit | CommonActions.Select | CommonActions.RenewPatronMembership;
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

        throw new InvalidOperationException("An input option is not handled.");
    }

    async Task<ConsoleState> LoanDetails()
    {
        Console.WriteLine($"Book title: {selectedLoanDetails.BookItem!.Book!.Title}");
        Console.WriteLine($"Book Author: {selectedLoanDetails.BookItem!.Book!.Author!.Name}");
        Console.WriteLine($"Due date: {selectedLoanDetails.DueDate}");
        Console.WriteLine($"Returned: {(selectedLoanDetails.ReturnDate != null).ToString()}");
        Console.WriteLine();

        CommonActions options = CommonActions.SearchPatrons | CommonActions.Quit | CommonActions.ReturnLoanedBook | CommonActions.ExtendLoanedBook;
        CommonActions action = ReadInputOptions(options, out int selectedLoanNumber);

        if (action == CommonActions.ExtendLoanedBook)
        {
            var status = await _loanService.ExtendLoan(selectedLoanDetails.Id);
            Console.WriteLine(EnumHelper.GetDescription(status));

            // reload loan after extending
            selectedPatronDetails = (await _patronRepository.GetPatron(selectedPatronDetails.Id))!;
            selectedLoanDetails = (await _loanRepository.GetLoan(selectedLoanDetails.Id))!;
            return ConsoleState.LoanDetails;
        }
        else if (action == CommonActions.ReturnLoanedBook)
        {
            var status = await _loanService.ReturnLoan(selectedLoanDetails.Id);

            Console.WriteLine(EnumHelper.GetDescription(status));
            _currentState = ConsoleState.LoanDetails;
            // reload loan after returning
            selectedLoanDetails = await _loanRepository.GetLoan(selectedLoanDetails.Id);
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
}
