using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Add(string key, object data, int cachetime);
        bool IsAdd(string key);
        void Remove(string key);
        void Removebypattern(string pattern);
        void Clear();
    }
} 