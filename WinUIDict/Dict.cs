using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIDict;

[Table("words")]
public class Dict
{
    [Column("id")]
    public int Id { get; set; }

    [Column("value")]
    public string Word { get; set; }

    [Column("definition")]
    public string Definition { get; set; }
}

[INotifyPropertyChanged]
[Table("selected")]
public partial class SelectedDict
{
    private int _id;
    [Key]
    [Column("id")]
    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    private int _wordId;
    [Column("word_id")]
    public int WordId
    {
        get => _wordId;
        set => SetProperty(ref _wordId, value);
    }

    private string _word ;
    [Column("value")]
    public string Word
    {
        get => _word;
        set => SetProperty(ref _word, value);
    }
  
    private string _definition ;
    [Column("definition")]
    public string Definition {
        get => _definition; 
        set => SetProperty(ref _definition, value); 
    }    
}