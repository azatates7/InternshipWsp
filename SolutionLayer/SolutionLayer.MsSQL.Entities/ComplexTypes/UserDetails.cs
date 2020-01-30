using SolutionLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.Entities.ComplexTypes
{
    public class UserDetails:IEntity
    {
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PersonelName { get; set; }
    }
} 