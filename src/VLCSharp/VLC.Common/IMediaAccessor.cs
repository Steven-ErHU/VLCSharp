using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.Common
{
    public interface IMediaReader
    {
        MediaAccessorResult OpenFile(string filename);
        MediaAccessorResult OpenFolder(string path);
    }
}
