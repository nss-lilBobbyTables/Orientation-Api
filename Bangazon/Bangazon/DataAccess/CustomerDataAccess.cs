using Bangazon.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace Bangazon.DataAccess
{
    public class CustomerDataAccess
    {
        public List<CustomerItem> GetAll()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.Query<CustomerItem>("select * " +
                                                            "from Customers");
                return result.ToList();
            }
        }
        public int Post(CustomerItem customer)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {

                var results = connection.Execute("Insert into Customers(FirstName, LastName, Address, isActive) " +
                                                "Values(@FirstName, @LastName, @Address, @isActive)",
                new { FirstName = customer.FirstName, LastName = customer.LastName, Address = customer.Address, isActive = customer.isActive });
                return results;
            }
        }

        public int Update(int id, CustomerItem customer)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var results = connection.Execute
                                       ("Update Customers " + 
                                       "SET FirstName = @FirstName, " +
                                       "LastName = @LastName, " +
                                       "Address = @Address "  + 
                                       "WHERE Customer_Id = @CustomerID " , 
                                       new
                                       {
                                           CustomerID = id,
                                           FirstName = customer.FirstName,
                                           LastName = customer.LastName,
                                           Address = customer.Address
                                       });
                return results;
            }

        }
    }
}