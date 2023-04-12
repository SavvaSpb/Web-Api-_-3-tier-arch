using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Student
    {
        [Key]
        [Column("student_id", Order = 0)]
        public int StudentId { get; set; }

        [Required]
        [Column("first_name", Order = 1)]
        public string FirstName { get; set; }

        [Column("last_name", Order = 2)]
        public string LastName { get; set; }

        [Column("birthday", Order = 3)]
        public DateTime? Birthday { get; set; }

        [Column("address", Order = 4)]
        public string Address { get; set; }

        [Column("phone", Order = 5)]
        public string Phone { get; set; }

        [Column("email", Order = 6)]
        public string Email { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }

    }
}
