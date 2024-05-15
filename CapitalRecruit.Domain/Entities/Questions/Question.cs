namespace CapitalRecruit.Domain.Entities.Questions
{
    // This design cater for a recruiter or employee to be able to set different questions 
    // and save them as a set or batch
    public class Question : BaseEntity
    {
        public DateQuestion DateQuestion { get; set; }
        public YesOrNoQuestion YesOrNoQuestion { get; set; }
        public string QuestionContent { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
        public ParagraphQuestion ParagraphQuestion { get; set; }
        public DropdownQuestion DropdownQuestion { get; set; }
        public NumericQuestion NumericQuestion { get; set; }

        // This represents a property that holds the response given by the candidate for this question.
        public string Answer { get; set; }
    }
}
