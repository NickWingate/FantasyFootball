using FantasyFootball.Core.ViewModels;
using MvvmCross.ViewModels;

namespace FantasyFootball.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MenuViewModel>();
        }
    }
}