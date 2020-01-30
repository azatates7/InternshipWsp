using log4net.Core;
using System;

namespace SolutionLayer.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _logginegvent;

        public SerializableLogEvent(LoggingEvent logginegvent)
        {
            _logginegvent = logginegvent;
        }

        public string Username => _logginegvent.UserName;
        public object MessageObject => _logginegvent.MessageObject;
    }
}