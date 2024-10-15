using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IStudentAppServices//: IBaseAppServices<StudentDto,StudentDtoResponse, Student>
    {

        Task CreateAsync(StudentDto dtoRequest);

        Task<List<StudentDtoResponse>> OnGetAsync();

        Task<StudentDtoResponse> GetByIdAsync(int id);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();

		Task UpdateAsync(StudentDto studentDto);

    }
}
