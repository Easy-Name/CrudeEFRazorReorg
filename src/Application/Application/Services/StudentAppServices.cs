using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System.Text.RegularExpressions;


namespace Application.Services
{
    public class StudentAppServices : IStudentAppServices
    {

        private readonly IStudentRepository _studentRepository;

        public StudentAppServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }






        public async Task CreateAsync(StudentDto studentDto)
        {
            try
            {
                ValidateName(studentDto.Name);
                ValidateEmail(studentDto.Email);

                var student = new Student { Name = studentDto.Name, Email = studentDto.Email };

                await _studentRepository.CreateAsync(student);
            }
            catch 
            {
                throw;
            }

        }
        public virtual async Task<List<Student>> OnGetAsync()
        {
            //no validation required
            var students = await _studentRepository.OnGetAsync();

            /*List<StudentDtoResponse> result = new List<StudentDtoResponse>();

            foreach (var student in students) 
            {
            
                result.Add(new StudentDtoResponse { Name = student.Name, Email = student.Email });

            }*/





            return students;
        }

        public virtual async Task<StudentDtoResponse> GetByIdAsync(int id)
        {
            try
            {
                bool validation = ValidateId(id);
                var student = await _studentRepository.GetByIdAsync(id);
                //var studentDtoResponse = new StudentDtoResponse { Name = student.Name, Email = student.Email}
                return new StudentDtoResponse { Name = student.Name, Email = student.Email };
            }
            catch 
            {

                throw;
            }

        }
        public virtual async Task DeleteAsync(int id)
        {
            try
            {
                ValidateId(id);
                var student = await _studentRepository.GetByIdAsync(id);
                await _studentRepository.DeleteAsync(student);
            }
            catch 
            {
                throw;
            }
        }

        public virtual async Task SaveChangesAsync()
        {
            //no validation required
            await _studentRepository.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(int id, StudentDto studentDto)
        {

            try
            {
                ValidateName(studentDto.Name);
				ValidateId(id);

                Student student = new Student();

                student = await _studentRepository.GetByIdAsync(id);

                if (student.Email == studentDto.Email)
                {
                    student.Name = studentDto.Name;
                }
                else 
                {
                    ValidateEmail(studentDto.Email);
                    student.Name = studentDto.Name;
                    student.Email = studentDto.Email;
                }
                _studentRepository.Update(student);
                await SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }

        public bool ValidateId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid ID");
            }

            return true;
        }

        private int NameLenght = 5;

        public void ValidateName(string name)
        {
            string regex = @"^(?!\s*$)[A-Za-zÀ-ÖØ-öø-ÿ'’-]+(?: [A-Za-zÀ-ÖØ-öø-ÿ'’-]+)*$";

            if (name.Length < NameLenght)
                throw new Exception($"Name shorter than {NameLenght} characters");


            if (!Regex.IsMatch(name, regex))
                throw new Exception($"Invalid name format");

        }

        public virtual bool ExistsEmail(string email)
        {
            return _studentRepository.ExistsEmail(email);
        }

        public void ValidateEmail(string email)
        {
            //string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            string regex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var regexOk = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            var emailExist = ExistsEmail(email);

            if (!regexOk)
            {
                throw new Exception($"Invalid e-mail");
            }

            if (emailExist)
            {
                throw new Exception("E-Mail already in use");
            }

        }
    }
}
