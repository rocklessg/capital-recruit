using CapitalRecruit.Infrastructure.Dtos.ResponseDto;

namespace CapitalRecruit.Infrastructure.Dtos.RequestsDto
{
    public class UpdateEmployerFormRequestDto : EmployerFormResponseDto
    {
        public DateTime UpdatedAt { get; set; }
    }
}
