using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    /// <summary>
    /// Product資料的API
    /// </summary>
    public class ProductsApiController : ApiController
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: api/ProductsApi
        /// <summary>
        /// 取得所有商品
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetProduct()
        {
            return db.Product;
        }

        // GET: api/ProductsApi/5
        /// <summary>
        /// 取得單一商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/ProductsApi/5
        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <param name="product">商品</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductsApi
        /// <summary>
        /// 新增一筆商品
        /// </summary>
        /// <param name="product">商品</param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // DELETE: api/ProductsApi/5
        /// <summary>
        /// 刪除一筆商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 判斷商品是否存在
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.ProductId == id) > 0;
        }
    }
}