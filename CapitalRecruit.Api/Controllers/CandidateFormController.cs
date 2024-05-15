using CapitalRecruit.Application.Services.Interfaces;
using CapitalRecruit.Infrastructure.Dtos.RequestsDto;
using Microsoft.AspNetCore.Mvc;

namespace CapitalRecruit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateFormController : ControllerBase
    {
        private readonly ICandidateFormService _candidateFormService;
        public CandidateFormController(ICandidateFormService candidateFormService)
        {
            _candidateFormService = candidateFormService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCandidateFormAsync(string programId, [FromBody] CreateCandidateFormRequestDto applicationModel)
        {
            var response = await _candidateFormService.CreateCandidateFormAsync(programId, applicationModel);
            return response.Status ? Ok(response) : BadRequest(response);
        }        
    }
}
