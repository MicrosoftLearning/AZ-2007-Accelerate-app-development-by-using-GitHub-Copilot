using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.ApplicationCore.Enums;

public class LoanService : ILoanService
{
    private ILoanRepository _loanRepository;

    public LoanService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<LoanReturnStatus> ReturnLoan(int loanId)
    {
        Loan? loan = await _loanRepository.GetLoan(loanId);
        if (loan == null)
        {
            return LoanReturnStatus.LoanNotFound;
        }

        // check if already returned
        if (loan.ReturnDate != null)
        {
            return LoanReturnStatus.AlreadyReturned;
        }

        loan.ReturnDate = DateTime.Now;
        try
        {
            await _loanRepository.UpdateLoan(loan);
            return LoanReturnStatus.Success;
        }
        catch (Exception e)
        {
            return LoanReturnStatus.Error;
        }
    }

    public const int ExtendByDays = 14;

    public async Task<LoanExtensionStatus> ExtendLoan(int loanId)
    {
        var loan = await _loanRepository.GetLoan(loanId);

        if (loan == null)
            return LoanExtensionStatus.LoanNotFound;

        // Check if patron's membership is expired
        if (loan.Patron!.MembershipEnd < DateTime.Now)
            return LoanExtensionStatus.MembershipExpired;

        if (loan.ReturnDate != null)
            return LoanExtensionStatus.LoanReturned;

        if (loan.DueDate < DateTime.Now)
            return LoanExtensionStatus.LoanExpired;

        loan.DueDate = loan.DueDate.AddDays(ExtendByDays);
        try
        {
            await _loanRepository.UpdateLoan(loan);
            return LoanExtensionStatus.Success;
        }
        catch (Exception e)
        {
            return LoanExtensionStatus.Error;
        }
    }
}