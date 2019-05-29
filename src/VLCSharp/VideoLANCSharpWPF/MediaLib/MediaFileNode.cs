using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.MediaPlayer.MediaLib
{
    public class MediaFileNode
    {
        public List<MediaFile> Children { get; set; }
        public List<MediaFileNode> ChildrenNode { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public int Count
        {
            get
            {
                return Children == null ? 0 : Children.Count;
            }
        }

        public MediaFileNode Parent { get; set; }

        public bool IsRoot { get; set; }

        public MediaFileNode()
        {
            Children = new List<MediaLib.MediaFile>();
            ChildrenNode = new List<MediaLib.MediaFileNode>();
        }
    }
}
