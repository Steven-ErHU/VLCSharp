using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Forms;

namespace VLC.MediaPlayer.Presentation
{
    public class MediaOpenFileCommand : ICommand
    {
        public MediaLibraryModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string filename = parameter as string;
            var result = ViewModel.MediaReader.OpenFile(filename);
            if (result.Result == 0)
            {
                ViewModel.MediaRootNode = result.MediaNode;
            }
        }
    }

    public class MediaOpenFolderCommand : ICommand
    {
        public MediaLibraryModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;
        public string MediaRootPath { get; private set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string path = GetMediaPath();
            var result = ViewModel.MediaReader.OpenFolder(path);
            if (result.Result == 0)
            {
                ViewModel.MediaRootNode = result.MediaNode;
            }
        }

        private string GetMediaPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            else
            {
                return null;
            }
        }
    }
}
