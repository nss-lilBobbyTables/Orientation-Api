namespace Bangazon.Models
{
    public class CustomerListResult
    {
        public int Customer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}