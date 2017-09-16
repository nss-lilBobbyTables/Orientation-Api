﻿using Bangazon.Models;
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
    public class OrderDataAccess 
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

        public List<OrderListResult> Get()
        {
            using (var connection =
               new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = @"SELECT Order_ID,
                                Customer_ID,
                                Product_ID,
                                Payment_ID,
                                IsActive
                                FROM [dbo].[Order]
                                WHERE IsActive = 'true'";

                {
                    return connection.Query<OrderListResult>(result).ToList();
                }
            }
        }

     
    }
}


