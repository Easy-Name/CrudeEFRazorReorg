using Domain.Models;

namespace Application.Interfaces
{
    public interface IPremiumAppServices
    {
        Task CreateAsync(Premium premium);

        Task<List<Premium>> OnGetAsync();

        Task<Premium> GetByIdAsync(int id);

        Task DeleteAsync(Premium premium);

        Task SaveChangesAsync();

        void Update(Premium premium);

        bool Exists(int id);
    }
}
