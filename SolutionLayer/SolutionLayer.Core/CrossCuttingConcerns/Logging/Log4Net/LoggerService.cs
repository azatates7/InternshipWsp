using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerService 
    {
        private readonly ILog _log;

        public LoggerService(ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsDebuggEnabled => _log.IsDebugEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;

        public void Info(Object Message)
        {
            if (IsInfoEnabled)
            {
                _log.Info(Message);
            }
        }

        public void Error(Object Message)
        {
            if (IsErrorEnabled)
            {
                _log.Error(Message);
            }
        }

        public void Debug(Object Message)
        {
            if (IsDebuggEnabled)
            {
                _log.Debug(Message);
            }
        }

        public void Fatal(Object Message)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(Message);
            }
        }

        public void Warn(Object Message)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(Message);
            }
        }
    }
} 