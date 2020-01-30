using Respository_Pattern.RepositoryFramework3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework3.Entities
{
    public class Worker:IEntity2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string  wordep { get; set; }
    }
}