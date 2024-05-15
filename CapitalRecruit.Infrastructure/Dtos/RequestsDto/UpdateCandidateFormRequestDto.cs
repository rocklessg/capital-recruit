namespace CapitalRecruit.Infrastructure.Dtos.RequestsDto
{
    public class UpdateCandidateFormRequestDto : CreateCandidateFormRequestDto
    {
        public DateTime UpdatedAt { get; set; }
    }
}
