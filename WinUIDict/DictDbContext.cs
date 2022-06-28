using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.WinUI.Helpers;
using Windows.Storage;
using Windows.ApplicationModel;

namespace WinUIDict
{
    public sealed class DictDbContext : DbContext
    {

        private readonly ILoggerFactory _loggerFactory;

        public DictDbContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var installedPath = Package.Current.InstalledPath;
            var dbPath = $@"{installedPath}\Assets\Databases\dict.sqlite";
            optionsBuilder
                .UseLoggerFactory(_loggerFactory)
                .UseSqlite($"Data Source={dbPath}")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        public DbSet<Dict> Dicts { get; set; }
    }
}
