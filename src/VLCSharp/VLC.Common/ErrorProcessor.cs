using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLC.Common
{
    public class ErrorProcessor
    {
        static public string GetErrorMesage(uint errorCode)
        {
            string msg = string.Empty;

            switch (errorCode)
            {
                case 31: msg = "File not exists"; break;
                default: msg = "Unknow Error!"; break;

            }
            return msg;
        }
    }

    public enum ErrorCode
    {
        Success = 0,
        FileNotExists = 31,
        PathNotExists = 41,
        PathIsEmpty = 42,
    }
}
