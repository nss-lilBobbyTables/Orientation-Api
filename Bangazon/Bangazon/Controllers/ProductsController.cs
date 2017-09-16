using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using Bangazon.DataAccess;

namespace Bangazon.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductsController : ApiController
    {
        //api/product
        [HttpGet, Route("")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var productData = new ProductDataAccess();
                var products = productData.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query blew up");
            }
        }

        //post api/product
        [HttpPost, Route("")]
        public HttpResponseMessage Post(Models.ProductItem product)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                try
                {
                    var productData = new ProductDataAccess();
                    var results = productData.Post(product);
                    return Request.CreateResponse(HttpStatusCode.Created, $"rows affected, {results}");
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }

        //PUT api/product/outofstock/{id}
        [HttpPut, Route("outofstock/{id}")]
        public HttpResponseMessage Put(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                try
                {
                    var productData = new ProductDataAccess();
                    var results = productData.SetOutOfStock(id);
                    return Request.CreateResponse(HttpStatusCode.Accepted, "message: Product marked as out of stock");
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }

        //Customers can not order out of stock items
        //api/products/{id}
        [HttpPut, Route("{id}/{cartAmount}")] //-> route prefix, adds the prefix to the route attributes going forward
        public HttpResponseMessage InventoryCheck(int id, int cartAmount)
        {
            try
            {
                var productData = new ProductDataAccess();
                var results = productData.UpdateInventory(id, cartAmount);

                if (results == 0)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.RequestEntityTooLarge, "Not Enough Stock to Complete Order!");

                }

                else
                {

                    return Request.CreateResponse(HttpStatusCode.OK, results);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query blew up");
            }
        }
    }
}
