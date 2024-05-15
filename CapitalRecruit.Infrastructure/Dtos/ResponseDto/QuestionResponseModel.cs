using CapitalRecruit.Domain.Entities.Questions;

namespace CapitalRecruit.Infrastructure.Dtos.ResponseDto
{
    public class QuestionResponseModel
    {
        public YesOrNoQuestion YesOrNoQuestion { get; set; }

        public ParagraphQuestion ParagraphQuestion { get; set; }

        public string QuestionContent { get; set; }

        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }

        public DropdownQuestion DropdownQuestion { get; set; }

        public DateQuestion DateQuestion { get; set; }

        public NumericQuestion NumericQuestion { get; set; }

        public string Response { get; set; }
    }
}
