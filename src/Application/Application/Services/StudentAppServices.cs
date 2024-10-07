using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using NToastNotify;
using Infrastructure.Data.Repositories;

//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Services
{
    public class StudentAppServices : IStudentAppServices
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IToastNotification _toastNotification; //<------------------

        public StudentAppServices(IStudentRepository studentRepository, IToastNotification toastNotification)
        {
            _studentRepository = studentRepository;
            _toastNotification = toastNotification;
        }

        public async Task CreateAsync(Student student)
        {
            try
            {
                bool namevalidation = ValidateName(student.Name);
                bool emailvalidation = ValidateEmail(student.Email);
                bool idValidation = ValidateID(student.Id);
                await _studentRepository.CreateAsync(student);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }

        }
        public virtual async Task<List<Student>> OnGetAsync()
        {
            //no validation required
            return await _studentRepository.OnGetAsync();
        }

        public virtual async Task<Student> GetByIdAsync(int id)
        {
            try
            {
                bool validation = ValidateID(id);
                return await _studentRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
                return new Student();
            }

        }
        public virtual async Task DeleteAsync(Student student)
        {
            try
            {
                bool validation = Exists(student.Id);
                await _studentRepository.DeleteAsync(student);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }
        }

        public virtual async Task SaveChangesAsync()
        {
            //no validation required
            await _studentRepository.SaveChangesAsync();
        }

        public virtual void Update(Student student)
        {

            try
            {
                bool namevalidation = ValidateName(student.Name);
                bool emailvalidation = ValidateEmail(student.Email);
                bool idValidation = ValidateID(student.Id);
                _studentRepository.Update(student);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }

        }

        public virtual bool Exists(int id)
        {
            bool validation = ValidateID(id);

            if (!validation)
            {
                throw new Exception("Invalid ID");
            }

            if (!_studentRepository.Exists(id))
            {
                throw new Exception("ID does not exist");
            }

            return true;
        }

        public bool ValidateID(int id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid ID");
            }

            return true;
        }

        private int NameLenght = 5;

        public bool ValidateName(string name)
        {
            string regex = @"^(?!\s*$)[A-Za-zÀ-ÖØ-öø-ÿ'’-]+(?: [A-Za-zÀ-ÖØ-öø-ÿ'’-]+)*$";
            if (name.Length < NameLenght)
            {
                throw new Exception($"Name shorter than {NameLenght} characters");
            }
            else if (!Regex.IsMatch(name, regex))
            {
                throw new Exception($"Invalid name format");
            }
            return true;
        }
        public virtual bool ExistsEmail(string email)
        {
            return _studentRepository.ExistsEmail(email);
        }

        public bool ValidateEmail(string email)
        {
            //string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            string regex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var regexOk = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            var emailExist = ExistsEmail(email);

            if (!regexOk) 
            {
                throw new Exception($"Invalid e-mail");
            }

            if(emailExist)
            {
                throw new Exception("E-Mail already in use");
            }

            return true;
        }
    }
}
