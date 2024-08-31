using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MfaApi.Modules.Member;

public static class MemberUtils {
    public static Expression<Func<MemberModel, bool>> GetFullNameFilter(string query) {
        return member => EF.Functions.ILike(member.FirstName + " " + member.LastName, $"%{query}%");
    }
}