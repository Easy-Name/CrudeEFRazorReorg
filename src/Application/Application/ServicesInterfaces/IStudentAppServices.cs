using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.ServicesInterfaces
{
    public interface IStudentAppServices
    {

        Task CreateAsync(Student student);

        Task<List<Student>> OnGetAsync();

        Task<Student> GetByIdAsync(int id);

        Task DeleteAsync(Student student);

        Task SaveChangesAsync();

        void Update(Student student);

        bool Exists(int id);

    }
}
