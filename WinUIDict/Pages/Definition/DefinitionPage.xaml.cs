using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using System.Diagnostics;
using System.Drawing;

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
        App.Current.MainWindow.ItemSelect = this;
    }

    public void OnItemSelect(Dict dict)
    {
        DetailTextBlock.Blocks.Clear();
        //Debug.WriteLine("{Def}", dict.Definition);
        var definition = dict.Definition;

        WordTextBlock.Text = dict.Word;
        foreach (var s in definition.Split("[NewLine]"))
        {
            var paragraph = new Paragraph();

            paragraph.Margin = new Thickness
            {
                Bottom = 32
            };
            foreach (var s1 in s.Split("[]"))
            {
                        if (s1.Contains('|'))
                        {
                            var tmps = s1.Split("|");
                            var run = new Run();
                            run.Text = tmps[1];
                            var hyperLink = new Hyperlink()
                            {
                                UnderlineStyle = UnderlineStyle.None,
                            };
                            hyperLink.SetValue(NameProperty, tmps[0]);
                            hyperLink.Click += HyperLink_Click;
                            hyperLink.Foreground = new SolidColorBrush(Colors.Black);

                            hyperLink.Inlines.Add(run);
                            paragraph.Inlines.Add(hyperLink);
                        }
                        else
                        {
                            var run = new Run();
                    if (s1.Contains("[HI]"))
                    {
                        run.Text = s1.Replace("[HI]","");
                        run.Foreground = new SolidColorBrush(Colors.GreenYellow);
                    }
                    else if (s1.Contains("[HI1]"))
                    {
                        run.Text = s1.Replace("[HI1]","");
                        run.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    else {
                        run.Text = s1;
                        run.Foreground = new SolidColorBrush(Colors.Black);
                    }
                   
                            paragraph.Inlines.Add(run);
                        }
            }
            DetailTextBlock.Blocks.Add(paragraph);
        }
    }

    private void HyperLink_GotFocus(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("focus");
    }

    private void HyperLink_Click(Hyperlink sender, HyperlinkClickEventArgs args)
    {

        Debug.WriteLine(sender.Name);
    }
}
