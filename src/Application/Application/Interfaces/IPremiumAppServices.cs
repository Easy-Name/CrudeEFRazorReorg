using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IPremiumAppServices
    {
        Task CreateAsync(PremiumDto premiumDto);

        Task<List<PremiumDtoResponse>> OnGetAsync();

        Task<PremiumDtoResponse> GetByIdAsync(int id);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();

        Task UpdateAsync(PremiumDto premiumDto);

        bool Exists(int id);
    }
}
