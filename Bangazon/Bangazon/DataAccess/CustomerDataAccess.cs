using Bangazon.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace Bangazon.DataAccess
{
    public class CustomerDataAccess : IRepository<CustomerListResult>
    {
        public void Add(CustomerListResult customer)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.Execute("Insert into Customer(Firstname, LastName, Address, IsActive) " +
                                                        "Values(@firstName,@lastName, @address, @isActive)",
                                                        new { FirstName = customer.FirstName, LastName = customer.LastName, Address = customer.Address, IsActive = customer.IsActive});
            }
        }
    }
}