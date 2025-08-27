
using Fintcs.Data.Entities;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;

    public LoanService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<IEnumerable<Loan>> GetAllLoansAsync()
    {
        return await _loanRepository.GetAllAsync();
    }

    public async Task<Loan?> GetLoanByIdAsync(Guid id)
    {
        return await _loanRepository.GetByIdAsync(id);
    }

    public async Task<Loan> CreateLoanAsync(Loan loan)
    {
        loan.Id = Guid.NewGuid();
        loan.CreatedAt = DateTime.UtcNow;
        return await _loanRepository.CreateAsync(loan);
    }

    public async Task<Loan> UpdateLoanAsync(Loan loan)
    {
        return await _loanRepository.UpdateAsync(loan);
    }

    public async Task DeleteLoanAsync(Guid id)
    {
        await _loanRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Loan>> GetLoansBySocietyAsync(Guid societyId)
    {
        return await _loanRepository.GetBySocietyIdAsync(societyId);
    }

    public async Task<IEnumerable<Loan>> GetLoansByMemberAsync(Guid memberId)
    {
        return await _loanRepository.GetByMemberIdAsync(memberId);
    }
}
