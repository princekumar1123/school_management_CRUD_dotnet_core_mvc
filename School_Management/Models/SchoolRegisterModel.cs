using System.ComponentModel.DataAnnotations;

namespace School_Management.Models
{
    public class SchoolRegisterModel
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string emailID { get; set; }
        [Required]
        public string password { get; set; }

        public string phoneNumber { get; set; }
    }
}
