using PostSharp.Aspects;
using SolutionLayer.Core.CrossCuttingConcerns.Caching;
using System;
using System.Linq;
using System.Reflection;

namespace SolutionLayer.Core.Aspects.PostSharp.CacheAspect
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private readonly Type _cacheType;
        private readonly int _cacheminute;
        private ICacheManager _cachemanager;

        public CacheAspect(System.Type cachetyp, int cacheminute=60) // 60 minute
        {
            _cacheType = cachetyp;
            _cacheminute = cacheminute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if(typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Used Wrong CacheManager Type");
            }
            _cachemanager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodname = string.Format("{0}.{1}.{2}", // namespace class methodname
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);

            var arguments = args.Arguments.ToList();

            var key = string.Format("{0}({1})", methodname,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<null>"))); // maybe Null

            if (_cachemanager.IsAdd(key))
            {
                args.ReturnValue = _cachemanager.Get<object>(key);
            }
            base.OnInvoke(args);
            _cachemanager.Add(key, args.ReturnValue, _cacheminute);
        }

    }
} 