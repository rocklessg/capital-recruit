using CapitalRecruit.Application.Services.Implementations;
using CapitalRecruit.Domain.Entities.Questions;
using CapitalRecruit.Domain.Enums;
using CapitalRecruit.Infrastructure.Dtos.RequestsDto.Question;
using CapitalRecruit.Infrastructure.Repositories.Interfaces;
using Moq;

public class QuestionServiceTests
{
    private readonly Mock<IQuestionRepository> _questionRepositoryMock;
    private readonly QuestionService _questionService;

    public QuestionServiceTests()
    {
        _questionRepositoryMock = new Mock<IQuestionRepository>();
        _questionService = new QuestionService(_questionRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldReturnSuccess_ForYesOrNoQuestion()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.YesOrNo,
            QuestionContent = "Is this a yes or no question?",
            YesOrNoQuestionModel = new YesOrNoQuestionModel
            {
                Choice = true
            }
        };

        var question = new Question
        {
            QuestionContent = requestModel.QuestionContent,
            YesOrNoQuestion = new YesOrNoQuestion
            {
                Choice = requestModel.YesOrNoQuestionModel.Choice
            }
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync(question);

        // Act
        var result = await _questionService.CreateQuestionAsync(requestModel);

        // Assert
        Assert.True(result.Status);
        Assert.Equal("Question Successfully Added.", result.Message);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldReturnSuccess_ForDropdownQuestion()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.Dropdown,
            QuestionContent = "Choose one:",
            DropdownQuestionModel = new DropdownQuestionModel
            {
                Choices = new List<string> { "Option 1", "Option 2" },
                EnableOtherOption = true
            }
        };

        var question = new Question
        {
            QuestionContent = requestModel.QuestionContent,
            DropdownQuestion = new DropdownQuestion
            {
                Choices = requestModel.DropdownQuestionModel.Choices,
                EnableOtherOption = requestModel.DropdownQuestionModel.EnableOtherOption
            }
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync(question);

        // Act
        var result = await _questionService.CreateQuestionAsync(requestModel);

        // Assert
        Assert.True(result.Status);
        Assert.Equal("Question Successfully Added.", result.Message);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldReturnSuccess_ForMultipleChoiceQuestion()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.MultipleChoice,
            QuestionContent = "Select options:",
            MultipleChoiceQuestionModel = new MultipleChoiceQuestionModel
            {
                Options = new List<string> { "Option A", "Option B" },
                EnableOtherOption = true,
                MaximumNumberOfChoicesAllowed = 2
            }
        };

        var question = new Question
        {
            QuestionContent = requestModel.QuestionContent,
            MultipleChoiceQuestion = new MultipleChoiceQuestion
            {
                Options = requestModel.MultipleChoiceQuestionModel.Options,
                EnableOtherOption = requestModel.MultipleChoiceQuestionModel.EnableOtherOption,
                MaximumChoicesAllowed = requestModel.MultipleChoiceQuestionModel.MaximumNumberOfChoicesAllowed
            }
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync(question);

        // Act
        var result = await _questionService.CreateQuestionAsync(requestModel);

        // Assert
        Assert.True(result.Status);
        Assert.Equal("Question Successfully Added.", result.Message);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldReturnSuccess_ForNumberQuestion()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.Number,
            QuestionContent = "Enter a number:",
            NumberQuestionModel = new NumberQuestionModel
            {
                NumberQuestion = 42
            }
        };

        var question = new Question
        {
            QuestionContent = requestModel.QuestionContent,
            NumericQuestion = new NumericQuestion
            {
                Question = requestModel.NumberQuestionModel.NumberQuestion
            }
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync(question);

        // Act
        var result = await _questionService.CreateQuestionAsync(requestModel);

        // Assert
        Assert.True(result.Status);
        Assert.Equal("Question Successfully Added.", result.Message);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldReturnSuccess_ForDateQuestion()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.Date,
            QuestionContent = "Enter a date:",
            DateQuestionModel = new DateQuestionModel
            {
                DateQuestion = DateTime.UtcNow
            }
        };

        var question = new Question
        {
            QuestionContent = requestModel.QuestionContent,
            DateQuestion = new DateQuestion
            {
                DateQuestionToAsk = requestModel.DateQuestionModel.DateQuestion
            }
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync(question);

        // Act
        var result = await _questionService.CreateQuestionAsync(requestModel);

        // Assert
        Assert.True(result.Status);
        Assert.Equal("Question Successfully Added.", result.Message);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldReturnSuccess_ForGeneralQuestion()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.Paragraph,
            QuestionContent = "General question?"
        };

        var question = new Question
        {
            QuestionContent = requestModel.QuestionContent
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync(question);

        // Act
        var result = await _questionService.CreateQuestionAsync(requestModel);

        // Assert
        Assert.True(result.Status);
        Assert.Equal("Question Successfully Added.", result.Message);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldReturnFailure_OnRepositoryFailure()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.YesOrNo,
            QuestionContent = "Is this a yes or no question?",
            YesOrNoQuestionModel = new YesOrNoQuestionModel
            {
                Choice = true
            }
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync((Question)null);

        // Act
        var result = await _questionService.CreateQuestionAsync(requestModel);

        // Assert
        Assert.False(result.Status);
        Assert.NotEqual("Question Successfully Added.", result.Message);
    }

    [Fact]
    public async Task CreateQuestionAsync_ShouldThrowException_OnRepositoryException()
    {
        // Arrange
        var requestModel = new BaseQuestionRequestModel
        {
            QuestionType = QuestionType.YesOrNo,
            QuestionContent = "Is this a yes or no question?",
            YesOrNoQuestionModel = new YesOrNoQuestionModel
            {
                Choice = false
            }
        };

        _questionRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ThrowsAsync(new Exception("Repository error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _questionService.CreateQuestionAsync(requestModel));
    }
}

