using Application.ServicesInterfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Repositories;

namespace Application
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
            //TODO Criar validações para todos os métods que vou criar. Também criar as interfaces
            bool validation = ValidateName(premium);
            await _premiumRepository.CreateAsync(premium);
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
            return id > 0;
        }

        private int NameLenght = 6;

        public bool ValidateName(Premium Premium)
        {
            return Premium.Name.Length > NameLenght;
        }











    }
}
