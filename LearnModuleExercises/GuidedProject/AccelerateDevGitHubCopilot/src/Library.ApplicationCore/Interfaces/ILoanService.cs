using Library.ApplicationCore.Enums;

public interface ILoanService
{
    Task<LoanReturnStatus> ReturnLoan(int loanId);
    Task<LoanExtensionStatus> ExtendLoan(int loanId);
}