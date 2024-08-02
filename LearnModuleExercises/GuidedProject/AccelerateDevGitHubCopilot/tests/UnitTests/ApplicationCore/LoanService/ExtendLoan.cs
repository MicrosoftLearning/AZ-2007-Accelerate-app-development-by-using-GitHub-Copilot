using NSubstitute;
using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.ApplicationCore.Enums;

namespace Library.UnitTests.ApplicationCore.LoanServiceTests;

public class ExtendLoanTest
{
    private readonly ILoanRepository _mockLoanRepository;
    private readonly LoanService _loanService;

    public ExtendLoanTest()
    {
        _mockLoanRepository = Substitute.For<ILoanRepository>();
        _loanService = new LoanService(_mockLoanRepository);
    }

    [Fact(DisplayName = "LoanService.ExtendLoan: Extends the loan successfully")]
    public async Task ExtendLoan_ExtendsLoanSuccessfully()
    {
        // Arrange
        var patron = PatronFactory.CreateCurrentPatron();
        var loan = LoanFactory.CreateCurrentLoanForPatron(patron);
        var loanDueDate = loan.DueDate;
        var loanId = loan.Id;
        _mockLoanRepository.GetLoan(loanId).Returns(loan);

        // Act
        LoanExtensionStatus extensionStatus = await _loanService.ExtendLoan(loanId);

        // Assert
        Assert.Equal(LoanExtensionStatus.Success, extensionStatus);
        Assert.Equal(loanDueDate.AddDays(LoanService.ExtendByDays), loan.DueDate);
    }

    [Fact(DisplayName = "LoanService.ExtendLoan: Returns LoanNotFound if loan is not found")]
    public async Task ExtendLoan_ReturnsLoanNotFound()
    {
        // Arrange
        var loanId = 1;
        _mockLoanRepository.GetLoan(loanId).Returns((Loan?)null);

        // Act
        LoanExtensionStatus extensionStatus = await _loanService.ExtendLoan(loanId);

        // Assert
        Assert.Equal(LoanExtensionStatus.LoanNotFound, extensionStatus);
    }

    [Fact(DisplayName = "LoanService.ExtendLoan: Returns MembershipExpired if patron's membership is expired")]
    public async Task ExtendLoan_ReturnsMembershipExpired()
    {
        // Arrange
        var patron = PatronFactory.CreateExpiredPatron();
        var loan = LoanFactory.CreateCurrentLoanForPatron(patron);
        var loanId = loan.Id;
        var loanDueDate = loan.DueDate;
        _mockLoanRepository.GetLoan(loanId).Returns(loan);

        // Act
        LoanExtensionStatus extensionStatus = await _loanService.ExtendLoan(loanId);

        // Assert
        Assert.Equal(LoanExtensionStatus.MembershipExpired, extensionStatus);
        Assert.Equal(loanDueDate, loan.DueDate);
    }

    [Fact(DisplayName = "LoanService.ExtendLoan: Returns LoanReturned if loan is already returned")]
    public async Task ExtendLoan_ReturnsLoanReturned()
    {
        // Arrange
        var patron = PatronFactory.CreateCurrentPatron();
        var loan = LoanFactory.CreateReturnedLoanForPatron(patron);
        var loanId = loan.Id; 
        var loanDueDate = loan.DueDate;
        _mockLoanRepository.GetLoan(loanId).Returns(loan);

        // Act
        LoanExtensionStatus extensionStatus = await _loanService.ExtendLoan(loanId);

        // Assert
        Assert.Equal(LoanExtensionStatus.LoanReturned, extensionStatus);
        Assert.Equal(loanDueDate, loan.DueDate);
    }

    [Fact(DisplayName = "LoanService.ExtendLoan: Returns LoanExpired if loan is already expired")]
    public async Task ExtendLoan_ReturnsLoanExpired()
    {
        // Arrange
        var patron = PatronFactory.CreateCurrentPatron();
        var loan = LoanFactory.CreateExpiredLoanForPatron(patron);
        var loanId = loan.Id; 
        var loanDueDate = loan.DueDate;
        _mockLoanRepository.GetLoan(loanId).Returns(loan);

        // Act
        LoanExtensionStatus extensionStatus = await _loanService.ExtendLoan(loanId);

        // Assert
        Assert.Equal(LoanExtensionStatus.LoanExpired, extensionStatus);
        Assert.Equal(loanDueDate, loan.DueDate);
    }
}
