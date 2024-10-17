using Application.Dtos;
using Application.Dtos.Response;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IPremiumAppServices
    {
        Task CreateAsync(PremiumDto premiumDto);

        Task<List<PremiumDtoResponse>> OnGetAsync();
        Task<List<PremiumDtoRespWStudent>> OnGetAsyncWStudent();

        Task<PremiumDtoResponse> GetByIdAsync(int id);
        Task<PremiumDtoRespWStudent> GetByIdAsyncWStudent(int id);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();

        Task UpdateAsync(PremiumDto premiumDto);

        bool Exists(int id);
    }
}
