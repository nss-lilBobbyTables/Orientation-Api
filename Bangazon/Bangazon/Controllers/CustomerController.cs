using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bangazon.Models;
using Bangazon.DataAccess;

namespace Bangazon.Controllers
{
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
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Add customer blew up", ex);
                };
            
        }
    }
}



