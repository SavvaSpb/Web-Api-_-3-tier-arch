using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DAL.Entities
{
    public class Teacher
    {
        [Key]
        [Column("teacher_id", Order = 0)]
        public int TeacherId { get; set; }

        [Required]
        [Column("first_name", Order = 1)]
        public string FirstName { get; set; }

        [Column("last_name", Order = 2)]
        public string LastName { get; set; }

        [Column("birthday", Order = 3)]
        public DateTime? Birthday { get; set; }

        //todo: make this NOT NULL (required)

        [Column("address", Order = 4)]
        [DefaultValue("Yerevan")]
        public string Address { get; set; }

        [Column("phone", Order = 5)]
        public string Phone { get; set; }

        [Column("email", Order = 6)]
        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 

    }
}
