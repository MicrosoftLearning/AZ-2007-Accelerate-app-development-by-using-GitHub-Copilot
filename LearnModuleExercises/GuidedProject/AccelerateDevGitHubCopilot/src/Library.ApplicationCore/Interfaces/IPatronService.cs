using Library.ApplicationCore.Enums;

public interface IPatronService
{
    Task<MembershipRenewalStatus> RenewMembership(int patronId);
}
