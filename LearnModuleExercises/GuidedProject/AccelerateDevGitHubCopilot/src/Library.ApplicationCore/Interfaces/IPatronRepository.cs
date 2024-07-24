using Library.ApplicationCore.Entities;

namespace Library.ApplicationCore;

public interface IPatronRepository {
    Task<Patron?> GetPatron(int patronId);
    Task<List<Patron>> SearchPatrons(string searchInput);
    Task UpdatePatron(Patron patron);
}

