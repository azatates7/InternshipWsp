using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolutionLayer.Core.CrossCuttingConcerns.Caching.MicrosoftCaching
{
    public class MemoryCacheManager : ICacheManager
    { 
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Add(string key, object data, int cachetime=60)
        {
            if (data == null)
            {
                return;
            }
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cachetime)
            };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }
         
        public void Removebypattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline|RegexOptions.Compiled|RegexOptions.IgnoreCase);
            var keysoremove = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key).ToList();

            foreach (var item in keysoremove)
            {
                Remove(item);
            }
        }
         
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}