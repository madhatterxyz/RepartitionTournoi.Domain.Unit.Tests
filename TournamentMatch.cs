namespace RepartitionTournoi.Domain.Unit.Tests
{
    public class TournamentMatch
    {
        public string Name { get; set; }
        public List<MatchScore> Scores { get; set; } = new List<MatchScore>();
        public Game Game { get; set; }
        public override bool Equals(object? obj)
        {
            TournamentMatch other = obj as TournamentMatch;
            if (other == null)
            {
                return false;
            }
            return (this.Name == other.Name) && (this.Game.Equals(other.Game)) && (this.Scores!=null && this.Scores.SequenceEqual(other.Scores));
        }
    }
    public class MatchScore
    {
        public int Points { get; set; } = 0;
        public Player Player { get; set; }
        public override bool Equals(object? obj)
        {
            MatchScore other = obj as MatchScore;
            if (other == null)
            {
                return false;
            }
            return (this.Points == other.Points) && (this.Player.Equals(other.Player));
        }
    }
}