using Microsoft.UI.Xaml;
using System;
using System.Threading.Tasks;
using WinUIDict.Pages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDict
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public IItemSelect ItemSelect;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(typeof(SplashPage));
        }

        public void NavigateToMain()
        {
            DispatcherQueue.TryEnqueue(async () =>
            {
                await Task.Delay(1000);
                MainFrame.Navigate(typeof(MainPage));
            });
        }
    }
}
