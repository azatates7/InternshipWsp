using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUser.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required] 
        public int UserNo { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string UserFirstName { get; set; } 
        public string UserLastName { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}