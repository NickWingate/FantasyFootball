using MvvmCross.Platforms.Wpf.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FantasyFootball.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TeamView.xaml
    /// </summary>
    public partial class TeamView : MvxWpfView
    {
        public TeamView()
        {
            InitializeComponent();
        }
        private void Expander_Process(object sender, RoutedEventArgs e)
        {
            if (sender is Expander expander)
            {
                var row = DataGridRow.GetRowContainingElement(expander);

                row.DetailsVisibility = expander.IsExpanded ? Visibility.Visible
                                                            : Visibility.Collapsed;
            }
        }
    }
}