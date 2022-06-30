using CommunityToolkit.WinUI;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Windows.Data.Html;

namespace WinUIDict.Pages.Words
{
    public sealed class WordsViewModel
    {
        public readonly IncrementalLoadingCollection<WordsSource,Dict> Words;
        private readonly DictDbContext _context;

        public WordsViewModel(WordsSource wordsSource, DictDbContext context)
        {
            Words = new(wordsSource, 100);
            _context = context;
        }

        public Visibility ProgressVisibility()
        {
            if(Words.IsLoading) return Visibility.Visible;
            return Visibility.Collapsed;
        }
    }
}
