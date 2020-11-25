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
    public class TeamViewModel : MvxViewModel<string>
    {
        public TeamViewModel()
        {
            AddPlayerCommand = new MvxCommand(AddPlayer);
        }
        public override void Prepare(string parameter)
        {
            TeamName = parameter;
            Team = new TeamModel(TeamName);
        }
        public string TeamName { get; set; }

        public TeamModel Team { get; set; }
        public IMvxCommand AddPlayerCommand { get; set; }

        public ObservableCollection<PlayerModel> Players 
            => new ObservableCollection<PlayerModel>(Team.Players);

        public int TeamValue => Team.TeamValue;

        private string _playerFirstName;

        public string PlayerFirstName
        {
            get { return _playerFirstName; }
            set
            {
                SetProperty(ref _playerFirstName, value);
                RaisePropertyChanged(() => PlayerFirstName);
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

        public bool IsPlayerLimitReached => Team.TeamSize >= 5;

        public bool CanAddPlayer => uint.TryParse(Goals, out _)
            && uint.TryParse(YellowCards, out _)
            && uint.TryParse(RedCards, out _)
            && Team.TeamSize < 5;

        public void AddPlayer()
        {
            PlayerModel p = new PlayerModel(PlayerFirstName,
                PlayerLastName,
                Convert.ToInt32(Goals),
                Convert.ToInt32(YellowCards),
                Convert.ToInt32(RedCards));
            Team.Players.Add(p);
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