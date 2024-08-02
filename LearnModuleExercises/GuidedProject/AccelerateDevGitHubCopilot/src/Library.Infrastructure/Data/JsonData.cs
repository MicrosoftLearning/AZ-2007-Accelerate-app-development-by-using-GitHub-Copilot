using System.Text.Json;
using Library.ApplicationCore.Entities;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure.Data;

public class JsonData
{
    public List<Author>? Authors { get; set; }
    public List<Book>? Books { get; set; }
    public List<BookItem>? BookItems { get; set; }
    public List<Patron>? Patrons { get; set; }
    public List<Loan>? Loans { get; set; }

    private readonly string _authorsPath;
    private readonly string _booksPath;
    private readonly string _bookItemsPath;
    private readonly string _patronsPath;
    private readonly string _loansPath;

    public JsonData(IConfiguration configuration)
    {
        var section = configuration.GetSection("JsonPaths");
        _authorsPath = section["Authors"] ?? Path.Combine("Json", "Authors.json");
        _booksPath = section["Books"] ?? Path.Combine("Json", "Books.json");
        _bookItemsPath = section["BookItems"] ?? Path.Combine("Json", "BookItems.json");
        _patronsPath = section["Patrons"] ?? Path.Combine("Json", "Patrons.json");
        _loansPath = section["Loans"] ?? Path.Combine("Json", "Loans.json");
    }

    public async Task EnsureDataLoaded()
    {
        if (Patrons == null)
        {
            await LoadData();
        }
    }

    public async Task LoadData()
    {
        Authors = await LoadJson<List<Author>>(_authorsPath);
        Books = await LoadJson<List<Book>>(_booksPath);
        BookItems = await LoadJson<List<BookItem>>(_bookItemsPath);
        Patrons = await LoadJson<List<Patron>>(_patronsPath);
        Loans = await LoadJson<List<Loan>>(_loansPath);
    }

    public async Task SaveLoans(IEnumerable<Loan> loans)
    {
        List<Loan> loanList = new List<Loan>();
        foreach (var l in loans)
        {
            Loan loan = new Loan
            {
                // making sure only a subset of properties is set and saved
                Id = l.Id,
                BookItemId = l.BookItemId,
                PatronId = l.PatronId,
                LoanDate = l.LoanDate,
                DueDate = l.DueDate,
                ReturnDate = l.ReturnDate
            };
            loanList.Add(loan);
        }
        await SaveJson(_loansPath, loanList);
    }

    public async Task SavePatrons(IEnumerable<Patron> patrons)
    {
        await SaveJson(_patronsPath, patrons.Select(p => new Patron
        {
            Id = p.Id,
            Name = p.Name,
            MembershipStart = p.MembershipStart,
            MembershipEnd = p.MembershipEnd,
            ImageName = p.ImageName,
        }).ToList());
    }

    private async Task SaveJson<T>(string filePath, T data)
    {
        using (FileStream jsonStream = File.Create(filePath))
        {
            await JsonSerializer.SerializeAsync(jsonStream, data);
        }
    }

    public List<Patron> GetPopulatedPatrons(IEnumerable<Patron> patrons)
    {
        List<Patron> populated = new List<Patron>();
        foreach (Patron patron in patrons)
        {
            populated.Add(GetPopulatedPatron(patron));
        }
        return populated;
    }

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

    public Loan GetPopulatedLoan(Loan l)
    {
        Loan populated = new Loan
        {
            Id = l.Id,
            BookItemId = l.BookItemId,
            PatronId = l.PatronId,
            LoanDate = l.LoanDate,
            DueDate = l.DueDate,
            ReturnDate = l.ReturnDate
        };

        foreach (BookItem bi in BookItems!)
        {
            if (bi.Id == l.BookItemId)
            {
                populated.BookItem = GetPopulatedBookItem(bi);
                break;
            }
        }

        foreach (Patron p in Patrons!)
        {
            if (p.Id == l.PatronId)
            {
                populated.Patron = p;
                break;
            }
        }

        return populated;
    }

    public BookItem GetPopulatedBookItem(BookItem bi)
    {
        BookItem populated = new BookItem
        {
            Id = bi.Id,
            BookId = bi.BookId,
            AcquisitionDate = bi.AcquisitionDate,
            Condition = bi.Condition
        };

        foreach (Book b in Books!)
        {
            if (b.Id == bi.BookId)
            {
                populated.Book = GetPopulatedBook(b);
                break;
            }
        }

        return populated;
    }

    public Book GetPopulatedBook(Book b)
    {
        Book populated = new Book
        {
            Id = b.Id,
            Title = b.Title,
            AuthorId = b.AuthorId,
            Genre = b.Genre,
            ISBN = b.ISBN,
            ImageName = b.ImageName
        };

        foreach (Author a in Authors!)
        {
            if (a.Id == b.AuthorId)
            {
                populated.Author = new Author
                {
                    Id = a.Id,
                    Name = a.Name
                };
                break;
            }
        }

        return populated;
    }

    private async Task<T?> LoadJson<T>(string filePath)
    {
        using (FileStream jsonStream = File.OpenRead(filePath))
        {
            return await JsonSerializer.DeserializeAsync<T>(jsonStream);
        }
    }

}
