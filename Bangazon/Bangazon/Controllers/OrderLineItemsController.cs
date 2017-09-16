using Bangazon.Models;
using Bangazon.DataAccess;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;

namespace Bangazon.Controllers
{
    [RoutePrefix("api/orderlineitems")]
    public class OrderLineItemsController : ApiController
    {
        //api/OrderLineItems
        [HttpPost, Route("")]
        public HttpResponseMessage Post(List<OrderLineItemsListResults> orderItems)
        {
            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
                try
                {
                    var addOrderLineItemsData = new OrderLineItemsDataAccess();
                    foreach (var orderItem in orderItems)
                    { 
                        addOrderLineItemsData.Add(orderItem);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Add orderlineitems blew up", ex);
                };
        }
    }
}

