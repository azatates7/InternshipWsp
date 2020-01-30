using SolutionLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.Entities.Concrete
{
    public class Personel:IEntity
    {
        public int PersonelId { get; set; }
        public string PersonelName { get; set; }
        public string PersonelDepartment { get; set; }
    }
} 