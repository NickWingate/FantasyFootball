using FantasyFootball.Core.ViewModels;
using Microsoft.Win32;
using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : MvxWpfView
    {
        public MenuView()
        {
            InitializeComponent();
        }
        private void GetFileLocation_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
            };
            if (dialog.ShowDialog() == true)
            {
                string sourceFilePath = dialog.FileName;
                (this.DataContext as MenuViewModel)?.LoadTeam(sourceFilePath);
            }
        }
    }
}
