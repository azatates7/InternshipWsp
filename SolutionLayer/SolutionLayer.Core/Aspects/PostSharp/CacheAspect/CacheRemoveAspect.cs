using PostSharp.Aspects;
using SolutionLayer.Core.CrossCuttingConcerns.Caching;
using System;
using System.Reflection;

namespace SolutionLayer.Core.Aspects.PostSharp.CacheAspect
{
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private readonly string _pattern;
        private readonly Type _cacheType;
        private ICacheManager _cachemanager; // Used Field not readonly

        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }

        public CacheRemoveAspect(string pattern, Type cacheType)
        {
            _cacheType = cacheType;
            _pattern = pattern;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Used Wrong CacheManager Type");
            }
            _cachemanager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cachemanager.Removebypattern(string.IsNullOrEmpty(_pattern)
                ? string.Format("{ 0 }.{ 1 }.*", 
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name
                ) : _pattern); 
        }

    }
} 