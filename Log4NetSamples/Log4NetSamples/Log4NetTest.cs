using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Log4NetSamples
{
    [TestClass]
    public class Log4NetTest
    {
        public Log4NetTest()
        {
            // Another watch log4net configuration 
            // log4net.Config.XmlConfigurator.Configure();

            // Set ApplicationName
            log4net.GlobalContext.Properties["ApplicationName"] = Assembly.GetExecutingAssembly().GetName().Name;
            log4net.GlobalContext.Properties["CurrentDirectory"] =
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        [TestMethod]
        public void Test_LogMethod()
        {
            ILog log = LogManager.GetLogger(this.GetType());

            log.Info("Hello World");
            log.InfoFormat("Hello World {0}", DateTime.Now);

            // 其他 Level 的記錄方式
            log.Logger.Log(null, Level.Notice, "Notice !!", null);
        }
    }
}
