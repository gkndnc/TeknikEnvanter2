using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    public class Logger
    {
        #region Private Fields

        private static NLog.Logger _nLogger;

        #endregion Private Fields

        #region Constructor

        static Logger()
        {
            NLogger = LogManager.GetCurrentClassLogger();
        }

        #endregion Constructor

        #region Private Properties

        private static NLog.Logger NLogger
        {
            get
            {
                return _nLogger;
            }
            set
            {
                _nLogger = value;
            }
        }

        private static bool _isLoggable = false;


        private static void log(LogLevel level, string message)
        {
            NLogger.Log(level, message);
        }

        private static void log(LogLevel level, string message, string[] parameters)
        {
            NLogger.Log(level, message, parameters);
        }

        #endregion Private Properties

        #region Public Properties

        public static void LogInfo(string message)
        {

            log(LogLevel.Info, message);

        }

        public static void LogInfo(string message, string[] parameters)
        {

            log(LogLevel.Info, message, parameters);

        }

        public static void LogException(string message)
        {

            log(LogLevel.Error, message);

        }

        public static void LogException(string message, string[] parameters)
        {
            log(LogLevel.Error, message, parameters);
        }

        #endregion Public Properties
    }
}

