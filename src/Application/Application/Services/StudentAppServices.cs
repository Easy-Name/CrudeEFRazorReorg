using Application.ServicesInterfaces;
using Domain.Interfaces;
using Domain.Models;


namespace Application.Services
{
    public class StudentAppServices : IStudentAppServices
    {

        private readonly IStudentRepository _studentRepository;

        public StudentAppServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateAsync(Student student)
        {
            //TODO Criar validações para todos os métods que vou criar. Também criar as interfaces
            bool validation = ValidateName(student);
            if (validation)
            {
                await _studentRepository.CreateAsync(student);
            }
            else 
            {
                throw new Exception();
            }
            //await _studentRepository.CreateAsync(student);
        }

        public virtual async Task<List<Student>> OnGetAsync()
        {
            //no validation required
            return await _studentRepository.OnGetAsync();
        }

        public virtual async Task<Student> GetByIdAsync(int id)
        {
            bool validation = ValidateID(id);
            return await _studentRepository.GetByIdAsync(id);
        }

        public virtual async Task DeleteAsync(Student student)
        {
            bool validation = Exists(student.Id);
            await _studentRepository.DeleteAsync(student);
        }

        public virtual async Task SaveChangesAsync()
        {
            //no validation required
            await _studentRepository.SaveChangesAsync();
        }

        public virtual void Update(Student student)
        {
            bool validation = ValidateName(student);
            _studentRepository.Update(student);
        }

        public virtual bool Exists(int id)
        {
            bool validation = ValidateID(id);
            return _studentRepository.Exists(id);
        }

        public bool ValidateID(int id) 
        {
            return id > 0;
        }

        private int NameLenght = 6;

        public bool ValidateName(Student student) 
        {
            return student.Name.Length > NameLenght;
        }

    }
}
