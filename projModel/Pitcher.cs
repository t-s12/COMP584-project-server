using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace projModel
{
    [Table("Pitcher")]
    public class Pitcher
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("teamid")]
        public int TeamId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Column("bats")]
        public char Bats { get; set; }

        [Column("throws")]
        public char Throws { get; set; }

        [Column("position")]
        public string Position { get; set; } = null!;

        [Column("games_played")]
        public int Games_Played { get; set; }

        [Column("wins")]
        public int Wins { get; set; }

        [Column("losses")]
        public int Losses { get; set; }

        [Column("ERA")]
        public decimal ERA { get; set; }

        [Column("saves")]
        public int Saves { get; set; }  

        [Column("innings_pitched")]
        public decimal Innings_Pitched { get; set; }

        [Column("strikeouts")]
        public int Strikeouts { get; set; }

        [Column("walks")]
        public int Walks { get; set; }

        [Column("hits")]
        public int Hits { get; set; }

        [Column("hit_by_pitch")]
        public int Hit_By_Pitch { get; set; }

        [Column("WHIP")]
        public decimal WHIP { get; set; }

        [Column("FIP")]
        public decimal FIP { get; set; }

        [JsonIgnore]
        [ForeignKey("TeamId")]
        [InverseProperty("Pitchers")]
        public virtual Team Team { get; set; } = null!;
    }
}
