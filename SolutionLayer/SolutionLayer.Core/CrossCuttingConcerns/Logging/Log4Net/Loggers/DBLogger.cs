using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DBLogger : LoggerService
    {
        public DBLogger() : base(LogManager.GetLogger("DBLogger"))
        {

        }
}
}
