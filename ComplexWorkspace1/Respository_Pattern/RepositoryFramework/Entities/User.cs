using Respository_Pattern.RepositoryFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework.Entities
{

    public class User:IEntity
    {  
        public int id { get; set; }
        public string name { get; set; }
        public string userkey { get; set; }
    }
} 