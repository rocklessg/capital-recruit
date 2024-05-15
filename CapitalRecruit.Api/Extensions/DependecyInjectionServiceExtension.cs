using CapitalRecruit.Application.Services.Implementations;
using CapitalRecruit.Application.Services.Interfaces;
using CapitalRecruit.Infrastructure.Data;
using CapitalRecruit.Infrastructure.Repositories.Implementations;
using CapitalRecruit.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CapitalRecruit.Api.Extensions
{
    public static class DependecyInjectionServiceExtension
    {
        public static IServiceCollection ResolveDepencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDbConfig = configuration.GetSection("CosmosDb");

            services.AddDbContext<AppDbContext>(options =>
                options.UseCosmos(
                    cosmosDbConfig["Account"],
                    cosmosDbConfig["Key"],
                    cosmosDbConfig["DatabaseName"]
                ));

            // Repositories
            services.AddScoped<IEmployerFormRepository, EmployerFormRepository>();
            services.AddScoped<ICandidateFormRepository, CandidateFormRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            // Services
            services.AddScoped<ICandidateFormService, CandidateFormService>();
            services.AddScoped<IQuestionService, QuestionService>();

            return services;
        }
    }
}
