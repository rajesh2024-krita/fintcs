
using Fintcs.Data.Entities;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class VoucherService : IVoucherService
{
    private readonly IVoucherRepository _voucherRepository;

    public VoucherService(IVoucherRepository voucherRepository)
    {
        _voucherRepository = voucherRepository;
    }

    public async Task<IEnumerable<Voucher>> GetAllVouchersAsync()
    {
        return await _voucherRepository.GetAllAsync();
    }

    public async Task<Voucher?> GetVoucherByIdAsync(Guid id)
    {
        return await _voucherRepository.GetByIdAsync(id);
    }

    public async Task<Voucher> CreateVoucherAsync(Voucher voucher)
    {
        voucher.Id = Guid.NewGuid();
        voucher.CreatedAt = DateTime.UtcNow;
        return await _voucherRepository.CreateAsync(voucher);
    }

    public async Task<Voucher> UpdateVoucherAsync(Voucher voucher)
    {
        return await _voucherRepository.UpdateAsync(voucher);
    }

    public async Task DeleteVoucherAsync(Guid id)
    {
        await _voucherRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Voucher>> GetVouchersBySocietyAsync(Guid societyId)
    {
        return await _voucherRepository.GetBySocietyIdAsync(societyId);
    }
}
