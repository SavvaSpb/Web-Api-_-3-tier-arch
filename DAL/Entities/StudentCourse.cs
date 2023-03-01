using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class StudentCourse
    {
        [Key]
        [Column("student_course_id", Order = 0)]
        public int StudentCourseId { get; set; }

        [Column("student_id", Order = 1)]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        [Column("course_id", Order = 2)]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        [Column("student_grade", Order = 3)]
        public int StudentGrade { get; set; }

    }
}
