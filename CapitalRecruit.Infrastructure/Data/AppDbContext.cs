using CapitalRecruit.Domain.Entities;
using CapitalRecruit.Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore;

namespace CapitalRecruit.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // The constructor is empty because AppDbContext already extends base class.
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.ParagraphQuestion)
                .WithOne(pq => pq.Question)
                .HasForeignKey<ParagraphQuestion>(pq => pq.QuestionId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.YesOrNoQuestion)
                .WithOne(pq => pq.Question)
                .HasForeignKey<YesOrNoQuestion>(pq => pq.QuestionId);

            modelBuilder.Entity<CandidateForm>().ToContainer("recruit-portal");
            modelBuilder.Entity<Question>().ToContainer("recruit-portal");
            modelBuilder.Entity<EmployerForm>().ToContainer("recruit-portal");
            
            modelBuilder.Entity<CandidateForm>().HasPartitionKey(cf => cf.Id);
            modelBuilder.Entity<Question>().HasPartitionKey(q => q.Id);
            modelBuilder.Entity<EmployerForm>().HasPartitionKey(ef => ef.Id);
        }
        public DbSet<EmployerForm> EmployerForms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CandidateForm> CandidateForms { get; set; }
    }
}
