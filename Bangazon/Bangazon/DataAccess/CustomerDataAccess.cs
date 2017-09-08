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
    }
}