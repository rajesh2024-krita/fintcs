
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllAsync();
    Task<Loan?> GetByIdAsync(Guid id);
    Task<Loan> CreateAsync(Loan loan);
    Task<Loan> UpdateAsync(Loan loan);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<Loan>> GetBySocietyIdAsync(Guid societyId);
    Task<IEnumerable<Loan>> GetByMemberIdAsync(Guid memberId);
}
