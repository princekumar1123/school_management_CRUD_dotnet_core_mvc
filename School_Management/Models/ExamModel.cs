using System.ComponentModel.DataAnnotations;

namespace School_Management.Models
{
    public class ExamModel
    {
        [Required]
        [Key]
        public int subjectID { get; set; }
        [Required]

        public string subjectName { get; set; }
        [Required]

        public DateOnly examDate { get; set; }
        [Required]

        public string standard { get; set;}

    }
}
