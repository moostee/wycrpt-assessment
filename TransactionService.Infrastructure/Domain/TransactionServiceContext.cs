using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TransactionService.Domain;

namespace TransactionService.Infrastructure.Domain
{

    public class TransactionServiceContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DbSet<TransactionHistory> TransactionHistory { get; set; }

        public TransactionServiceContext(DbContextOptions<TransactionServiceContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }

    public class TransactionServiceContextFactory : IDesignTimeDbContextFactory<TransactionServiceContext>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConfiguration _configuration;
        public TransactionServiceContextFactory(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        public TransactionServiceContextFactory() { }

        public TransactionServiceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransactionServiceContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            return new TransactionServiceContext(optionsBuilder.Options, _loggerFactory);
        }
    }

}