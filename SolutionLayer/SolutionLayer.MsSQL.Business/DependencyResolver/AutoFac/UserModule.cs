using Autofac;
using SolutionLayer.Core.DAL;
using SolutionLayer.Core.DAL.EntityFramework;
using SolutionLayer.MsSQL.Business.Abstract;
using SolutionLayer.MsSQL.Business.Concrete.Managers;
using SolutionLayer.MsSQL.DAL.Abstaract;
using SolutionLayer.MsSQL.DAL.Concrete;
using System.Data.Entity;

namespace SolutionLayer.MsSQL.Business.DependencyResolver.AutoFac
{
    public class UserModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IUserService>().As<UserManager>();
            builder.RegisterType<IUserDAL>().As<EFUserDAL>();
            builder.RegisterType(typeof(IQueryableRepository<>)).As(typeof(EFQueryableRepository<>));
            builder.RegisterType<DbContext>().As<MsSQLContext>();
            base.Load(builder);
        }
    }
} 