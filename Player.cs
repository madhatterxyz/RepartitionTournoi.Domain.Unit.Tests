namespace RepartitionTournoi.Domain.Unit.Tests
{
    public class Player
    {
        public Player()
        {
        }

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Telephone { get; set; }
        public override bool Equals(object? obj)
        {
            Player other = obj as Player;
            if (other == null)
            {
                return false;
            }
            return (this.Firstname == other.Firstname) && (this.ID == other.ID) && (this.Lastname == other.Lastname) && (this.Telephone == other.Telephone);
        }
    }
}