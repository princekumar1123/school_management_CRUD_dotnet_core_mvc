using System.ComponentModel.DataAnnotations;

namespace School_Management.Models
{
    public class TeacherModel
    {
        [Key]
        [Required]
        public int TeacherID { get; set; }
        [Required]

        public string TeacherName { get; set; }
        [Required]

        public string emailID { get; set; }
        [Required]

        public string subject { get; set; }

        [Required]

        public string standard { get; set; }

    }
}
