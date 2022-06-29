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

        public void SelectWord(Dict dict)
        {
            var old = _context.SelectedDicts.OrderBy(d => d.Id).FirstOrDefault();

            if (old?.WordId == dict.Id) return;
            var definition = dict.Definition
                .Replace("<\"", "<a href=\"")
                .Replace("/a", "</a>")
            .Replace("\\n", "<br><br>")
            .Replace(" : ", " : ឧ. ")
            .Replace("ន.", "<span style=\"color:#D32F2F\">ន.</span>")
            .Replace("កិ. វិ.", "<span style=\"color:#D32F2F\">កិ. វិ.</span>")
            .Replace("កិ.វិ.", "<span style=\"color:#D32F2F\">កិ.វិ.</span>")
            .Replace("កិ.", "<span style=\"color:#D32F2F\">កិ.</span>")
            .Replace("និ.", "<span style=\"color:#D32F2F\">និ.</span>")
            .Replace("គុ.", "<span style=\"color:#D32F2F\">គុ.</span>");
          
            if (old == null)
            {
                _context.SelectedDicts.Add(new SelectedDict
                {
                    WordId = dict.Id,
                    Word = dict.Word,
                    Definition = definition
                });
            }
            else
            {
                old.Word = dict.Word;
                old.WordId = dict.Id;
                old.Definition = definition;
            }
            _context.SaveChanges();

        }
    }
}
