namespace RepartitionTournoi.Domain.Unit.Tests
{
    public class Game
    {
        public Game()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public override bool Equals(object? obj)
        {
            Game other = obj as Game;
            if (other == null)
            {
                return false;
            }
            return (this.Name == other.Name) && (this.ID == other.ID);
        }
    }
}