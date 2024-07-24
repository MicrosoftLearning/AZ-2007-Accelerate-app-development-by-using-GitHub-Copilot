namespace Library.ApplicationCore.Entities;

public class Patron
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime MembershipEnd { get; set; }
    public DateTime MembershipStart { get; set; }
    public string? ImageName { get; set; }
    public ICollection<Loan> Loans { get; set; } = new HashSet<Loan>();
}
