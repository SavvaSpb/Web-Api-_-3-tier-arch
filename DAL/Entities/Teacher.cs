using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Teacher
    {
        [Key]
        public int TeachersId { get; set; }

        [Required]
        [Column("first_name", Order = 0)]
        public string FirstName { get; set; }

        [Column("last_name", Order = 1)]
        public string LastName { get; set; }

        [Column("birthday", Order = 2)]
        public DateTime? Birthday { get; set; }

        [Column("address", Order = 3)]
        public string? Address { get; set; }

        [Column("phone", Order = 4)]
        public string? Phone { get; set; }

        [Column("email", Order = 5)]
        public string Email { get; set; }

    }
}
