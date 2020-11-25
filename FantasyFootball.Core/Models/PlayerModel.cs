namespace FantasyFootball.Core.Models
{
    public class PlayerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int Value => 10 * Goals + -2 * YellowCards + -5 * RedCards;

        public PlayerModel(string firstName, string lastName, int goals, int yellowCards, int redCards)
        {
            FirstName = firstName;
            LastName = lastName;
            Goals = goals;
            YellowCards = yellowCards;
            RedCards = redCards;
        }
    }
}