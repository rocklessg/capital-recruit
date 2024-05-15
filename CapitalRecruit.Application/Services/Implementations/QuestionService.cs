using System.Linq;
using System.Threading.Tasks;
using CapitalRecruit.Domain.Entities.Questions;
using CapitalRecruit.Infrastructure.Repositories.Interfaces;
using CapitalRecruit.Infrastructure.Dtos.ResponseDto;
using CapitalRecruit.Application.Services.Interfaces;
using CapitalRecruit.Infrastructure.Dtos.RequestsDto.Question;

namespace CapitalRecruit.Application.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<BaseResponse<bool>> CreateQuestionAsync(BaseQuestionRequestModel questionRequestModel)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                switch (questionRequestModel.QuestionType.ToString())
                {
                    case "YesOrNo":
                        var question = new Question
                        {
                            QuestionContent = questionRequestModel.QuestionContent,
                            YesOrNoQuestion = new YesOrNoQuestion
                            {
                                Choice = questionRequestModel.YesOrNoQuestionModel.Choice
                            },
                        };
                        var savedResponse = await _questionRepository.AddAsync(question);
                        if (savedResponse is not null) baseResponse = new BaseResponse<bool>
                        {
                            Status = true,
                            Message = "Question Successfully Added."
                        };
                        break;

                    case "Dropdown":
                        var dropdownQuestion = new Question
                        {
                            QuestionContent = questionRequestModel.QuestionContent,
                            DropdownQuestion = new DropdownQuestion
                            {
                                Choices = questionRequestModel.DropdownQuestionModel.Choices,
                                EnableOtherOption = questionRequestModel.DropdownQuestionModel.EnableOtherOption,
                            },
                        };
                        var savedDropdownResponse = await _questionRepository.AddAsync(dropdownQuestion);
                        if (savedDropdownResponse is not null) baseResponse = new BaseResponse<bool>
                        {
                            Status = true,
                            Message = "Question Successfully Added."
                        };
                        break;

                    case "MultipleChoice":
                        var multipleChoiceQuestion = new Question
                        {
                            QuestionContent = questionRequestModel.QuestionContent,
                            MultipleChoiceQuestion = new MultipleChoiceQuestion
                            {
                                Options = questionRequestModel.MultipleChoiceQuestionModel.Options,
                                EnableOtherOption = questionRequestModel.MultipleChoiceQuestionModel.EnableOtherOption,
                                MaximumChoicesAllowed = questionRequestModel.MultipleChoiceQuestionModel.MaximumNumberOfChoicesAllowed

                            },
                        };
                        var savedMultipleChoiceQuestionResponse = await _questionRepository.AddAsync(multipleChoiceQuestion);
                        if (savedMultipleChoiceQuestionResponse is not null) baseResponse = new BaseResponse<bool>
                        {
                            Status = true,
                            Message = "Question Successfully Added."
                        };
                        break;

                    case "Number":
                        var NumericQuestion = new Question
                        {
                            QuestionContent = questionRequestModel.QuestionContent,
                            NumericQuestion = new NumericQuestion
                            {
                                Question = questionRequestModel.NumberQuestionModel.NumberQuestion,
                            },
                        };
                        var savedNumericQuestionResponse = await _questionRepository.AddAsync(NumericQuestion);
                        if (savedNumericQuestionResponse is not null) baseResponse = new BaseResponse<bool>
                        {
                            Status = true,
                            Message = "Question Successfully Added."
                        };
                        break;

                    case "Date":
                        var dateQuestion = new Question
                        {
                            QuestionContent = questionRequestModel.QuestionContent,
                            DateQuestion = new DateQuestion
                            {
                                DateQuestionToAsk = questionRequestModel.DateQuestionModel.DateQuestion,
                            },
                        };
                        var savedDateQuestionResponse = await _questionRepository.AddAsync(dateQuestion);
                        if (savedDateQuestionResponse is not null) baseResponse = new BaseResponse<bool>
                        {
                            Status = true,
                            Message = "Question Successfully Added."
                        };
                        break;

                    default:
                        var generalQuestion = new Question
                        {
                            QuestionContent = questionRequestModel.QuestionContent
                        };
                        var savedGeneralQuestionResponse = await _questionRepository.AddAsync(generalQuestion);
                        if (savedGeneralQuestionResponse is not null) baseResponse = new BaseResponse<bool>
                        {
                            Status = true,
                            Message = "Question Successfully Added."
                        };
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return baseResponse;
        }
        public async Task<BaseResponse<bool>> UpdateQuestionAsync(UpdateQuestionModel questionUpdateModel, string Id)
        {
            try
            {
                var question = await _questionRepository.GetAsync(question => question.Id == Id);

                if (question is null)
                {
                    return new BaseResponse<bool>
                    {
                        Status = false,
                        Message = $"Question With Id: {Id} does not exist",
                    };
                }

                question.Answer = questionUpdateModel.Response;
                question.QuestionContent = questionUpdateModel.QuestionContent;
                var updateResponse = await _questionRepository.UpdateAsync(question);
                if (updateResponse is not null) return new BaseResponse<bool>
                {
                    Status = false,
                    Message = $"An error occurred! Question could not be updated.",
                };
                return new BaseResponse<bool>
                {
                    Status = true,
                    Message = $"Question has been updated successfully!",
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<BaseResponse<IEnumerable<QuestionResponseModel>>> GetQuestionsAsync()
        {
            try
            {
                var questions = await _questionRepository.GetAllAsync();
                if (questions.Count() == 0 || !questions.Any()) return new BaseResponse<IEnumerable<QuestionResponseModel>>
                {
                    Status = false,
                    Message = "Fetching Questions Returned Empty Data..."
                };

                return new BaseResponse<IEnumerable<QuestionResponseModel>>
                {
                    Data = (IEnumerable<QuestionResponseModel>)questions.ToList(),
                    Status = true,
                    Message = "Questions Successfully Retrieved"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponse<QuestionResponseModel>> GetQuestionAsync(string Id)
        {
            try
            {
                var question = await _questionRepository.GetAsync(Id);
                if (question is null) return new BaseResponse<QuestionResponseModel>
                {
                    Status = false,
                    Message = "Question not found"
                };

                var questionReturned = new QuestionResponseModel
                {
                    QuestionContent = question.QuestionContent,
                    YesOrNoQuestion = question.YesOrNoQuestion,
                    NumericQuestion = question.NumericQuestion,
                    ParagraphQuestion = question.ParagraphQuestion,
                    MultipleChoiceQuestion = question.MultipleChoiceQuestion,
                    DropdownQuestion = question.DropdownQuestion,
                    DateQuestion = question.DateQuestion
                };
                return new BaseResponse<QuestionResponseModel>
                {
                    Data = questionReturned,
                    Status = true,
                    Message = "Question Successfully Retrieved..."
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }               
        public async Task<BaseResponse<bool>> DeleteQuestionAsync(string Id)
        {
            try
            {
                var question = await _questionRepository.GetAsync(Id);

                if (question is null)
                {
                    return new BaseResponse<bool>
                    {
                        Status = false,
                        Message = $"Question With Id does not exist",
                    };
                }

                await _questionRepository.DeleteAsync(question);

                return new BaseResponse<bool>
                {
                    Status = true,
                    Message = $"Question has been deleted successfully!",
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
