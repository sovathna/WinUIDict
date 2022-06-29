using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDict.Pages.Definition;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class DefinitionPage : Page, IItemSelect
{
    private readonly DefinitionViewModel _viewModel = App.Current.Services.GetRequiredService<DefinitionViewModel>();
    public DefinitionPage()
    {
        this.InitializeComponent();
        DataContext = _viewModel.Selected;
        App.Current.MainWindow.ItemSelect = this;
    }

    public void OnItemSelect(Dict dict)
    {
        Debug.WriteLine("{Def}", dict.Definition);
        var paragraph = new Paragraph();
        var run =new Run();
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

        run.Text = definition;
        paragraph.Inlines.Add(run);
        DetailTextBlock.Blocks.Add(paragraph);
    }
}
