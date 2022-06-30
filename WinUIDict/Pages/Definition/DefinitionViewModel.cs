using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUIDict.Pages.Definition
{
    public sealed class DefinitionViewModel
    {
        private readonly DictDbContext _context;
        private readonly ILogger _logger;

        public DefinitionViewModel(DictDbContext dbContext,ILogger<DefinitionViewModel> logger)
        {
            _context = dbContext;
            _logger = logger;

        }
    }
}
