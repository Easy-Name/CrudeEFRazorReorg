using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;

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
            bool namevalidation = ValidateName(student);
            bool existEmail = ExistsEmail(student.Email);

            if (namevalidation && !existEmail)
            {
                await _studentRepository.CreateAsync(student);
                //return true;
            }
            else if (existEmail)
            {
                throw new Exception("E-Mail already in use");
            }
            else if (!namevalidation)
            {
                throw new Exception($"Name shorter than {NameLenght} characters");
            }
        }

        public virtual async Task<List<Student>> OnGetAsync()
        {
            //no validation required
            return await _studentRepository.OnGetAsync();
        }

        public virtual async Task<Student> GetByIdAsync(int id)
        {
            bool validation = ValidateID(id);
            if (validation)
            {
                try
                {
                    return await _studentRepository.GetByIdAsync(id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("id must be above 0");
            }

        }
        public virtual async Task DeleteAsync(Student student)
        {
            bool validation = Exists(student.Id);

            if (validation)
            {
                try
                {
                    await _studentRepository.DeleteAsync(student);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("Student does not exist");
            }
        }

        public virtual async Task SaveChangesAsync()
        {
            //no validation required
            await _studentRepository.SaveChangesAsync();
        }

        public virtual void Update(Student student)
        {
            bool namevalidation = ValidateName(student);
            bool existEmail = ExistsEmail(student.Email);

            if (namevalidation && !existEmail)
            {
                 _studentRepository.Update(student);
                //return true;
            }
            else if (existEmail)
            {
                throw new Exception("E-Mail already in use");
            }
            else if (!namevalidation)
            {
                throw new Exception($"Name shorter than {NameLenght} characters");
            }
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

        private int NameLenght = 5;

        public bool ValidateName(Student student)
        {
            return student.Name.Length > NameLenght;
        }
        public virtual bool ExistsEmail(string email)
        {
            return _studentRepository.ExistsEmail(email);
        }
    }
}
