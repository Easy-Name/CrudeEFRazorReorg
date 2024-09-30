using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PremiumRepository : BaseRepository<Premium>, IPremiumRepository
    {
        //private readonly ApplicationDbContext _context;

        public PremiumRepository(ApplicationDbContext context) : base(context) //base é o construtor da classe base (BaseRepository). Nisso ele pega o context que a applicacaõ mandou e passa para o construtor da classe base //preciso mandar o contexto para o base repository " base(context)" pois é lá que os métodos rodam 
        {

        }

        public override async Task CreateAsync(Premium entity)
        {
            var e = await GetByIdAsync(entity.Id);
            if (e == null)
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
            }
        }
    }


}
