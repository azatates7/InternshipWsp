using System.ComponentModel.DataAnnotations;

namespace WebApiSecurity.Models
{
    public class Security
    {
        [Key]
        [Required]
        public int SecId { get; set; }
        public string SecName { get; set; }
        public string Description { get; set; }
    }
} 