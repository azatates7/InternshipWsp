using FluentValidation;
using SolutionLayer.MsSQL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.UserKey).NotEmpty();
            //RuleFor(p => p.UserName).Must(UserKeyNotStartWithZero);
        }

        private bool UserKeyNotStartWithZero(string arg)
        {
            char[] chars = arg.ToCharArray();
            if(chars[arg.Length - 1] == 0)
            {
                return false;
            }
            return true;
        }
    }
} 