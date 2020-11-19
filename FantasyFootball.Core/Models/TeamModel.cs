using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyFootball.Core.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public List<PlayerModel> Players { get; set; }
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
    }
}
