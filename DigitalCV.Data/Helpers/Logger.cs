using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Helpers
{
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        
        public void LogError(string className, string model, string exceptionMessage, string innerException, [CallerMemberName] string callerMemberName = "")
        {
            log.Error(className +"."+ callerMemberName + "\nModel - " + model + "\n" + "Exception: " + exceptionMessage + "\n" + "Inner Exception: " + innerException + "\n");
        }

        public void LogErrorWithUser(string className, string model, string exceptionMessage, string innerException, string user, [CallerMemberName] string callerMemberName = "")
        {
            log.Error(className + "." + callerMemberName + "\nUser: " + user + "\nModel - " + model + "\n" + "Exception: " + exceptionMessage + "\n" + "Inner Exception: " + innerException + "\n");
        }
    }
}
