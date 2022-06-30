using System.ComponentModel.DataAnnotations.Schema;

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