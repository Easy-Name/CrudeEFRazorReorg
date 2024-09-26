using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{//abstract makes it so that it can't be instantiated, only be implemented by other classes
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity //generic contraint (TEntity must use an entity as a generic arguments)
    {

        protected readonly ApplicationDbContext _context;
        
        public DbSet<TEntity> entity => _context.Set<TEntity>();

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<TEntity>> OnGetAsync()
        {
            return await entity.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        { 
           return await entity.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
        }

        public bool Exists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }



    }
}
