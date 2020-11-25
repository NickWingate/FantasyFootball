﻿using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyFootball.Core.ViewModels
{
    public class TeamNameViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand CreateTeamCommand { get; set; }
        public TeamNameViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            CreateTeamCommand = new MvxCommand(CreateTeam);
        }

        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set 
            {
                if (SetProperty(ref _teamName, value))
                {
                    RaisePropertyChanged(() => TeamName);
                    RaisePropertyChanged(() => CanCreateTeam);
                }
            }
        }
        public bool CanCreateTeam => !String.IsNullOrWhiteSpace(TeamName);

        private void CreateTeam()
        {
            _navigationService.Navigate<TeamViewModel, string>(TeamName);
        }

    }
}
