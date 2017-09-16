namespace Bangazon.Models
{
    public class OrderLineItemsListResult
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Product_ID { get; set; }
        public int Payment_ID { get; set; }
        public bool IsActive { get; set; }
    }
}
