using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Windows.ApplicationModel;

namespace WinUIDict
{
    public sealed class DictDbContext : DbContext
    {
        private readonly ILogger _logger;

        public DictDbContext(ILogger<DictDbContext> logger)
        {
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var installedPath = Package.Current.InstalledLocation.Path;
            var dbPath = $@"{installedPath}\Assets\Databases\dict.sqlite";
            optionsBuilder
                .LogTo(log => _logger.LogInformation(log))
                .UseSqlite($"Data Source={dbPath}")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        public DbSet<Dict> Dicts { get; set; }
    }
}
