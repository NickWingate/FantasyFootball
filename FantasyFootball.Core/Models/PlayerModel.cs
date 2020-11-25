﻿namespace FantasyFootball.Core.Models
{
    public class PlayerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int Value => 10 * Goals + -2 * YellowCards + -5 * RedCards;

        public PlayerModel(string fName, string lName, int goals, int yCards, int rCards)
        {
            FirstName = fName;
            LastName = lName;
            Goals = goals;
            YellowCards = yCards;
            RedCards = rCards;
        }
    }
}