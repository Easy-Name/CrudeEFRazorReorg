using Application.Dtos;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Repositories;
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


        public async Task CreateAsync(PremiumDto premiumDto)
        {

            try
            {
                ValidateName(premiumDto.Name);
                var premium = new Premium { Name = premiumDto.Name, StartDate = premiumDto.StartDate, EndtDate = premiumDto.EndtDate, StudentId = premiumDto.StudentId};
                await _premiumRepository.CreateAsync(premium);
            }
            catch 
            {
                throw;
            }
        }

        public virtual async Task<List<PremiumDtoResponse>> OnGetAsync()
        {
            
            var premium = await _premiumRepository.OnGetAsync();

            //no validation required
            var result = new List<PremiumDtoResponse>();

            foreach (var item in premium)
            {
                result.Add(new PremiumDtoResponse { Id = item.Id, Name = item.Name, StartDate = item.StartDate, EndtDate = item.EndtDate, StudentId = item.StudentId });
            }

            return result;
        }

        public virtual async Task<PremiumDtoResponse> GetByIdAsync(int id)
        {

            try
            {
                ValidateID(id);
                var entity = await _premiumRepository.GetByIdAsync(id);
                return new PremiumDtoResponse { Id = entity.Id, Name = entity.Name, StartDate = entity.StartDate, EndtDate = entity.EndtDate, StudentId = entity.StudentId };
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
                Exists(id);
                var premium = await _premiumRepository.GetByIdAsync(id);
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

        public virtual async Task UpdateAsync(PremiumDto premiumDto)
        {
            try
            {
                ValidateName(premiumDto.Name);
                var originalPremium = await _premiumRepository.GetByIdAsync(premiumDto.Id);
                var premium = new Premium { Id = originalPremium.Id, Name = originalPremium.Name, StartDate = originalPremium.StartDate, EndtDate = originalPremium.EndtDate, StudentId = originalPremium.StudentId };

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
