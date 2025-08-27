
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllAsync();
    Task<Member?> GetByIdAsync(Guid id);
    Task<Member> CreateAsync(Member member);
    Task<Member> UpdateAsync(Member member);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<Member>> GetBySocietyIdAsync(Guid societyId);
    Task<Member?> GetByMemberCodeAsync(string memberCode);
}
