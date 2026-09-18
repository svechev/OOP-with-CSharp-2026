using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfSliderButtonDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ViewModel.MainViewModel viewModel = new ViewModel.MainViewModel();
            if (viewModel == null)
            {
                return;
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = viewModel;
            mainWindow.ShowDialog();
        }
    }
}
