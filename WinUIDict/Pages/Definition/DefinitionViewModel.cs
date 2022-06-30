using Microsoft.Extensions.Logging;

namespace WinUIDict.Pages.Definition
{
    public sealed class DefinitionViewModel
    {
        private readonly DictDbContext _context;
        private readonly ILogger _logger;

        public DefinitionViewModel(DictDbContext dbContext, ILogger<DefinitionViewModel> logger)
        {
            _context = dbContext;
            _logger = logger;

        }
    }
}
