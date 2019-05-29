using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLC.Common;

namespace VLC.MediaPlayer.MediaLib
{
    internal class MediaAccessor
    {
        static private MediaFileNode _rootMediaNode;
        

        static public MediaAccessorResult OpenFile(string filename)
        {
            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                return new MediaAccessorResult((uint)ErrorCode.FileNotExists);
            }

            MediaFile mf = new MediaFile();
            var fileInfo = new FileInfo(filename);

            mf.Name = fileInfo.Name;
            mf.FileType = Path.GetExtension(fileInfo.FullName);
            mf.Size = fileInfo.Length;
            mf.Source = filename;

            return new MediaAccessorResult((uint)ErrorCode.Success, mf);
        }

        static public MediaAccessorResult OpenFolder(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                return new MediaAccessorResult((uint)ErrorCode.PathNotExists);
            }

            var di = new DirectoryInfo(path);
            FileInfo[] fis = di.GetFiles("*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] dis = di.GetDirectories("*", SearchOption.TopDirectoryOnly);

            if ((fis == null || fis.Length == 0) && (dis == null || dis.Length == 0))
            {
                return new MediaAccessorResult((uint)ErrorCode.PathIsEmpty);
            }

            _rootMediaNode = new MediaFileNode
            {
                IsRoot = true,
                Name = di.Name,
                Source = path,
            };

            var result = OpenSubFolderFiles(_rootMediaNode);

            return new MediaAccessorResult((uint)ErrorCode.Success, _rootMediaNode);
        }

        static private uint OpenSubFolderFiles(MediaFileNode parent)
        {
            if (parent == null || string.IsNullOrEmpty(parent.Source) || !Directory.Exists(parent.Source))
            {
                return (uint)ErrorCode.PathNotExists;
            }

            var di = new DirectoryInfo(parent.Source);
            FileInfo[] fis = di.GetFiles("*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] dis = di.GetDirectories("*", SearchOption.TopDirectoryOnly);

            if ((fis == null || fis.Length == 0) && (dis == null || dis.Length == 0))
            {
                return(uint)ErrorCode.PathIsEmpty;
            }

            //Open all the files
            Array.ForEach(fis, f =>
            {
                var r = OpenFile(f.FullName);
                parent.Children.Add(r.FirstMedia);
            });

            //Open all the sub folders
            Array.ForEach(dis, d =>
            {
                var n = new MediaFileNode
                {
                    IsRoot = false,
                    Name = d.Name,
                    Source = d.FullName,
                    Parent = parent,
                };

                parent.ChildrenNode.Add(n);
                OpenSubFolderFiles(n);
            });

            return (uint)ErrorCode.Success;
        }

    }

    internal class MediaAccessorResult
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
