using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> OnGetAsync();


        Task<Student> GetByIdAsync(int id);

        Task DeleteAsync(Student student);

        Task CreateAsync(Student student);

    }
}

//as interfaces são como se fossem o contrato do método que herda elas. Se o método que herda ela não tiver o método da interface, dará erro+
