
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface IVoucherRepository
{
    Task<IEnumerable<Voucher>> GetAllAsync();
    Task<Voucher?> GetByIdAsync(Guid id);
    Task<Voucher> CreateAsync(Voucher voucher);
    Task<Voucher> UpdateAsync(Voucher voucher);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<Voucher>> GetBySocietyIdAsync(Guid societyId);
}
