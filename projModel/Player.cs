using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace projModel;

[Table("Player")]
public class Player
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("position")]
    public string Position { get; set; }

    [Column("teamid")]
    public int TeamId { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("Players")]
    public virtual Team Team { get; set; } = null!;
}
