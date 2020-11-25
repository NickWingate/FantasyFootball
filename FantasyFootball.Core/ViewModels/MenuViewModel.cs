using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FantasyFootball.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NewTeamCommand = new MvxCommand(NewTeam);
            LoadTeamCommand = new MvxCommand(LoadTeam);
        }
        public IMvxCommand NewTeamCommand { get; set; }
        public IMvxCommand LoadTeamCommand { get; set; }

        private void NewTeam()
        {
            Debug.WriteLine("New Team Button Clicked");
            _navigationService.Navigate<TeamNameViewModel>();
            // Get Team Name
            // Pass into TeamViewModel
        }
        private void LoadTeam()
        {
            Debug.WriteLine("Load Team Button Clicked");
            // Open File
            //
            // Pass into TeamViewModel
        }
    }
}
