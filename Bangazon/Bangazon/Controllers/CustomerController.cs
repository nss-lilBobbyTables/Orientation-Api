using Bangazon.DataAccess;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Http;
using Bangazon.Models;
using Bangazon.DataAccess;

namespace Bangazon.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {

        //api/Customer
        public HttpResponseMessage Post(CustomerListResult customer)
        {
            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
                try
                {
                    var addCustomerData = new CustomerDataAccess();
                    addCustomerData.Add(customer);

                    return Request.CreateResponse(HttpStatusCode.OK);
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query blew up");
            }
        }
        
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
}



