using Bangazon.Models;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace Bangazon.DataAccess
{
    public class OrderLineItemsDataAccess : IRepository<OrderLineItemsListResults>
    {
        public void Add(OrderLineItemsListResults orderItem)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.Execute("Insert into OrderLineItems(OrderID, ProductID, UnitPrice, Quantity) " +
                                                        "Values(@orderId, @productId, @unitPrice, @quantity)",
                                                        new { OrderID = orderItem.OrderID, ProductID = orderItem.ProductID, UnitPrice = orderItem.UnitPrice, Quantity = orderItem.Quantity});
            }
        }
    }
}