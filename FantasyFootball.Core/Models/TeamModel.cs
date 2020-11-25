using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FantasyFootball.Core.Models
{
    public class TeamModel
    {
        public TeamModel(string teamName)
        {
            TeamName = teamName;
        }
        public List<PlayerModel> Players { get; set; } = new List<PlayerModel>();
        public int TeamValue
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
        public int MaxTeamSize { get; set; }
        public int TeamSize => Players.Count;
        public string TeamName { get; set; }
    }
}
