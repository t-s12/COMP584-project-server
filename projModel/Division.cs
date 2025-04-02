using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace projModel;

[Table("Division")]
public class Division
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [InverseProperty("Division")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
