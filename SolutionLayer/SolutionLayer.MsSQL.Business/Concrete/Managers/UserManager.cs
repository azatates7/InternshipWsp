using SolutionLayer.MsSQL.Business.Abstract;
using SolutionLayer.MsSQL.Business.ValidationRules.FluentValidation;
using SolutionLayer.Core.Aspects.PostSharp;
using SolutionLayer.MsSQL.Entities.Concrete;
using System.Collections.Generic;
using SolutionLayer.MsSQL.DAL.Abstaract;
using SolutionLayer.Core.Aspects.PostSharp.ScopeAspects;
using SolutionLayer.Core.Aspects.PostSharp.CacheAspect;
using SolutionLayer.Core.CrossCuttingConcerns.Caching.MicrosoftCaching;
using SolutionLayer.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using SolutionLayer.Core.Aspects.PostSharp.LogAspects;

namespace SolutionLayer.MsSQL.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userdal;

        public UserManager(IUserDAL userdal)
        {
            _userdal = userdal;
        }
         
        [CacheAspect(typeof(MemoryCacheManager), 120)] // for use default delete ", 120" (60 minute)
        [LogAspect(typeof(DBLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<User> GetData()
        {
            return _userdal.GetList();
        }

        [FluentValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public User Add(User user)
        {
            return _userdal.Add(user);
        }  

        [FluentValidationAspect(typeof(UserValidator))]
        public User Update(User user)
        {
            return _userdal.Update(user);
        }

        //[TransactionScopeAspect]
        public void TransactionOperation(User usr1, User usr2)
        {
            _userdal.Add(usr1);
            _userdal.Add(usr2);
        }

    }
}