using System.ComponentModel.DataAnnotations;

namespace School_Management.Models
{
    public class SchoolLoginModel
    {
        [Key]
        [Required]
        public int MyProperty { get; set; }
        [Required]
        public string emailID { get; set; }
        [Required]
        public string password { get; set; }
    }
}
