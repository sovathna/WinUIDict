using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDict.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashPage : Page
    {
        public SplashPage()
        {
            InitializeComponent();

        }

        private void NavigateToMain()
        {
            App.Current.MainWindow.NavigateToMain();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigateToMain();
        }
    }
}
