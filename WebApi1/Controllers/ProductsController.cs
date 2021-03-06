﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> products = new List<Product>()
               {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
               };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [ValidModel]
        public IHttpActionResult PostProduct(Product product)
        {
            products.Add(product);
            return Created(this.Url.Route("DefaultApi", new { id = product.Id }), products);
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            var one = products.FirstOrDefault(p => p.Id == id);
            products.Remove(one);
            return Ok(products);
        }
    }
}