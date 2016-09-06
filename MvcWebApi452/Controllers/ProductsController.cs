using MvcWebApi452.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebApi452.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] 
        { 
            new Product { id = 1, name = "Tomato Soup", category = "Groceries", price = 1 }, 
            new Product { id = 2, name = "Yo-yo", category = "Toys", price = 3.75M }, 
            new Product { id = 3, name = "Hammer", category = "Hardware", price = 16.99M } 
        };

        /// <summary>
        /// /api/rest/products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        /// <summary>
        /// /api/rest/products/2
        /// /api/rest/products?id=2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
