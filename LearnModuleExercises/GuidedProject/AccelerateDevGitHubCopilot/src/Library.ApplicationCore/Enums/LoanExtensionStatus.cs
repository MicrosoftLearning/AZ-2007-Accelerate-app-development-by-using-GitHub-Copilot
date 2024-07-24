using System.ComponentModel;

namespace Library.ApplicationCore.Enums;

public enum LoanExtensionStatus
{
    [Description("Book loan extension was successful.")]
    Success,

    [Description("Loan not found.")]
    LoanNotFound,

    [Description("Cannot extend book loan as it already has expired. Return the book instead.")]
    LoanExpired,

    [Description("Cannot extend book loan due to expired patron's membership.")]
    MembershipExpired,

    [Description("Cannot extend book loan as the book is already returned.")]
    LoanReturned,

    [Description("Cannot extend book loan due to an error.")]
    Error
}