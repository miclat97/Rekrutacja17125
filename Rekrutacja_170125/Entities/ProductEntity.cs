using System.ComponentModel.DataAnnotations;

namespace Rekrutacja_170125.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal NetPrice { get; set; }

        [Required]
        public decimal GrossPrice { get; set; }

        public virtual ICollection<OrderProductEntity> OrderProducts { get; set; }
    }
}
