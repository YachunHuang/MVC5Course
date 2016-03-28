using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        //TODO:透過Repository來存取Entity Framework
        //ProductRepository repo = RepositoryHelper.GetProductRepository();
        //private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index()
        {
            //var data = db.Product.Where(p => p.ProductId > 1550).ToList();
            //只顯示五筆
            var data = reportProduct.All().Take(5).ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(IList<BachUpdateProduct> data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var prod = reportProduct.Find(item.ProductId);
                    prod.Price = item.Price;
                    prod.Stock = item.Stock;
                    prod.Active = item.Active;
                }
                reportProduct.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //TODO:model state會優先顯示，如果沒值的話會再去抓model的值。
            //所以在驗證錯誤後，畫面上留下來的值會是最後打的那個值，而不會是最原始的值。
            ViewData.Model = reportProduct.All().Take(5).ToList();
            return View();

        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = reportProduct.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            //TODO:編輯時判斷模型驗證是否有通過ModelState.IsValid
            if (ModelState.IsValid)
            {
                //db.Product.Add(product);
                //db.SaveChanges();
                reportProduct.Add(product);
                reportProduct.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = reportProduct.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                var dbProduct = (FabricsEntities)reportProduct.UnitOfWork.Context;
                dbProduct.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                reportProduct.UnitOfWork.Commit();

                //TODO:TempData預設存在Session裡面，只要被讀過一次就會不見了。
                TempData["ProductsEditMsg"] = product.ProductName + "更新成功";

                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = reportProduct.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = reportProduct.Find(id);
            reportProduct.Delete(product);
            reportProduct.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                reportProduct.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
