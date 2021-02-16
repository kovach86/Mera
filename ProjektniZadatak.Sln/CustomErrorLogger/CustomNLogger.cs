using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CustomErrorLogger
{
    public static class CustomNLogger
    {
        public static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
       
        public static void LogException(string msg)
        {
            Logger.Debug(msg);
        }
    }
}
