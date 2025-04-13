namespace _584_bb_proj.Dto
{
    public class DivisionTeams
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<TeamDivision> Teams { get; set; } = null!;
    }
}
