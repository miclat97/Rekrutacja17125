using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Rekrutacja_170125.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ShopEntity")]
        public int ShopId { get; set; }
        public virtual ShopEntity Shop { get; set; }

        [ForeignKey("ClientEntity")]
        public int ClientId { get; set; }
        public virtual ClientEntity Client { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }

    public enum PaymentMethod
    {
        Cash,
        Card,
        Transfer
    }

}
