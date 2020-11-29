using FantasyFootball.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FantasyFootball.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        // MvvmCross navigation service depencency injection
        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NewTeamCommand = new MvxCommand(NewTeam);
        }

        public IMvxCommand NewTeamCommand { get; set; }

        /// <summary>
        /// Deserialize json file asynchronously
        /// </summary>
        public async Task LoadTeam(string sourceFilePath)
        {
            TeamModel team;
            Debug.WriteLine(sourceFilePath);
            using (FileStream fs = File.OpenRead(@sourceFilePath))
            {
                team = await JsonSerializer.DeserializeAsync<TeamModel>(fs);
            }
            // Pass team instance into TeamVM
            await _navigationService.Navigate<TeamViewModel, Object>(team);
        }

        private void NewTeam()
        {
            _navigationService.Navigate<TeamNameViewModel>();
        }
    }
}