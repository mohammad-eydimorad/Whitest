using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Core.Configuration;

namespace ISC.Whitest.Web.Core.Logging
{
    public static class Logger
    {
        //TODO: this whole class is for test, use a logging framework instead (NLog, Log4Net)
        private static string filename = "";
        private static object syncLock = new object();
        static Logger()
        {
            var logPath = ConfigurationService.GetValueSafe<string>(ConfigKeys.LogFolder);
            if (string.IsNullOrEmpty(logPath))
                throw new Exception("Log folder is not in config file !");

            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);

            filename = Path.Combine(logPath, $"{DateTime.Now.Ticks}.txt");
        }

        public static void Write(string message)
        {
            lock (syncLock)
            {
                File.AppendAllText(filename, Environment.NewLine + message);
            }
        }
    }
}
