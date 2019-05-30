using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.Common
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
            Children = new List<MediaFile>();
            ChildrenNode = new List<MediaFileNode>();
        }
    }

    public class MediaAccessorResult
    {
        public uint Result { get; set; }

        public MediaFile FirstMedia
        {
            get
            {
                return (MediaNode.Children == null || MediaNode.Children.Count == 0) ? null : MediaNode.Children[0];
            }
        }

        public MediaFileNode MediaNode { get; set; }

        public MediaAccessorResult(uint result)
        {
            Result = result;
        }

        public MediaAccessorResult(uint result, MediaFile media)
        {
            Result = result;
            MediaNode = new MediaFileNode();
            MediaNode.Children.Add(media);
        }

        public MediaAccessorResult(uint result, MediaFileNode mediaNode)
        {
            Result = result;
            MediaNode = mediaNode;
        }
    }
}
