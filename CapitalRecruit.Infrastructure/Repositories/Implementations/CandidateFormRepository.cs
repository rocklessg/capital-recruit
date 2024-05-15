using CapitalRecruit.Domain.Entities;
using CapitalRecruit.Infrastructure.Data;
using CapitalRecruit.Infrastructure.Repositories.Interfaces;

namespace CapitalRecruit.Infrastructure.Repositories.Implementations
{
    public class CandidateFormRepository : GenericRepository<CandidateForm>, ICandidateFormRepository
    {
        public CandidateFormRepository(AppDbContext context) : base(context)
        {
        }
    }
}
