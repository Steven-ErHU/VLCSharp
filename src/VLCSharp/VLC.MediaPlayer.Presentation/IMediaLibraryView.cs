using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.MediaPlayer.Presentation
{
    public interface IMediaLibraryView
    {
        string MediaFilename { get; }
        string MediaFolderName { get; }
    }
}
