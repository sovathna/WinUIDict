using CommunityToolkit.WinUI;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIDict.Pages.Words
{
    public sealed class WordsViewModel
    {
        public readonly IncrementalLoadingCollection<WordsSource,Dict> Words;

        public WordsViewModel(WordsSource wordsSource)
        {
            Words = new(wordsSource, 100);
        }

        public Visibility ProgressVisibility()
        {
            if(Words.IsLoading) return Visibility.Visible;
            return Visibility.Collapsed;
        }
    }
}
