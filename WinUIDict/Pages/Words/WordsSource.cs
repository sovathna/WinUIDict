using CommunityToolkit.Common.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinUIDict.Pages.Words
{
    public sealed class WordsSource : IIncrementalSource<Dict>
    {
        private readonly DictDbContext _context;
        private readonly ILogger<WordsSource> _logger;

        public WordsSource(DictDbContext context, ILogger<WordsSource> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Dict>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("GetPagedItemsAsync {Page} {Size}", pageIndex, pageSize);

            if(pageIndex==1)
            await Task.Delay(500, cancellationToken);


            return _context.Dicts.AsNoTracking()
               .Skip(pageIndex * pageSize)
               .Take(pageSize)
              .OrderBy(d => d.Word)
               .AsEnumerable();

        }
    }
}
