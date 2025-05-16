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
    [Table("Position_Player")]
    public class Position_Player
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("teamid")]
        public int TeamId { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("games_played")]
        public int Games_Played { get; set; }

        [Column("at_bats")]
        public int At_Bats { get; set; }

        [Column("plate_appearances")]
        public int Plate_Appearances { get; set; }

        [Column("hits")]
        public int Hits { get; set; }

        [Column("singles")]
        public int Singles { get; set; }

        [Column("doubles")]
        public int Doubles { get; set; }

        [Column("triples")]
        public int Triples { get; set; }

        [Column("home_runs")]
        public int Home_Runs { get; set; }

        [Column("runs_scored")]
        public int Runs_Scored { get; set; }

        [Column("rbi")]
        public int RBI { get; set; }

        [Column("walks")]
        public int Walks { get; set; }

        [Column("intentional_walks")]
        public int Intentional_Walks { get; set; }

        [Column("strikeouts")]
        public int Strikeouts { get; set; }

        [Column("hbp")]
        public int HBP { get; set; }

        [Column("sac_fly")]
        public int Sac_Fly { get; set; }

        [Column("sac_hit")]
        public int Sac_Hit { get; set; }

        [Column("gdp")]
        public int GDP { get; set; }

        [Column("stolen_bases")]
        public int Stolen_Bases { get; set; }

        [Column("caught_stealing")]
        public int Caught_Stealing { get; set; }

        [Column("batting_average", TypeName = "decimal(18,3)"),]
        public decimal Batting_Average { get; set; }

        [JsonIgnore]
        [ForeignKey("TeamId")]
        [InverseProperty("Position_Players")]
        public virtual Team Team { get; set; } = null!;

    }
}
