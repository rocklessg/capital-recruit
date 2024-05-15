using CapitalRecruit.Application.Services.Interfaces;
using CapitalRecruit.Infrastructure.Dtos.RequestsDto.Question;
using Microsoft.AspNetCore.Mvc;

namespace CapitalRecruit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestionAsync([FromBody] BaseQuestionRequestModel requestModel)
        {
            var response = await _questionService.CreateQuestionAsync(requestModel);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetQuestionAsync(string Id)
        {
            var response = await _questionService.GetQuestionAsync(Id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetQuestionsAsync()
        {
            var response = await _questionService.GetQuestionsAsync();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> UpdateQuestionAsync([FromBody] UpdateQuestionModel updateQuestionModel, [FromRoute] string id)
        {
            var response = await _questionService.UpdateQuestionAsync(updateQuestionModel, id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteQuestionAsync([FromQuery] string id)
        {
            var response = await _questionService.DeleteQuestionAsync(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
