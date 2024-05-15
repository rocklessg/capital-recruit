using CapitalRecruit.Domain.Entities;
using CapitalRecruit.Infrastructure.Data;
using CapitalRecruit.Infrastructure.Repositories.Interfaces;

namespace CapitalRecruit.Infrastructure.Repositories.Implementations
{
    public class EmployerFormRepository : GenericRepository<EmployerForm>, IEmployerFormRepository
    {
        public EmployerFormRepository(AppDbContext context) : base(context)
        {
        }
    }
}