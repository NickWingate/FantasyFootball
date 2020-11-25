using FantasyFootball.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FantasyFootball.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NewTeamCommand = new MvxCommand(NewTeam);
        }
        public IMvxCommand NewTeamCommand { get; set; }
        public async Task LoadTeam(string sourceFilePath)
        {
            TeamModel team;
            Debug.WriteLine(sourceFilePath);
            using (FileStream fs = File.OpenRead(@sourceFilePath))
            {
                team = await JsonSerializer.DeserializeAsync<TeamModel>(fs);
            }
            await _navigationService.Navigate<TeamViewModel, Object>(team);
        }
        private void NewTeam()
        {
            Debug.WriteLine("New Team Button Clicked");
            _navigationService.Navigate<TeamNameViewModel>();
        }
    }
}
