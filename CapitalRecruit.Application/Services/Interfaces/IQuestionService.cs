using CapitalRecruit.Infrastructure.Dtos.RequestsDto.Question;
using CapitalRecruit.Infrastructure.Dtos.ResponseDto;
namespace CapitalRecruit.Application.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<BaseResponse<bool>> CreateQuestionAsync(BaseQuestionRequestModel questionRequestModel);

        Task<BaseResponse<bool>> UpdateQuestionAsync(UpdateQuestionModel questionUpdateModel, string Id);

        Task<BaseResponse<IEnumerable<QuestionResponseModel>>> GetQuestionsAsync();

        Task<BaseResponse<QuestionResponseModel>> GetQuestionAsync(string Id);
       // Task<BaseResponse<QuestionResponseModel>> GetQuestionByTypeAsync(string questionType);

        Task<BaseResponse<bool>> DeleteQuestionAsync(string Id);
    }
}