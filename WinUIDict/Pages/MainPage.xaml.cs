using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIDict.Pages.Definition;
using WinUIDict.Pages.Words;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDict.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            WordsFrame.Navigate(typeof(WordsPage));
            DefinitionFrame.Navigate(typeof(DefinitionPage));
        }
    }
}
