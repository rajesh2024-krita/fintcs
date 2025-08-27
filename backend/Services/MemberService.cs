
using Fintcs.Data.Entities;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
        return await _memberRepository.GetAllAsync();
    }

    public async Task<Member?> GetMemberByIdAsync(Guid id)
    {
        return await _memberRepository.GetByIdAsync(id);
    }

    public async Task<Member> CreateMemberAsync(Member member)
    {
        member.Id = Guid.NewGuid();
        member.CreatedAt = DateTime.UtcNow;
        return await _memberRepository.CreateAsync(member);
    }

    public async Task<Member> UpdateMemberAsync(Member member)
    {
        return await _memberRepository.UpdateAsync(member);
    }

    public async Task DeleteMemberAsync(Guid id)
    {
        await _memberRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Member>> GetMembersBySocietyAsync(Guid societyId)
    {
        return await _memberRepository.GetBySocietyIdAsync(societyId);
    }
}
