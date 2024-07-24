using Library.ApplicationCore.Enums;

//namespace Library.ApplicationCore.Services;

public interface IPatronService
{
    Task<MembershipRenewalStatus> RenewMembership(int patronId);
}