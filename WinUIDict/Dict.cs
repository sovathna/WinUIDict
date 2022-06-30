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