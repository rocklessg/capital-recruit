using CapitalRecruit.Application.Services.Implementations;
using CapitalRecruit.Domain.Entities;
using CapitalRecruit.Infrastructure.Dtos.RequestsDto;
using CapitalRecruit.Infrastructure.Repositories.Interfaces;
using Moq;
using System.Linq.Expressions;

namespace CapitalRecruit.Test.ServicesTest
{
    public class CandidateFormServiceTests
    {
        private readonly Mock<ICandidateFormRepository> _candidateFormRepositoryMock;
        private readonly Mock<IEmployerFormRepository> _employerFormRepositoryMock;
        private readonly CandidateFormService _candidateFormService;

        public CandidateFormServiceTests()
        {
            _candidateFormRepositoryMock = new Mock<ICandidateFormRepository>();
            _employerFormRepositoryMock = new Mock<IEmployerFormRepository>();
            _candidateFormService = new CandidateFormService(_candidateFormRepositoryMock.Object, _employerFormRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateCandidateFormAsync_ShouldReturnFailure_WhenCandidateFormAlreadyExists()
        {
            // Arrange
            var request = new CreateCandidateFormRequestDto { EmailAddress = "test@example.com" };
            _candidateFormRepositoryMock.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<CandidateForm, bool>>>()))
                .ReturnsAsync(true);

            // Act
            var result = await _candidateFormService.CreateCandidateFormAsync("programId", request);

            // Assert
            Assert.False(result.Status);
            Assert.Equal("CandidateForm With Email Address: test@example.com already exists", result.Message);
        }

        [Fact]
        public async Task CreateCandidateFormAsync_ShouldReturnFailure_WhenEmployerFormNotFound()
        {
            // Arrange
            var request = new CreateCandidateFormRequestDto { EmailAddress = "test@example.com" };
            _candidateFormRepositoryMock.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<CandidateForm, bool>>>()))
                .ReturnsAsync(false);
            _employerFormRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<string>()))
                .ReturnsAsync((EmployerForm)null);

            // Act
            var result = await _candidateFormService.CreateCandidateFormAsync("programId", request);

            // Assert
            Assert.False(result.Status);
            Assert.Equal("Program not found", result.Message);
        }
        
    }
}
