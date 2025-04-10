﻿using System.Windows;

namespace JNY_Generator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new MainWindowViewModel();

            var mainWindow = new MainWindow()
            {
                DataContext = viewModel
            };

            mainWindow.Show();
        }
    }

}
