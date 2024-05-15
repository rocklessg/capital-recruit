using CapitalRecruit.Domain.Enums;

namespace CapitalRecruit.Infrastructure.Dtos.ResponseDto
{
    public class CandidateFormModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public string CurrentResidence { get; set; }

        public string IdNumber { get; set; }

        public Gender Gender { get; set; }
    }
}
