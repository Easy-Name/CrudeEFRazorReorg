using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    /* public interface IStudentRepository
     {
         Task<List<Student>> OnGetAsync();


         Task<Student> GetByIdAsync(int id);

         Task DeleteAsync(Student student);

         Task CreateAsync(Student student);

         void Update(Student student);

         Task SaveChangesAsync();

         bool StudentExists(int id);
     }
 }*/

    //as interfaces são como se fossem o contrato do método que herda elas. Se o método que herda ela não tiver o método da interface, dará erro+


    public interface IStudentRepository : IBaseRepository<Student>
    {
    }
}
