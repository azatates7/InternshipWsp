using FluentValidation;
using Ninject.Modules;
using SolutionLayer.MsSQL.Business.ValidationRules.FluentValidation;

namespace SolutionLayer.MsSQL.Business.DependencyResolver.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator>().To<UserValidator>().InSingletonScope();
        }
    }
}