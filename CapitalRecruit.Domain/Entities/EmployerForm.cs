using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalRecruit.Domain.Entities.Questions;

namespace CapitalRecruit.Domain.Entities
{
    public class EmployerForm : BaseEntity
    {
        public string ProgramTitle { get; set; } 
        public string ProgramTitleDescription { get; set; }

        // These fields are set to true by default because they are mandatory to be included in the form.
        public bool IsFirstNameMandatory { get; set; } = true;
        public bool IsLastNameMandatory { get; set; } = true;
        public bool IsEmailMandatory { get; set; } = true;

        // These fields are false by default, This allows the frontend developers
        // to render the fields accordingly
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
        public virtual List<Question> Questions { get; set; }

        // This is lists of candidates is added for an employer to be able to accesss the record of canditate's
        // applications for a particular program
        public List<CandidateForm> Candidates { get; set; }
    }
}
