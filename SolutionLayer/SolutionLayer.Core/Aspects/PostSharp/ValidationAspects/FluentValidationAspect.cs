using PostSharp.Aspects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionLayer.Core.CrossCuttingConcerns.Validation.FluentValidation;

namespace SolutionLayer.Core.Aspects.PostSharp
{
    [Serializable]
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        Type _validatortype;
        public FluentValidationAspect(Type  validatortype)
        {
            _validatortype = validatortype;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatortype);
            var entitytype = _validatortype.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(x => x.GetType() == entitytype);

            foreach (var item in entities)
            {
                ValidationTool.FluentValidate(validator, item);
            }
        }
    }
} 