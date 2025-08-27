
using Fintcs.Data.Entities;

namespace Fintcs.Services;

public interface IMemberService
{
    Task<IEnumerable<Member>> GetAllMembersAsync();
    Task<Member?> GetMemberByIdAsync(Guid id);
    Task<Member> CreateMemberAsync(Member member);
    Task<Member> UpdateMemberAsync(Member member);
    Task DeleteMemberAsync(Guid id);
    Task<IEnumerable<Member>> GetMembersBySocietyAsync(Guid societyId);
}
