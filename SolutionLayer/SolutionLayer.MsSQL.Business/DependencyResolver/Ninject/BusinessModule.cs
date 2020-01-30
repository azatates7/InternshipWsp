using Ninject.Modules;
using SolutionLayer.Core.DAL;
using SolutionLayer.Core.DAL.EntityFramework;
using SolutionLayer.MsSQL.Business.Abstract;
using SolutionLayer.MsSQL.Business.Concrete.Managers;
using SolutionLayer.MsSQL.DAL.Abstaract;
using SolutionLayer.MsSQL.DAL.Concrete;
using System.Data.Entity;

namespace SolutionLayer.MsSQL.Business.DependencyResolver.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDAL>().To<EFUserDAL>();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EFQueryableRepository<>));
            Bind<DbContext>().To<MsSQLContext>();
        }
    }
}