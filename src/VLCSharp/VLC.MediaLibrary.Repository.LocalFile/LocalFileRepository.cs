using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLC.Common;

namespace VLC.MediaLibrary.Repository.LocalFile
{
    public class LocalFileRepository : IMediaReader
    {
        public MediaAccessorResult OpenFile(string filename)
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

        public MediaAccessorResult OpenFolder(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                return new MediaAccessorResult((uint)ErrorCode.PathNotExists);
            }

            var di = new DirectoryInfo(path);
            FileInfo[] fis = di.GetFiles("*", SearchOption.AllDirectories);
            if (fis == null || fis.Length == 0)
            {
                return new MediaAccessorResult((uint)ErrorCode.PathIsEmpty);
            }

            List<MediaFile> medias = new List<MediaFile>();

            Array.ForEach(fis, fi => 
            {
                MediaFile mf = new MediaFile();
                mf.Name = fi.Name;
                mf.FileType = Path.GetExtension(fi.FullName);
                mf.Size = fi.Length;
                mf.Source = fi.FullName;
                mf.Depth = fi.FullName.Count(c => c == '\\') - path.Count(c => c == '\\');
                medias.Add(mf);
            });

            return new MediaAccessorResult((uint)ErrorCode.Success, medias, true);
        }
    }
}
