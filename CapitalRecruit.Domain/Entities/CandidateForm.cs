using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CapitalRecruit.Domain.Enums;

namespace CapitalRecruit.Domain.Entities
{
    public class CandidateForm : BaseEntity
    {
        [ForeignKey("EmployerForm")]
        public string ProgramId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        // This field is aimed at implementing soft delete
        public bool IsActive { get; set; } = true;

        //This field will hold a Serialised collections of candidate answers
        public string CandidateAnswers { get; set; }
    }

    public class CandidateAnswer
    {
        public string QuestionId { get; set; }
        public string QuestionDescription { get; set; }
        public string Response { get; set; }
    }
}
