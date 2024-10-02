﻿using Application.ServicesInterfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Repositories;

namespace Application
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
                await _premiumRepository.CreateAsync(premium);
            }
            else if (!namevalidation)
            {
                throw new Exception("Name shorter than 5 characters");
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
            return await _premiumRepository.GetByIdAsync(id);
        }

        public virtual async Task DeleteAsync(Premium premium)
        {
            bool validation = Exists(premium.Id);
            await _premiumRepository.DeleteAsync(premium);
        }

        public virtual async Task SaveChangesAsync()
        {
            //no validation required
            await _premiumRepository.SaveChangesAsync();
        }

        public virtual void Update(Premium premium)
        {
            bool validation = ValidateName(premium);
            _premiumRepository.Update(premium);
        }

        public virtual bool Exists(int id)
        {
            bool validation = ValidateID(id);
            return _premiumRepository.Exists(id);
        }

        public bool ValidateID(int id)
        {
            var valid1 = _studentRepository.Exists(id);
            var valid2 = id > 0;

            if (valid1 && valid2)
            {
                return true;
            }
            else if (!valid1)
            {
                throw new Exception("Student does not exist");
            }
            else
            {
                throw new Exception("Invalid student");
            }
        }

        private int NameLenght = 5;

        public bool ValidateName(Premium Premium)
        {
            return Premium.Name.Length > NameLenght;
        }

        public virtual bool ExistsEmail(string email)
        {
            return _premiumRepository.ExistsEmail(email);
        }








    }
}
