
using Fintcs.Data.Entities;

namespace Fintcs.Services;

public interface ILoanService
{
    Task<IEnumerable<Loan>> GetAllLoansAsync();
    Task<Loan?> GetLoanByIdAsync(Guid id);
    Task<Loan> CreateLoanAsync(Loan loan);
    Task<Loan> UpdateLoanAsync(Loan loan);
    Task DeleteLoanAsync(Guid id);
    Task<IEnumerable<Loan>> GetLoansBySocietyAsync(Guid societyId);
    Task<IEnumerable<Loan>> GetLoansByMemberAsync(Guid memberId);
}
