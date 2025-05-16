using System.ComponentModel.DataAnnotations.Schema;

namespace _584_bb_proj.Dto
{
    public class HitterUpdateDto
    {
        public string Name { get; set; } = null!;
        public int Games_Played { get; set; }
        public int At_Bats { get; set; }
        public int Plate_Appearances { get; set; }
        public int Hits { get; set; }
        public int Singles { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int Home_Runs { get; set; }
        public int Runs_Scored { get; set; }
        public int RBI { get; set; }
        public int Walks { get; set; }
        public int Intentional_Walks { get; set; }
        public int Strikeouts { get; set; }
        public int HBP { get; set; }
        public int Sac_Fly { get; set; }
        public int Sac_Hit { get; set; }
        public int GDP { get; set; }
        public int Stolen_Bases { get; set; }
        public int Caught_Stealing { get; set; }
        public decimal Batting_Average { get; set; }
    }
}
