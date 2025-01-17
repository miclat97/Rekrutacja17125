namespace Rekrutacja_170125.Entities
{
    public class OrderProductEntity
    {
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public int Quantity { get; set; }
    }
}
