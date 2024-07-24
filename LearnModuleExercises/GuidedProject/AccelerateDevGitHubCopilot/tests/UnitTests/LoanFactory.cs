using Library.ApplicationCore.Entities;

public static class LoanFactory
{
    public static int loanId = 777;

    public static Loan CreateReturnedLoanForPatron(Patron patron)
    {
        return new Loan
        {
            Id = loanId++,
            DueDate = DateTime.Now.AddDays(1),
            ReturnDate = DateTime.Now.AddDays(-1),
            PatronId = patron.Id,
            Patron = patron
        };
    }

    public static Loan CreateCurrentLoanForPatron(Patron patron)
    {
        return new Loan
        {
            Id = loanId++,
            DueDate = DateTime.Now.AddDays(1),
            ReturnDate = null,
            PatronId = patron.Id,
            Patron = patron
        };
    }

    public static Loan CreateExpiredLoanForPatron(Patron patron)
    {
        return new Loan
        {
            Id = loanId++,
            DueDate = DateTime.Now.AddDays(-1),
            ReturnDate = null,
            PatronId = patron.Id,
            Patron = patron
        };
    }
}