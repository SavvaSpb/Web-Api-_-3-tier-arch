using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Institute
    {
        [Key]
        public int InstituteId { get; set; }

        [Required]
        public string InstituteTypeName { get; set; }

    }
}
