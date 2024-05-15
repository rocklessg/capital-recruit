using CapitalRecruit.Domain.Entities.Questions;
using CapitalRecruit.Infrastructure.Data;
using CapitalRecruit.Infrastructure.Repositories.Interfaces;

namespace CapitalRecruit.Infrastructure.Repositories.Implementations
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {

        }
    }
}
