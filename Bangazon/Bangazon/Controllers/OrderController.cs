using Bangazon.Models;
using Bangazon.DataAccess;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Bangazon.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        //api/Order
        [HttpPost, Route("")]
        public HttpResponseMessage Post(OrderListResult order)
        {
            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
                try
                {
                    var addOrderData = new OrderDataAccess();
                    addOrderData.Add(order);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Add order blew up", ex);
                };

        }

        //api/order/outstanding
        [HttpGet, Route("outstanding")]
        public HttpResponseMessage Get()
        {

            try
            {
                var orderData = new OrderDataAccess();
                var orders = orderData.Get();
                if (orders == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No outstanding order found");
                }

                return Request.CreateResponse(HttpStatusCode.OK, orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "This is why we can't have nice things", ex);
            }
        }

        //api/order/paid
        [HttpPut, Route("paid/{id}")]
        public HttpResponseMessage SetAsPaid(int id)
        {
            try
            {
                var orderData = new OrderDataAccess();
                var results = orderData.SetAsPaid(id);
                return Request.CreateResponse(HttpStatusCode.Accepted, "Paid!");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "OOPS you", ex);
            }
        }
    }
}

