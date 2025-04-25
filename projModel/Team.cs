using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace projModel;

[Table("Team")]
public partial class Team
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("location")]
    public string Location { get; set; } = null!;

    [Column("divisionid")]
    public int DivisionId { get; set; }

    [JsonIgnore]
    [ForeignKey("DivisionId")]
    [InverseProperty("Teams")]
    public virtual Division Division { get; set; } = null!;

    [InverseProperty("Team")]
    public virtual ICollection<Position_Player> Position_Players { get; set; } = new List<Position_Player>();

    [InverseProperty("Team")]
    public virtual ICollection<Pitcher> Pitchers { get; set; } = new List<Pitcher>();

}
