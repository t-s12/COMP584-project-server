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

        [Column("plate_appearances")]
        public int Plate_Appearances { get; set; }

        [Column("at_bats")]
        public int At_Bats { get; set; }

        [Column("hits")]
        public int Hits { get; set; }

        [Column("home_runs")]
        public int Home_Runs { get; set; }

        [Column("RBI")]
        public int RBI { get; set; }

        [Column("strikeouts")]
        public int Strikeouts { get; set; }

        [Column("walks")]
        public int Walks { get; set; }

        [Column("batting_average")]
        public decimal Batting_Average { get; set; }
        [Column("OBP")]
        public decimal OBP { get; set; }

        [Column("SLG")]
        public decimal SLG { get; set; }

        [Column("OPS")]
        public decimal OPS { get; set; }

        [Column("stolen_bases")]
        public int Stolen_Bases { get; set; }

        [Column("caught_stealing")]
        public int caught_stealing { get; set; }

        [JsonIgnore]
        [ForeignKey("TeamId")]
        [InverseProperty("Position_Players")]
        public virtual Team Team { get; set; }

    }
}
