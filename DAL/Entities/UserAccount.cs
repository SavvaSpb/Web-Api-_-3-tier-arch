using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DAL.Entities
{
    public class UserAccount
    {
        [Key]
        [Column("user_account_id", Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column("email", Order = 1)]
        public string Email { get; set; }

        [Column("password", Order = 2)]
        public string? Password { get; set; }

        [Column("phone", Order = 3)]
        public string? Phone { get; set; }

    }
}
