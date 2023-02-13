using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Course
    {
        [Key]
        public int CoursesId { get; set; }


        [Required]
        [Column(Order = 1)]
        public string CoursesTypeName { get; set; }


        [Column(Order = 2)]
        [ForeignKey(nameof(Institute))]
        public int InstituteId { get; set; }
        public Institute Institute { get; set; }


        [Column(Order = 3)]
        [ForeignKey(nameof(Teachers))]
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }


        [Column(Order = 4)]
        public int Salary { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }

    }
}
