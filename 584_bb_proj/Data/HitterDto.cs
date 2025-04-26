using System.ComponentModel.DataAnnotations.Schema;
using projModel;

namespace _584_bb_proj.Data
{
    public class HitterDto
    {
        public string name { get; set; } = null!;
        public string location { get; set; } = null!;
        public string team { get; set; } = null!;
        public string division { get; set; } = null!;
        public int games_played { get; set; }
        public int at_bats { get; set; }
        public int plate_appearances { get; set; }
        public int hits { get; set; }
        public int singles { get; set; }
        public int doubles { get; set; }
        public int triples { get; set; }
        public int home_runs { get; set; }
        public int runs_scored { get; set; }
        public int rbi { get; set; }
        public int walks { get; set; }
        public int intentional_walks { get; set; }
        public int strikeouts { get; set; }
        public int hbp { get; set; }
        public int sac_fly { get; set; }
        public int sac_hit { get; set; }
        public int gdp { get; set; }
        public int stolen_bases { get; set; }
        public int caught_stealing { get; set; }
        public decimal batting_average { get; set; }
    }
}
