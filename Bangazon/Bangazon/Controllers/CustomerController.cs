using Bangazon.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

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
        // POST api/employees/
        [HttpPost, Route("")]
        public HttpResponseMessage Post(Models.CustomerItem customer)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                try
                {
                    var customerData = new CustomerDataAccess();
                    var results = customerData.Post(customer);
                    return Request.CreateResponse(HttpStatusCode.Created, $"rows affected, {results}");

                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }
        // PUT api/customers/5
        [HttpPut, Route("update/{id}")]
        public HttpResponseMessage Put(int id, Models.CustomerItem customer)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                try
                {
                    var customerData = new CustomerDataAccess();
                    var results = customerData.Update(id, customer);
                    return Request.CreateResponse(HttpStatusCode.Created, $"rows affected, {results}");

                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }
    }
}