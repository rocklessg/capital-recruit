using System.Data.Common;
using CapitalRecruit.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CapitalRecruit.Test
{
    public abstract class TestBase : IDisposable
    {
        private readonly DbConnection _connection;
        protected readonly AppDbContext _context;

        protected TestBase()
        {
            /*
              * This config is done to setup a disposable in-memory SQlite database for unit test
              * purpose only. The db instance is created, used and disposed after use
              * for each unit test execution.
              * This way, unit test data will not be persisted in the main application database
            */

            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            // Clean up resources
            _context.Dispose();
            _connection?.Dispose();
        }
    }
}
