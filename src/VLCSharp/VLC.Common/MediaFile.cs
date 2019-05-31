using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.Common
{
    public class MediaFile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string FileType { get; set; }
        public string Source { get; set; }
        public int Depth { get; set; }

        private long _size;
        public long Size
        {
            get { return _size; }
            set
            {
                _size = value;
                SizeText = GetSizeText(_size);
            }
        }
        public string SizeText { get; set; }
        public MediaState State { get; set; }

        private string GetSizeText(long size)
        {
            if (size < 0)
            {
                return "0 Bytes";
            }

            string[] sizes = { "Bytes", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (size >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                size = size / 1024;
            }
            return String.Format("{0:0.##} {1}", size, sizes[order]);
        }
    }
}
