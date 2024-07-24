namespace Library.ApplicationCore.Entities;

public class BookItem
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public string? Condition { get; set; }
    public Book? Book { get; set; }
}
