using System.ComponentModel.DataAnnotations;

namespace Rekrutacja_170125.Entities
{
    public class ClientEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

    }
}
