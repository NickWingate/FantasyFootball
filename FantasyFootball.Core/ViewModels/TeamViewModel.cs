using FantasyFootball.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FantasyFootball.Core.ViewModels
{
    class TeamViewModel : MvxViewModel
    {
        private ObservableCollection<PlayerModel> _players = new ObservableCollection<PlayerModel>();

        public ObservableCollection<PlayerModel> Players
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
                    SetProperty(ref _players, value);
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

        private string _playerFirstName;

        public string PlayerFirstName
        {
            get { return _playerFirstName; }
            set
            {
                SetProperty(ref _playerFirstName, value);

            }
        }
        private string _playerLastName;

        public string PlayerLastName
        {
            get { return _playerLastName; }
            set
            {
                SetProperty(ref _playerLastName, value);

            }
        }

    }
}
