using log4net.Layout;
using log4net.Core;
using System;
using System.IO;
using Newtonsoft.Json;

namespace SolutionLayer.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            throw new NotImplementedException();
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logevent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logevent, Formatting.Indented); // write classic json format
            writer.WriteLine(json);
        }
    }
}
