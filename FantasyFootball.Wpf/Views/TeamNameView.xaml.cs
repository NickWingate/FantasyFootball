using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FantasyFootball.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TeamNameView.xaml
    /// </summary>
    public partial class TeamNameView : MvxWpfView
    {
        public TeamNameView()
        {
            InitializeComponent();
        }
        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }
        public bool ValidTeamName => IsValid(TeamNameTxtBox);
    }
}
