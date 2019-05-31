using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VLC.Common;
using VLC.MediaPlayer.Presentation;

namespace VLC.MediaPlayer.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MediaLibrary : UserControl, IMediaLibraryView
    {
        private MediaLibraryModel _viewModel;

        public string MediaFilename { get; private set; }

        public string MediaFolderName { get; private set; }

        public MediaLibrary(MediaLibraryModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
            _viewModel = viewModel;

            BindSource();
        }

        private void BindSource()
        {
            
        }


        private void btnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "Select Media Path";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MediaFolderName = dialog.SelectedPath;
                _viewModel.OpenFolderCommand.Execute(this);
            }
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MediaFilename = dialog.FileName;
                _viewModel.OpenFileCommand.Execute(this);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearLibraryCommand.Execute(this);
        }
    }
}
