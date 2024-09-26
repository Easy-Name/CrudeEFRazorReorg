using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /*public interface IPremiumRepository
    {
        Task<List<Premium>> OnGetAsync();

        Task<Premium> GetByIdAsync(int id);

        Task DeleteAsync(Premium premium);

        Task CreateAsync(Premium premium);

        Task SaveChangesAsync();

        bool PremiumExists(int id);

        void Update(Premium premium);
    }*/
}

//as interfaces são como se fossem o contrato do método que herda elas. Se o método que herda ela não tiver o método da interface, dará erro


public interface IPremiumRepository : IBaseRepository<Premium>
{

}
