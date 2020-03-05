using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcom.Ventures.Ar.EnvioComprobantes.Logger
{
    public static class Logger
    {
        public static void Logueo(string msg, int level)
        {
            string fileLog = "TelcomGestion.txt".ToString().Replace(".txt", DateTime.Now.ToString("ddMMyyyy") + ".log");
            string pathLog = ReadSetting("RutaLog") + fileLog;

            Log.Logger = new LoggerConfiguration()
              .WriteTo.File(@pathLog, fileSizeLimitBytes: 50000)
              .CreateLogger();

            Log.Information("msg");
            if (level == 1)
            {
                Log.Information(msg);
            }
            if (level == 2)
            {
                Log.Error(msg);
            }
            Log.CloseAndFlush();

        }


        private static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return "Not Found";
            }
        }

    }
}
