using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace VLC.MediaPlayer.Presentation
{
    public class MediaLibraryCommand : ICommand
    {
        public MediaLibraryModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
ViewModel.MediaRootNode = ViewModel.
    }
}
