using Bangazon.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web.Http;

namespace Bangazon.DataAccess
{
    public class ProductDataAccess
    {
        public List<ProductItem> GetAll()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.Query<ProductItem>("select * " +
                                                            "from Products");
                return result.ToList();
            }
        }

        public int Post(ProductItem product)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                var results = connection.Execute("Insert into Products(ProductName, Quantity, Price, Description)" +
                                                    "Values(@ProductName, @Quantity, @Price, @Description)",
                                                    new { ProductName = product.ProductName, Quantity = product.Quantity, Price = product.Price, Description = product.Description });
                return results;
            }
        }

        public int SetOutOfStock(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();
                var results = connection.Execute("Update Products " +
                                       "SET Quantity = 0 " +
                                       "WHERE ProductID = @productID ", new { productID = id });
                return results;
            }
        }

        public int UpdateInventory(int id, int CartAmount)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {

                var SelectedProductCount = GetSingle(id).Quantity;
                connection.Open();

                if (CartAmount > SelectedProductCount)
                {
                    return 0;
                }

                else
                {

                    var newQuantity = SelectedProductCount - CartAmount;

                    var results = connection.Execute
                                           ("Update Products " +
                                           "SET Quantity = @Quantity " +
                                           "WHERE ProductID = @ProductID ",
                                           new
                                           {
                                               ProductID = id,
                                               Quantity = newQuantity
                                           });
                    return results;
                }

            }
        }

        public ProductItem GetSingle(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.QueryFirstOrDefault<ProductItem>("SELECT * " +
                                                                            "FROM Products " +
                                                                            "WHERE ProductID = @productID ",
                                                                            new { productID = id });
                return result;


            }

        }
    }
}