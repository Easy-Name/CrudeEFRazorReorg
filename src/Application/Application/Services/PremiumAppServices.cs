using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Repositories;
using NToastNotify;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class PremiumAppServices : IPremiumAppServices
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IToastNotification _toastNotification; //<------------------

        public PremiumAppServices(IPremiumRepository premiumRepository, IToastNotification toastNotification)
        {
            _premiumRepository = premiumRepository;
            _toastNotification = toastNotification;
        }

        public async Task CreateAsync(Premium premium)
        {

            try
            {
                bool namevalidation = ValidateName(premium.Name);
                bool idValidation = ValidateID(premium.Id);
                await _premiumRepository.CreateAsync(premium);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
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
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
                return new Premium();
            }
        }

        public virtual async Task DeleteAsync(Premium premium)
        {

            try
            {
                bool validation = Exists(premium.Id);
                await _premiumRepository.DeleteAsync(premium);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }

        }

        public virtual async Task SaveChangesAsync()
        {
            //no validation required
            await _premiumRepository.SaveChangesAsync();
        }

        public virtual void Update(Premium premium)
        {
            try
            {
                bool namevalidation = ValidateName(premium.Name);
                bool idValidation = ValidateID(premium.Id);
                _premiumRepository.Update(premium);
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

            if (!_premiumRepository.Exists(id))
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

    }
}
