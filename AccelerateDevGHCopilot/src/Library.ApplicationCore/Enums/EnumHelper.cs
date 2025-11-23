using System.Collections.Generic;

namespace Library.ApplicationCore.Enums;

public static class EnumHelper
{
    private static readonly Dictionary<LoanExtensionStatus, string> LoanExtensionStatusDescriptions = new()
    {
        { LoanExtensionStatus.Success, "Book loan extension was successful." },
        { LoanExtensionStatus.LoanNotFound, "Loan not found." },
        { LoanExtensionStatus.LoanExpired, "Cannot extend book loan as it already has expired. Return the book instead." },
        { LoanExtensionStatus.MembershipExpired, "Cannot extend book loan due to expired patron's membership." },
        { LoanExtensionStatus.LoanReturned, "Cannot extend book loan as the book is already returned." },
        { LoanExtensionStatus.Error, "Cannot extend book loan due to an error." }
    };

    private static readonly Dictionary<LoanReturnStatus, string> LoanReturnStatusDescriptions = new()
    {
        { LoanReturnStatus.Success, "Book was successfully returned." },
        { LoanReturnStatus.LoanNotFound, "Loan not found." },
        { LoanReturnStatus.AlreadyReturned, "Cannot return book as the book is already returned." },
        { LoanReturnStatus.Error, "Cannot return book due to an error." }
    };

    private static readonly Dictionary<MembershipRenewalStatus, string> MembershipRenewalStatusDescriptions = new()
    {
        { MembershipRenewalStatus.Success, "Membership renewal was successful." },
        { MembershipRenewalStatus.PatronNotFound, "Patron not found." },
        { MembershipRenewalStatus.TooEarlyToRenew, "It is too early to renew the membership." },
        { MembershipRenewalStatus.LoanNotReturned, "Cannot renew membership due to an outstanding loan." },
        { MembershipRenewalStatus.Error, "Cannot renew membership due to an error." }
    };

    public static string GetDescription<TEnum>(TEnum value) where TEnum : Enum
    {
        return value switch
        {
            LoanExtensionStatus LoanExtensionStatus => LoanExtensionStatusDescriptions.TryGetValue(LoanExtensionStatus, out var descLoanExtensionStatus) ? descLoanExtensionStatus : LoanExtensionStatus.ToString(),
            LoanReturnStatus LoanReturnStatus => LoanReturnStatusDescriptions.TryGetValue(LoanReturnStatus, out var descLoanReturnStatus) ? descLoanReturnStatus : LoanReturnStatus.ToString(),
            MembershipRenewalStatus MembershipRenewalStatus => MembershipRenewalStatusDescriptions.TryGetValue(MembershipRenewalStatus, out var descMembershipRenewalStatus) ? descMembershipRenewalStatus : MembershipRenewalStatus.ToString(),
            _ => value.ToString()
        };
    }
}