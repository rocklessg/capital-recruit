using System.ComponentModel.DataAnnotations;
using CapitalRecruit.Domain.Entities;
using CapitalRecruit.Domain.Enums;

namespace CapitalRecruit.Infrastructure.Dtos.RequestsDto
{
    public class CreateCandidateFormRequestDto
    {
        [Required(ErrorMessage = "Fill in The First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fill in The Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Fill in The EmailAddress Value")]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public List<CandidateAnswer> Answers { get; set; }
    }
}
