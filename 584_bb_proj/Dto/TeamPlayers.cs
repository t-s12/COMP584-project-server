using System.ComponentModel.DataAnnotations.Schema;
using projModel;

namespace _584_bb_proj.Dto
{
    public class TeamPlayers
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string DivisionName { get; set; } = null!;
        public List<PitcherDTO> Pitchers { get; set; } = null!;

        public List<Position_PlayerDTO> Position_Players { get; set; } = null!;
    }

    public class PitcherDTO 
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public char Bats { get; set; }
        public char Throws { get; set; }
        public string Position { get; set; } = null!;
        public int Games_Played { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal ERA { get; set; }
        public int Saves { get; set; }
        public decimal Innings_Pitched { get; set; }
        public int Strikeouts { get; set; }
        public int Walks { get; set; }
        public int Hits { get; set; }
        public int Hit_By_Pitch { get; set; }
        public decimal WHIP { get; set; }
        public decimal FIP { get; set; }
        public string TeamName { get; set; } = null!;
    }

    public class Position_PlayerDTO 
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public char Bats { get; set; }
        public char Throws { get; set; }
        public string Position { get; set; } = null!;
        public int Games_Played { get; set; }
        public int Plate_Appearances { get; set; }
        public int At_Bats { get; set; }
        public int Hits { get; set; }
        public int Home_Runs { get; set; }
        public int RBI { get; set; }
        public int Strikeouts { get; set; }
        public int Walks { get; set; }
        public decimal Batting_Average { get; set; }
        public decimal OBP { get; set; }
        public decimal SLG { get; set; }
        public decimal OPS { get; set; }
        public int Stolen_Bases { get; set; }
        public int caught_stealing { get; set; }
        public string TeamName { get; set; } = null!;
    }
}
