using FantasyFootball.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;

/* Write a program that allows users to create and store footballers
 * for a fantasy football team with the following characteristics:
 *      Name
 *      Goals scored
 *      Number of Yellow Cards
 *      Number of Red Cards
 *
 * A menu should be output that allows the user to enter a new player(max 5),
 * view their existing team, see the team's current value, or quit the program.
 * The team scores 10 points per goal, -5 for a red card and -2 for a yellow card.
 *
 * When calculating the team's value, the stats of each player is read from
 * the file and the stored values are used to calculate the current value of the team.
*/

namespace FantasyFootball.Core.ViewModels
{
    internal class TeamViewModel : MvxViewModel
    {
        public TeamViewModel()
        {
            AddPlayerCommand = new MvxCommand(AddPlayer);
        }

        public IMvxCommand AddPlayerCommand { get; set; }

        private ObservableCollection<PlayerModel> _players = new ObservableCollection<PlayerModel>();

        public ObservableCollection<PlayerModel> Players
        {
            get { return _players; }
            set
            {
                SetProperty(ref _players, value);
            }
        }

        public int Size => Players.Count;

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

        private string _playerFirstName;

        public string PlayerFirstName
        {
            get { return _playerFirstName; }
            set
            {
                SetProperty(ref _playerFirstName, value);
                RaisePropertyChanged(() => PlayerFirstName);
                RaisePropertyChanged(() => PlayerFullName);
            }
        }

        private string _playerLastName;

        public string PlayerLastName
        {
            get { return _playerLastName; }
            set
            {
                SetProperty(ref _playerLastName, value);
                RaisePropertyChanged(() => PlayerLastName);
                RaisePropertyChanged(() => PlayerFullName);
            }
        }

        private string _goals;

        public string Goals
        {
            get { return _goals; }
            set
            {
                if (SetProperty(ref _goals, value))
                {
                    RaisePropertyChanged(() => Goals);
                    RaisePropertyChanged(() => CanAddPlayer);
                }
            }
        }

        private string _yellowCards;

        public string YellowCards
        {
            get { return _yellowCards; }
            set
            {
                SetProperty(ref _yellowCards, value);
                RaisePropertyChanged(() => YellowCards);
                RaisePropertyChanged(() => CanAddPlayer);
            }
        }

        private string _redCards;

        public string RedCards
        {
            get { return _redCards; }
            set
            {
                SetProperty(ref _redCards, value);
                RaisePropertyChanged(() => RedCards);
                RaisePropertyChanged(() => CanAddPlayer);
            }
        }

        public string PlayerFullName => $"{PlayerFirstName} {PlayerLastName}";
        public bool IsPlayerLimitReached => Size >= 5;

        public bool CanAddPlayer => uint.TryParse(Goals, out _)
            && uint.TryParse(YellowCards, out _)
            && uint.TryParse(RedCards, out _)
            && Size < 5;

        public void AddPlayer()
        {
            PlayerModel p = new PlayerModel(PlayerFullName,
                Convert.ToInt32(Goals),
                Convert.ToInt32(YellowCards),
                Convert.ToInt32(RedCards));
            Players.Add(p);
            ClearFields();
            RaisePropertyChanged(() => Players);
            RaisePropertyChanged(() => TeamValue);
            RaisePropertyChanged(() => IsPlayerLimitReached);
        }

        private void ClearFields()
        {
            PlayerFirstName = String.Empty;
            PlayerLastName = String.Empty;
            Goals = String.Empty;
            YellowCards = String.Empty;
            RedCards = String.Empty;
        }
    }
}