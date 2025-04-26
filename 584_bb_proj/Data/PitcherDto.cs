using projModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace _584_bb_proj.Data
{
    public class PitcherDto
    {
        public string name { get; set; } = null!;
        public string location { get; set; } = null!;
        public string team { get; set; } = null!;
        public string division { get; set; } = null!;
        public int wins { get; set; }
        public int losses { get; set; }
        public decimal era { get; set; }
        public int games_played { get; set; }
        public int games_started { get; set; }
        public int quality_starts { get; set; }
        public int complete_games { get; set; }
        public int shutouts { get; set; }
        public int saves { get; set; }
        public int holds { get; set; }
        public int blown_saves { get; set; }
        public decimal innings_pitched { get; set; }
        public int total_batters_faced { get; set; }
        public int hits { get; set; }
        public int runs { get; set; }
        public int earned_runs { get; set; }
        public int home_runs { get; set; }
        public int walks { get; set; }
        public int intentional_walks { get; set; }
        public int hbp { get; set; }
        public int wild_pitches { get; set; }
        public int balks { get; set; }
        public int strikeouts { get; set; }
    }
}
