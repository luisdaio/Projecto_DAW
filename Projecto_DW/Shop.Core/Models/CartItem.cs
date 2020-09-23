namespace Shop.Core.Models
{
    public class CartItem : BaseEntity
    {
        public string CartId { get; set; }
        public string WatchId { get; set; }
        public int Quantity { get; set; }

    }
}