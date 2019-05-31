using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.Common
{
    public class MediaAccessorResult
    {
        public uint ResultCode { get; set; }

        public bool IsOverrideResult { get; set; }

        public MediaFile FirstMedia
        {
            get
            {
                return (Medias == null || Medias.Count == 0) ? null : Medias[0];
            }
        }

        public List<MediaFile> Medias { get; set; }

        public MediaAccessorResult(uint result)
        {
            ResultCode = result;
            IsOverrideResult = false;
        }

        public MediaAccessorResult(uint result, MediaFile media)
            :this(result)
        {
            Medias = new List<MediaFile>();
            Medias.Add(media);
        }

        public MediaAccessorResult(uint result, MediaFile media, bool isOverrideResult)
            :this(result, media)
        {
            IsOverrideResult = isOverrideResult;
        }

        public MediaAccessorResult(uint result, List<MediaFile> medias)
            :this(result)
        {
            Medias = medias;
        }

        public MediaAccessorResult(uint result, List<MediaFile> medias, bool isOverrideResult)
            :this(result, medias)
        {
            IsOverrideResult = isOverrideResult;
        }
    }
}
