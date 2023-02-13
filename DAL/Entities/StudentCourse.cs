using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class StudentCourse
    {
        [Key]
        public int StudentsCoursesId { get; set; }

        [Column("students_id", Order = 1)]
        [ForeignKey(nameof(Student))]
        public int StudentsId { get; set; }

        [Column("courses_id", Order = 2)]
        [ForeignKey(nameof(Course))]
        public int CoursesId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        public int StudentsGrade { get; set; }

    }
}
