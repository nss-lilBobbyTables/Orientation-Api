namespace Bangazon.Models
{
    public class OrderLineItemsListResults
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}