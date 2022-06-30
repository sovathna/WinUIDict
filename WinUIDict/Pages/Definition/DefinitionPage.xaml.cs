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
        App.Current.MainWindow.ItemSelect = this;
    }

    public void OnItemSelect(Dict dict)
    {
        DetailTextBlock.Blocks.Clear();
        //Debug.WriteLine("{Def}", dict.Definition);
        var definition = dict.Definition;

        WordTextBlock.Text = dict.Word;
        foreach (var s in definition.Split("\\n"))
        {
            var paragraph = new Paragraph();
            
            paragraph.Margin = new Thickness
            {
                Bottom = 32
            };
            foreach(var s1 in s.Split("<\""))
            {
                if (!string.IsNullOrWhiteSpace(s1))
                {
                    foreach (var s2 in s1.Split("/a"))
                    {
                        if (s2.Contains("\">"))
                        {
                            var tmps = s2.Split("\">");
                            var run = new Run();
                            var span = new Span();
    
          
                            run.Text = tmps[1];
                            var hyperLink = new Hyperlink()
                            {
                                UnderlineStyle = UnderlineStyle.None,
                            };
                            hyperLink.SetValue(NameProperty, tmps[0]);
                            hyperLink.Click += HyperLink_Click;
                            hyperLink.GotFocus += HyperLink_GotFocus;
                          
                            hyperLink.Inlines.Add(run);
                            paragraph.Inlines.Add(hyperLink);
                        }
                        else
                        {
                            var run = new Run();
                            run.Text = s2;
                            paragraph.Inlines.Add(run);
                        }
                    }
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
