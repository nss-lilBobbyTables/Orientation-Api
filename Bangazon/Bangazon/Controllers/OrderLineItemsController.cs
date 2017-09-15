using System.Web;
using Bangazon.Models;
using Bangazon.DataAccess;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bangazon.Controllers
{
    public class OrderLineItemsController : ApiController
    {
        //api/Order
        public HttpResponseMessage Post(OrderListResult order)
        {
            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
                try
                {
                    var addOrderLineItemsData = new OrderLineItemsDataAccess();
                    addOrderLineItemsData.Add(order);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Add order blew up", ex);
                };
        }
    }
}

