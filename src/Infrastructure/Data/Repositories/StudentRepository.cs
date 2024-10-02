using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository //essa é a classe concreta (onde de fato as coisas acontecem, onde existem os métodos e onde os comportamentos são executados)
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public virtual bool ExistsEmail(string email)
        {
            return _context.Students.Any(e => e.Email == email);
        }
    }
}
