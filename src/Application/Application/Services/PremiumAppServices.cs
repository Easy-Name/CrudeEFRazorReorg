using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class PremiumAppServices : IPremiumAppServices
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IStudentRepository _studentRepository; //IS THIS POSSIBLE? SHOULD I HAVE ONLY PREMIUM RELATED STUFF HERE?

        public PremiumAppServices(IPremiumRepository premiumRepository, IStudentRepository studentRepository)
        {
            _premiumRepository = premiumRepository;
            _studentRepository = studentRepository;
        }

        public async Task CreateAsync(Premium premium)
        {
            //TODO Criar validações para todos os métods que vou criar. Também criar as interfaces

            bool namevalidation = ValidateName(premium.Name);

            try
            {
                bool validateID = ValidateID(premium.Id);
            }
            catch
            {
                throw;
            }


            if (namevalidation)
            {
                await _premiumRepository.CreateAsync(premium);
            }
            else if (!namevalidation)
            {
                throw new Exception($"Name shorter than {NameLenght} characters");
            }
        }

        public virtual async Task<List<Premium>> OnGetAsync()
        {
            //no validation required
            return await _premiumRepository.OnGetAsync();
        }

        public virtual async Task<Premium> GetByIdAsync(int id)
        {

            bool validation = ValidateID(id);
            if (validation)
            {
                try
                {
                    return await _premiumRepository.GetByIdAsync(id);
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

        public virtual async Task DeleteAsync(Premium premium)
        {

            bool validation = Exists(premium.Id);

            if (validation)
            {
                try
                {
                    await _premiumRepository.DeleteAsync(premium);
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
            await _premiumRepository.SaveChangesAsync();
        }

        public virtual void Update(Premium premium)
        {
            bool namevalidation = ValidateName(premium);

            try
            {
                bool validateID = ValidateID(premium.StudentId);
            }
            catch
            {
                throw;
            }


            if (namevalidation)
            {
                _premiumRepository.Update(premium);
            }
            else if (!namevalidation)
            {
                throw new Exception($"Name shorter than {NameLenght} characters");
            }
        }


        public virtual bool Exists(int id)
        {
            bool validation = ValidateID(id);
            return _premiumRepository.Exists(id);
        }

        public bool ValidateID(int id)
        {
            var valid = id > 0;

            if (valid)
            {
                return true;
            }
            else             
            {
                throw new Exception("Invalid premium");
            }
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
            return _premiumRepository.ExistsEmail(email);
        }

    }
}
