using Library.ApplicationCore.Entities;

public static class PatronFactory
{
    public static int patronId = 42;
    
    public static Patron CreateCurrentPatron()
    {
        return new Patron
        {
            Id = patronId++,
            Name = "John Doe",
            MembershipEnd = DateTime.Now.AddDays(1),
            Loans = new List<Loan>()
        };
    }

        public static Patron CreateTooEarlyToRenewPatron()
    {
        return new Patron
        {
            Id = patronId++,
            Name = "John Doe",
            MembershipEnd = DateTime.Now.AddMonths(2),
            Loans = new List<Loan>()
        };
    }
    
    public static Patron CreateExpiredPatron()
    {
        return new Patron
        {
            Id = patronId++,
            Name = "John Doe",
            MembershipEnd = DateTime.Now.AddMonths(-2),
            Loans = new List<Loan>()
        };
    }
}