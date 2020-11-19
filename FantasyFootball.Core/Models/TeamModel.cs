using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyFootball.Core.Models
{
    public class TeamModel
    {
        private List<PlayerModel> _players;

        public string Name { get; set; }
        public List<PlayerModel> Players 
        {
            get { return _players; }
            set
            {
                if (Size > 5)
                {
                    throw new Exception("Team size can be 5 players max ");
                }
                else
                {
                    _players = value;
                }
            } 
        }
        public int Size => Players.Count;
        public int Score
        {
            get
            {
                int total = 0;
                foreach (PlayerModel player in Players)
                {
                    total += player.Value;
                }
                return total;
            }
        }

        public TeamModel(string name)
        {
            Name = name;
        }
    }
}
