using System.ComponentModel;

namespace Library.ApplicationCore.Enums;

public enum LoanReturnStatus
{
    [Description("Book was successfully returned.")]
    Success,

    [Description("Loan not found.")]
    LoanNotFound,

    [Description("Cannot return book as the book is already returned.")]
    AlreadyReturned,

    [Description("Cannot return book due to an error.")]
    Error
}