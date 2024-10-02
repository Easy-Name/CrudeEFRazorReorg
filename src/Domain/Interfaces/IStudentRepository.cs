using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    //as interfaces são como se fossem o contrato do método que herda elas. Se o método que herda ela não tiver o método da interface, dará erro+
    public interface IStudentRepository : IBaseRepository<Student>
    {
        bool ExistsEmail(string email);
    }
}
