using Bangazon.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Dapper;

namespace Bangazon.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        //api/customer
        [HttpGet, Route("")] //-> route prefix, adds the prefix to the route attributes going forward
        public HttpResponseMessage GetAll()
        {
            try
            {
                var customerData = new CustomerDataAccess();
                var customers = customerData.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query blew up");
            }
        }
    }
}