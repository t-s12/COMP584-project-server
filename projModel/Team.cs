using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace projModel;

[Table("Team")]
public partial class Team
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("divisionid")]
    public int DivisionId { get; set; }

    [ForeignKey("DivisionId")]
    [InverseProperty("Teams")]
    public virtual Division Division { get; set; } = null!;

    [InverseProperty("Team")]
    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

}
