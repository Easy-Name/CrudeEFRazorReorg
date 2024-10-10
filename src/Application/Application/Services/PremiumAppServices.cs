using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class PremiumAppServices : IPremiumAppServices
    {
        private readonly IPremiumRepository _premiumRepository;

        public PremiumAppServices(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        public async Task CreateAsync(Premium premium)
        {

            try
            {
                bool namevalidation = ValidateName(premium.Name);

                await _premiumRepository.CreateAsync(premium);
            }
            catch 
            {
                throw;
            }
        }

        public virtual async Task<List<Premium>> OnGetAsync()
        {
            //no validation required
            return await _premiumRepository.OnGetAsync();
        }

        public virtual async Task<Premium> GetByIdAsync(int id)
        {

            try
            {
                bool validation = ValidateID(id);
                return await _premiumRepository.GetByIdAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task DeleteAsync(Premium premium)
        {

            try
            {
                bool validation = Exists(premium.Id);
                await _premiumRepository.DeleteAsync(premium);
            }
            catch 
            {
                throw;
            }

        }

        public virtual async Task SaveChangesAsync()
        {
            //no validation required
            await _premiumRepository.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(Premium premium)
        {
            try
            {
                bool namevalidation = ValidateName(premium.Name);

                _premiumRepository.Update(premium);
                await SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
        }


        public virtual bool Exists(int id)
        {
            bool validation = ValidateID(id);

            if (!validation)
            {
                throw new Exception("Invalid ID");
            }

            if (!_premiumRepository.Exists(id))
            {
                throw new Exception("ID does not exist");
            }

            return true;
        }

        public bool ValidateID(int id)
        {
            if (id <= 0)
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

    }
}
