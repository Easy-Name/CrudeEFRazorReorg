

using Domain.Models;

namespace Application.Dtos
{
    public class StudentDtoResponse 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public StudentDtoResponse(Student student)
        {
            Id = student.Id; 
            Name = student.Name; 
            Email = student.Email;
        }
        public StudentDtoResponse()
        {
        }
    }
}
