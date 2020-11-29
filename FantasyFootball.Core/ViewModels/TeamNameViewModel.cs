using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;

namespace FantasyFootball.Core.ViewModels
{
    public class TeamNameViewModel : MvxViewModel
    {
        // Navigation service dependency injection
        private readonly IMvxNavigationService _navigationService;
        public TeamNameViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            CreateTeamCommand = new MvxCommand(CreateTeam);
        }

        public IMvxCommand CreateTeamCommand { get; set; }

        private string _teamName;
        public string TeamName
        {
            get { return _teamName; }
            set
            {
                SetProperty(ref _teamName, value);
                RaisePropertyChanged(() => TeamName);
            }
        }
        /// <summary>
        /// Create team and pass team name to TeamVM
        /// </summary>
        private void CreateTeam()
        {
            _navigationService.Navigate<TeamViewModel, Object>(TeamName);
        }
    }
}