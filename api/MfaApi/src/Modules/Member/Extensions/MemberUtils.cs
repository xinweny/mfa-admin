namespace MfaApi.Modules.Member;

public static class MemberUtils {
    public static bool DoesFullNameContainQuery(this MemberModel member, string query) {
        string[] fullNames = [
            $"{member.FirstName} {member.LastName}",
            $"{member.LastName} {member.FirstName}"
        ];

        return fullNames.Any(n => 
            n.Contains(query, StringComparison.CurrentCultureIgnoreCase)
        );
    }
}