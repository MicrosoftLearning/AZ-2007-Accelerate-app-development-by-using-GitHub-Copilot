using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.ApplicationCore.Enums;

public class PatronService : IPatronService
{
    private readonly IPatronRepository _patronRepository;

    public PatronService(IPatronRepository patronRepository)
    {
        _patronRepository = patronRepository;
    }

    public async Task<MembershipRenewalStatus> RenewMembership(int patronId)
    {
        var patron = await _patronRepository.GetPatron(patronId);
        if (patron == null)
            return MembershipRenewalStatus.PatronNotFound;

        // don't allow to renew till 1 month before expiration
        if (patron.MembershipEnd >= DateTime.Now.AddMonths(1))
            return MembershipRenewalStatus.TooEarlyToRenew;

        // don't allow to renew if patron has overdue loans
        if (patron.Loans.Any(l => (l.ReturnDate == null) && l.DueDate < DateTime.Now))
            return MembershipRenewalStatus.LoanNotReturned;

        patron.MembershipEnd = patron.MembershipEnd.AddYears(1);
        try{
            await _patronRepository.UpdatePatron(patron);
            return MembershipRenewalStatus.Success;
        } catch (Exception e) {
            return MembershipRenewalStatus.Error;
        }
    }
}
