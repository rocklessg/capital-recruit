using CapitalRecruit.Infrastructure.Repositories.Interfaces;
using CapitalRecruit.Application.Services.Interfaces;
using CapitalRecruit.Infrastructure.Dtos.ResponseDto;
using CapitalRecruit.Infrastructure.Dtos.RequestsDto;
using CapitalRecruit.Domain.Entities;
using Newtonsoft.Json;

namespace CapitalRecruit.Application.Services.Implementations
{
    public class CandidateFormService : ICandidateFormService
    {
        private readonly ICandidateFormRepository _candidateFormRepository;
        private readonly IEmployerFormRepository _employerFormRepository;

        public CandidateFormService(ICandidateFormRepository CandidateFormRepository,
             IEmployerFormRepository EmployerFormRepository)
        {
            _candidateFormRepository = CandidateFormRepository;
            _employerFormRepository = EmployerFormRepository;
        }
        public async Task<BaseResponse<bool>> CreateCandidateFormAsync(string programId, CreateCandidateFormRequestDto request)
        {
            try
            {
                var CandidateFormExists = await _candidateFormRepository.AnyAsync(x => x.Email == request.EmailAddress);
                if (CandidateFormExists) return new BaseResponse<bool>
                {
                    Status = false,
                    Message = $"CandidateForm With Email Address: {request.EmailAddress} already exists",
                };

                var EmployerForm = await _employerFormRepository.GetAsync(x => x.Id == programId);
                if (EmployerForm is null ) 
                {
                    return new BaseResponse<bool>
                    {
                        Status = false,
                        Message = $"Program not found"
                    };
                }                

                // Candidate responses are Serialized to be able to persist them to the database.
                var candidateAnswers = JsonConvert.SerializeObject(request.Answers); 

                var candidateForm = new CandidateForm
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.EmailAddress,
                    Nationality = request.Nationality,
                    IDNumber = request.IdNumber,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    CurrentResidence = request.CurrentResidence,
                    Phone = request.PhoneNumber,
                    ProgramId = programId,
                    CandidateAnswers = candidateAnswers.ToString(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var savedResponse = await _candidateFormRepository.AddAsync(candidateForm);
                if (savedResponse is null) 
                {
                    return new BaseResponse<bool>
                    {
                        Status = false,
                        Message = $"An error occurred, CandidateForm could not be saved.",
                    };
                }

                return new BaseResponse<bool>
                {
                    Status = true,
                    Message = $"Candidate Form submitted successfully."
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = ex.Message };
            }
        }       
    }
}