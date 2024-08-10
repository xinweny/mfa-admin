using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipRepository {
    Task<IEnumerable<GetMembershipsResponseDto>> GetMemberships(GetMembershipsRequestDto dto);
    Task<Member> GetMembershipById(int id);
    Task<Member> CreateMembership(Membership membership);
    Task<Member> UpdateMembership(Member member, UpdateMemberRequestDto dto);
    Task DeleteMembership(Member member);
}