namespace CapitalRecruit.Domain.Entities.Questions
{
    public class YesOrNoQuestion
    {
        public bool Choice { get; set; }
        public string QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
