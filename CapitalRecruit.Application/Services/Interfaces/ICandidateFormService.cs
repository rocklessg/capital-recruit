using CapitalRecruit.Infrastructure.Dtos.RequestsDto;
using CapitalRecruit.Infrastructure.Dtos.ResponseDto;

namespace CapitalRecruit.Application.Services.Interfaces
{
    public interface ICandidateFormService
    {
        Task<BaseResponse<bool>> CreateCandidateFormAsync(string programId, CreateCandidateFormRequestDto request);

        //Task<BaseResponse<bool>> UpdateCandidateFormAsync(UpdateCandidateFormRequestDto applicationModel, string Id);

        //Task<BaseResponse<IEnumerable<CandidateFormModel>>> GetCandidateFormsAsync();

        //Task<BaseResponse<CandidateFormModel>> GetCandidateFormAsync(string Id);

        //Task<BaseResponse<bool>> DeleteCandidateFormAsync(string Id);
    }
}
