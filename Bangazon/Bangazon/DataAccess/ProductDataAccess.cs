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
                var results = connection.Execute("Insert into Products(ProductName, InStock, Price, Description)" +
                                                    "Values(@ProductName, @InStock, @Price, @Description)",
                                                    new { ProductName = product.ProductName, InStock = product.InStock, Price = product.Price, Description = product.Description });
                return results;
            }
        }
    }
}