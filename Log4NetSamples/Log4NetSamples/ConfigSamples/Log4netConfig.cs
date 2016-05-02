using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using log4net;
using log4net.Config;

//[assembly: log4net.Config.XmlConfigurator( ConfigFile = "Log4netConfig", Watch = true )]
namespace NewsSmith.App_Start
{
    public class Log4netConfig
    {
        private static ILog log = LogManager.GetLogger(typeof(Log4netConfig));

        public static void Start()
        {

            var configFile = ""; // ConfigurationManager.AppSettings.Get("Log4netConfig");
            if (!string.IsNullOrEmpty(configFile))
            {
                configFile = Environment.ExpandEnvironmentVariables(configFile);
                log4net.GlobalContext.Properties["ApplicationName"] = Assembly.GetExecutingAssembly().GetName().Name;
                XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));

                if (log.IsDebugEnabled)
                {
                    log.DebugFormat("載入Log4net Config 設定檔 {0} ", configFile);
                }
            }

            if (log.IsDebugEnabled)
            {
                log.DebugFormat("Log4Net 從 Log4netConfig 設定完成");
            }
        }
    }
}