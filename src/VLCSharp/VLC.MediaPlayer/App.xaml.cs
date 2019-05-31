using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using VLC.MediaLibrary.Repository.LocalFile;
using VLC.MediaPlayer.Presentation;
using VLC.MediaPlayer.View;

namespace VLC.MediaPlayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureContainer();
            ComposeObjects();

            Application.Current.MainWindow.Title = "VLC Media Player";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {

        }

        private void ComposeObjects()
        {
            MediaLibraryModel viewModel = new MediaLibraryModel(new LocalFileRepository());
            View.MediaLibrary ml = new View.MediaLibrary(viewModel);
            var mw = new MainWindow();
            mw.LoadMediaLibrary(ml);
            Application.Current.MainWindow = mw;
        }
    }


}
