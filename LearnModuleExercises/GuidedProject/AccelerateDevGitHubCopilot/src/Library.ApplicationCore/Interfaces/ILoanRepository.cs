using Library.ApplicationCore.Entities;

namespace Library.ApplicationCore;

public interface ILoanRepository {
    Task<Loan?> GetLoan(int loanId);
    Task UpdateLoan(Loan loan);
}