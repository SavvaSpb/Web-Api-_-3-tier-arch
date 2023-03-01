using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Course
    {
        [Key]
        [Column("course_id", Order = 0)]
        public int CourseId { get; set; }

        [Required]
        [Column("course_type_name", Order = 1)]
        public string CourseTypeName { get; set; }
        
        [ForeignKey(nameof(Institute))]
        [Column("institute_id", Order = 2)]
        public int InstituteId { get; set; }
        public Institute Institute { get; set; }

        [ForeignKey(nameof(Teacher))]
        [Column("teacher_id", Order = 3)]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Column("salary", Order = 4)]
        public int Salary { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }

    }
}
