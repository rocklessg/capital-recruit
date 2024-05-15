using CapitalRecruit.Domain.Entities.Questions;
using System.ComponentModel.DataAnnotations;

namespace CapitalRecruit.Infrastructure.Dtos.ResponseDto
{
    // CreateProgram class represents the data transfer object (DTO) used for creating a new program
    public class EmployerFormResponseDto
    {
        [Required]
        public string ProgramTitle { get; set; }

        [Required]
        public string ProgramTitleDescription { get; set; }
        public bool IsFirstNameMandatory { get; set; } = true;
        public bool IsLastNameMandatory { get; set; } = true;
        public bool IsEmailMandatory { get; set; } = true;
        public bool IsPhoneInternal { get; set; }
        public bool HidePhone { get; set; }
        public bool IsNationalityInternal { get; set; }
        public bool HideNationality { get; set; }
        public bool IsCurrentResidenceInternal { get; set; }
        public bool HideCurrentResidence { get; set; }
        public bool IsIDNumberInternal { get; set; }
        public bool HideIDNumber { get; set; }
        public bool IsDateOfBirthInternal { get; set; }
        public bool HideDateOfBirth { get; set; }
        public bool IsGenderInternal { get; set; }
        public bool HideGender { get; set; }
        public List<Question> Questions { get; set; }
    }
}
