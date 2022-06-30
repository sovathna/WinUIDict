using CommunityToolkit.WinUI;

namespace WinUIDict.Pages.Words
{
    public sealed class WordsViewModel
    {
        public readonly IncrementalLoadingCollection<WordsSource, Dict> Words;
        private readonly DictDbContext _context;

        public WordsViewModel(WordsSource wordsSource, DictDbContext context)
        {
            Words = new(wordsSource, 100);
            _context = context;
        }
    }
}
