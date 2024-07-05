using System.ComponentModel.DataAnnotations;

namespace School_Management.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int studentID { get; set; }
        [Required]

        public string name { get; set; }
        [Required]

        public string emailID { get; set; }
        [Required]

        public string standard { get; set; }
        [Required]

        public string  location { get; set; }
    }
}
