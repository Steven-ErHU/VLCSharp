using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.MediaPlayer.MediaLib
{
    public enum MediaState
    {
        //
        // Summary:
        //     Nothing special happening
        NothingSpecial = 0,
        //
        // Summary:
        //     Opening media
        Opening = 1,
        //
        // Summary:
        //     Buffering media
        Buffering = 2,
        //
        // Summary:
        //     Playing media
        Playing = 3,
        //
        // Summary:
        //     Paused media
        Paused = 4,
        //
        // Summary:
        //     Stopped media
        Stopped = 5,
        //
        // Summary:
        //     Ended media
        Ended = 6,
        //
        // Summary:
        //     Error media
        Error = 7
    }
}
