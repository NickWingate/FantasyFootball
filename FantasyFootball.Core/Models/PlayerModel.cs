namespace FantasyFootball.Core.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int Value => 10 * Goals + -2 * YellowCards + -5 * RedCards;

        public PlayerModel(string name, int goals, int yCards, int rCards)
        {
            Name = name;
            Goals = goals;
            YellowCards = yCards;
            RedCards = rCards;
        }
    }
}