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

        private IEnumerable<MediaFile> _medias = new List<MediaFile>();
        public IEnumerable<MediaFile> Medias
        {
            get
            {
                return _medias;
            }
            private set
            {
                if (_medias != value)
                {
                    _medias = value;
                    RaisePropertyChanged("Medias");
                }
            }
        }

        private MediaAccessorResult _result;
        public MediaAccessorResult Result
        {
            get
            {
                return _result;
            }
            private set
            {
                _result = value;
                if (_result != null && _result.ResultCode == (uint)ErrorCode.Success)
                {
                    if (_result.IsOverrideResult)
                    {
                        Medias = _result.Medias;
                    }
                    else
                    {
                        var medias = new List<MediaFile>(_result.Medias);
                        medias.AddRange(Medias);
                        Medias = medias;
                    }
                }
            }
        }

        private RelayCommand _mediaOpenFileCommand;
        public RelayCommand OpenFileCommand
        {
            get
            {
                if (_mediaOpenFileCommand == null)
                {
                    _mediaOpenFileCommand = new RelayCommand(param => Result = _mediaReader.OpenFile((param as IMediaLibraryView).MediaFilename), param => true);
                }
                return _mediaOpenFileCommand;
            }
        }

        private RelayCommand _mediaOpenFolderCommand;
        public RelayCommand OpenFolderCommand
        {
            get
            {
                if (_mediaOpenFolderCommand == null)
                {
                    _mediaOpenFolderCommand = new RelayCommand(param => Result = _mediaReader.OpenFolder((param as IMediaLibraryView).MediaFolderName), param => true);
                }
                return _mediaOpenFolderCommand;
            }
        }

        private RelayCommand _mediaClearCommand;
        public RelayCommand ClearLibraryCommand
        {
            get
            {
                if (_mediaClearCommand == null)
                {
                    _mediaClearCommand = new RelayCommand(param => Medias = new List<MediaFile>(), param => true);
                }
                return _mediaClearCommand;
            }
        }
    }
}
