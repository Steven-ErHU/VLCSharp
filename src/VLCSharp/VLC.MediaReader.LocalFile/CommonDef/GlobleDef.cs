using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.MediaPlayer.CommonDef
{
    class GlobleDef
    {
    }

    public static class LogProcessor
    {
        public static void AddLog(string logText, bool isShowMsg = false)
        {
            //TODO:log
            //...........

            if (isShowMsg)
            {
                ShowMsg(logText);
            }
        }

        private static void ShowMsg(string logText)
        {

        }
    }
}
