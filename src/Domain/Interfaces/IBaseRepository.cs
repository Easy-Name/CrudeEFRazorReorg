using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<List<TEntity>> OnGetAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task DeleteAsync(TEntity entity);

        Task CreateAsync(TEntity entity);

        void Update(TEntity entity);

        Task SaveChangesAsync();

        bool Exists(int id);

        bool ExistsEmail(string email);
    }
}

//as interfaces são como se fossem o contrato do método que herda elas. Se o método que herda ela não tiver o método da interface, dará erro+
