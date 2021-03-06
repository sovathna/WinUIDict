using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDict.Pages.Words;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class WordsPage : Page
{
    private readonly WordsViewModel ViewModel;
    private readonly ILogger _logger;

    public WordsPage()
    {
        ViewModel = App.Current.Services.GetRequiredService<WordsViewModel>();
        _logger = App.Current.Services.GetRequiredService<ILogger<WordsPage>>();
        InitializeComponent();
        DataContext = ViewModel.Words;
    }

    private void GridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var item = (Dict)e.ClickedItem;
        App.Current.MainWindow.ItemSelect.OnItemSelect(item);
    }
}
