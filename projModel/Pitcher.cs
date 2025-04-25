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

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("wins")]
        public int Wins { get; set; }

        [Column("losses")]
        public int Losses { get; set; }

        [Column("era")]
        public decimal ERA { get; set; }

        [Column("games_played")]
        public int Games_Played { get; set; }

        [Column("games_started")]
        public int Games_Started { get; set; }

        [Column("quality_starts")]
        public int Quality_Starts { get; set; }

        [Column("complete_games")]
        public int Complete_Games { get; set; }

        [Column("shutouts")]
        public int Shutouts { get; set; }

        [Column("saves")]
        public int Saves { get; set; }

        [Column("holds")]
        public int Holds { get; set; }

        [Column("blown_saves")]
        public int Blown_Saves { get; set; }

        [Column("innings_pitched")]
        public decimal Innings_Pitched { get; set; }

        [Column("total_batters_faced")]
        public int Total_Batters_Faced { get; set; }

        [Column("hits")]
        public int Hits { get; set; }

        [Column("runs")]
        public int Runs { get; set; }

        [Column("earned_runs")]
        public int Earned_Runs { get; set; }

        [Column("home_runs")]
        public int Home_Runs { get; set; }

        [Column("walks")]
        public int Walks { get; set; }

        [Column("intentional_walks")]
        public int Intentional_Walks { get; set; }

        [Column("hbp")]
        public int HBP { get; set; }

        [Column("wild_pitches")]
        public int Wild_Pitches { get; set; }

        [Column("balks")]
        public int Balks { get; set; }

        [Column("strikeouts")]
        public int Strikeouts { get; set; }

        [JsonIgnore]
        [ForeignKey("TeamId")]
        [InverseProperty("Pitchers")]
        public virtual Team Team { get; set; } = null!;
    }
}
