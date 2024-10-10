using Application.Dtos;
using Application.Dtos.Request;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IStudentAppServices
    {

        Task CreateAsync(StudentDto studentDto);

        Task<List<Student>> OnGetAsync();

        Task<StudentDtoResponse> GetByIdAsync(int id);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();

		Task UpdateAsync(int id, StudentDto studentDto);

    }
}
