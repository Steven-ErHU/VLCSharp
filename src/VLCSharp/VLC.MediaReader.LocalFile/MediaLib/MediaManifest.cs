using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VLC.Common;

namespace VLC.MediaPlayer.MediaLib
{
    internal class MediaManifest
    {
        static public uint ReadFromXML(string filename)
        {

            return 0;
        }

        static public uint WriteToXML(string filename, MediaFileNode node)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return (uint)ErrorCode.FileNotExists;
            }

            var root = new XElement("VLCMediaLib", new XAttribute("DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))) ;

            WriteToXmlRecur(node, root);

            var document = new XDocument();

            document.Add(root);

            document.Save(filename);

            return (uint)ErrorCode.Success;
        }

        static private uint WriteToXmlRecur(MediaFileNode node, XElement xParent)
        {
            if(node.ChildrenNode.Count == 0 && node.Children.Count == 0)
            {
                return (uint)ErrorCode.Success;
            }

            var element = new XElement("Folder", new XAttribute("Directory", node.Source),
                from media in node.Children
                select new XElement("File", new XAttribute("Filename", media.Source)));

            xParent.Add(element);

            foreach(var n in node.ChildrenNode)
            {
                WriteToXmlRecur(n, element);
            }

            return (uint)ErrorCode.Success;
        }

    }
}
