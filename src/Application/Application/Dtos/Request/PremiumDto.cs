﻿

namespace Application.Dtos
{
    public class PremiumDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }

        public int StudentId { get; set; }

        public PremiumDto(PremiumDtoResponse premiumDtoResp)
        {
            StartDate = premiumDtoResp.StartDate;
            EndtDate = premiumDtoResp.EndtDate;
            Id = premiumDtoResp.Id;
            StudentId = premiumDtoResp.StudentId;
            Name = premiumDtoResp.Name;
        }

        public PremiumDto()
        {
        }

    }
}
