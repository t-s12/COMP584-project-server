using projModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace _584_bb_proj.Data
{
    public class PitcherDto
    {
        public string Name { get; set; } = null!;
        public string TeamName { get; set; } = null!;
        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal ERA { get; set; }
        public int Games_Played { get; set; }
        public int Games_Started { get; set; }
        public int Quality_Starts { get; set; }
        public int Complete_Games { get; set; }
        public int Shutouts { get; set; }
        public int Saves { get; set; }
        public int Holds { get; set; }
        public int Blown_Saves { get; set; }
        public decimal Innings_Pitched { get; set; }
        public int Total_Batters_Faced { get; set; }
        public int Hits { get; set; }
        public int Runs { get; set; }
        public int Earned_Runs { get; set; }
        public int Home_Runs { get; set; }
        public int Walks { get; set; }
        public int Intentional_Walks { get; set; }
        public int HBP { get; set; }
        public int Wild_Pitches { get; set; }
        public int Balks { get; set; }
        public int Strikeouts { get; set; }
    }
}
