namespace CapitalRecruit.Domain.Entities.Questions
{
    public class DropdownQuestion
    {
        public List<string> Choices { get; set; } = new List<string>();
        public bool EnableOtherOption { get; set; }
    }
}
