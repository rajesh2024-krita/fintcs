
using Fintcs.Data.Entities;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class SocietyService : ISocietyService
{
    private readonly ISocietyRepository _societyRepository;

    public SocietyService(ISocietyRepository societyRepository)
    {
        _societyRepository = societyRepository;
    }

    public async Task<IEnumerable<Society>> GetAllSocietiesAsync()
    {
        return await _societyRepository.GetAllAsync();
    }

    public async Task<Society?> GetSocietyByIdAsync(Guid id)
    {
        return await _societyRepository.GetByIdAsync(id);
    }

    public async Task<Society> CreateSocietyAsync(Society society)
    {
        society.Id = Guid.NewGuid();
        society.CreatedAt = DateTime.UtcNow;
        return await _societyRepository.CreateAsync(society);
    }

    public async Task<Society> UpdateSocietyAsync(Society society)
    {
        return await _societyRepository.UpdateAsync(society);
    }

    public async Task DeleteSocietyAsync(Guid id)
    {
        await _societyRepository.DeleteAsync(id);
    }
}
