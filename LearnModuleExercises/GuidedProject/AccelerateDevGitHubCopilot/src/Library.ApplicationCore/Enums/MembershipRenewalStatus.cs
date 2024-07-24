using System.ComponentModel;

namespace Library.ApplicationCore.Enums;

public enum MembershipRenewalStatus
{
    [Description("Membership renewal was successful.")]
    Success,

    [Description("Patron not found.")]
    PatronNotFound,

    [Description("It is too early to renew the membership.")]
    TooEarlyToRenew,

    [Description("Cannot renew membership due to an outstanding loan.")]
    LoanNotReturned,

    [Description("Cannot renew membership due to an error.")]
    Error
}
