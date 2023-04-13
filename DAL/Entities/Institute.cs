using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Institute
    {
        [Key]
        [Column("institute_id", Order = 0)]
        public int InstituteId { get; set; }

        [Required]
        [Column("institute_type_name", Order = 1)]
        public string InstituteTypeName { get; set; }
    }
}
