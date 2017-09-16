using Bangazon.Models;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace Bangazon.DataAccess
{
    public class OrderDataAccess : IRepository<OrderLineItemsListResult>
    {
        public void Add(OrderLineItemsListResult order)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.Execute("Insert into [Order](Customer_ID, Product_ID, Payment_ID, IsActive) " +
                                                        "Values(@customer_id, @product_id, @payment_id, @isActive)",
                                                        new { Customer_ID = order.Customer_ID, Product_ID = order.Product_ID, Payment_ID = order.Payment_ID, IsActive = order.IsActive });
            }
        }
    }
}


