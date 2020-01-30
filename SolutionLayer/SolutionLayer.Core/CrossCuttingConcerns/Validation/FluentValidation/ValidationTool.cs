using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SolutionLayer.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidationTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var rs = validator.Validate(entity);
            if(rs.Errors.Count > 0){
                throw new ValidationException("Validation Error : "+rs.Errors);
            }
        }
    }
} 