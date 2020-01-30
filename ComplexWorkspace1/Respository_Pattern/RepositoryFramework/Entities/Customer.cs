using Respository_Pattern.RepositoryFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework.Entities
{
    public class Customer:IEntity
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
    }
} 