
using Fintcs.Data.Entities;

namespace Fintcs.Services;

public interface IVoucherService
{
    Task<IEnumerable<Voucher>> GetAllVouchersAsync();
    Task<Voucher?> GetVoucherByIdAsync(Guid id);
    Task<Voucher> CreateVoucherAsync(Voucher voucher);
    Task<Voucher> UpdateVoucherAsync(Voucher voucher);
    Task DeleteVoucherAsync(Guid id);
    Task<IEnumerable<Voucher>> GetVouchersBySocietyAsync(Guid societyId);
}
