using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VLC.Common;

namespace VLC.MediaPlayer.Presentation
{
    public class MediaLibraryModel : INotifyPropertyChanged
    {
        private IMediaReader _mediaReader;
        public IMediaReader MediaReader
        {
            get
            {
                return _mediaReader;
            }
        }

        public MediaLibraryModel(IMediaReader mediaReader)
        {
            _mediaReader = mediaReader;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private MediaFileNode _rootNode;
        public MediaFileNode MediaRootNode
        {
            get
            {
                return _rootNode;
            }
            set
            {
                if (_rootNode != value)
                {
                    _rootNode = value;
                    RaisePropertyChanged("MediaRootNode");
                }
            }
        }

        private MediaOpenFileCommand _mediaOpenFileCommand = new MediaOpenFileCommand();
        public MediaOpenFileCommand OpenFileCommand
        {
            get
            {
                if (_mediaOpenFileCommand.ViewModel == null)
                {
                    _mediaOpenFileCommand.ViewModel = this;
                }
                return _mediaOpenFileCommand;
            }
        }


        private MediaOpenFolderCommand _mediaOpenFolderCommand = new MediaOpenFolderCommand();
        public MediaOpenFolderCommand OpenFolderCommand
        {
            get
            {
                if (_mediaOpenFolderCommand.ViewModel == null)
                {
                    _mediaOpenFolderCommand.ViewModel = this;
                }

                return _mediaOpenFolderCommand;
            }
        }


    }
}
