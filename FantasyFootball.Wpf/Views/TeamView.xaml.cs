﻿using FantasyFootball.Core.ViewModels;
using Microsoft.Win32;
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
        private void SaveTeamToFile_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON Files (*.json)|*.json|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                string destinationFilePath = dialog.FileName;
                (this.DataContext as TeamViewModel)?.SaveTeamToFile(destinationFilePath);
            }
        }
    }
}