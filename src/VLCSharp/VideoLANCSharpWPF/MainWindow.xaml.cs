using LibVLCSharp.Shared;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using VLC.MediaPlayer.MediaLib;

namespace VideoLANCSharpWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = VLC.MediaPlayer.MediaLib.MediaAccessor.OpenFolder(@"C:\_DEVELOPMENT\VLCSharp\Resource\6.LINQ Fundamentals");
            WriteMediaInfo2File(result);
        }

        private void WriteMediaInfo2File(MediaAccessorResult result)
        {
            MediaManifest.WriteToXML(@"C:\MediaManifest.xml", result.MediaNode);




        }
    }
}
