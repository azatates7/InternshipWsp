using PostSharp.Aspects;
using PostSharp.Extensibility;
using SolutionLayer.Core.CrossCuttingConcerns.Logging;
using SolutionLayer.Core.CrossCuttingConcerns.Logging.Log4Net;
using System; 
using System.Linq;
using System.Reflection; 

namespace SolutionLayer.Core.Aspects.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = // Run Aspect Over Class , Disable Constructor Logging
            MulticastAttributes.Instance)]

    public class LogAspect:OnMethodBoundaryAspect
    {
        private readonly Type _loggertype;
        private LoggerService _loggerService;
        public LogAspect(Type loggertype)
        {
            _loggertype = loggertype;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if(_loggertype.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Type");
            }
            _loggerService= (LoggerService)Activator.CreateInstance(_loggertype);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                var logparameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name, // t == type // i == iterator
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logdetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType?.Name, // null => null not null=> name
                    MethodName = args.Method.Name,
                    LoggingParameters = logparameters,

                };

                _loggerService.Info(logdetail);
            }
            catch
            {

            }
        }
    } 
}