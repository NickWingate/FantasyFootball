namespace FantasyFootball.Core.Models
{
    public class PlayerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public uint Goals { get; set; }
        public uint YellowCards { get; set; }
        public uint RedCards { get; set; }
        public int Value => 10 * (int)Goals + -2 * (int)YellowCards + -5 * (int)RedCards;

        public PlayerModel(string firstName, string lastName, uint goals, uint yellowCards, uint redCards)
        {
            FirstName = firstName;
            LastName = lastName;
            Goals = goals;
            YellowCards = yellowCards;
            RedCards = redCards;
        }
    }
}