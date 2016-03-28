using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        //FabricsEntities db = new FabricsEntities();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult EDE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EDE(EDEViewModel data)
        {
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("ReadProduct");
            }

            return View(product);
        }

        public ActionResult CreateProduct()
        {
            var product = new Product() {
                ProductName = "Goods1",
                Active = true,
                Price=1000,
                Stock=10
            };
            db.Product.Add(product);
            db.SaveChanges();
            return View(product);
        }

        public ActionResult ReadProduct(bool? Active)
        {
            //TODO: 取得所有產品資料
            var data = db.Product.AsQueryable();
            //TODO:iQueryable事多筆的型別，Find為單筆，丟給view顯示時需注意。
            data = data
                .Where(p => p.ProductId > 1550)
                .OrderByDescending(p => p.Price);

            //TODO: 動態取得條件值
            if (Active.HasValue)
            {
                data = data.Where(p => p.Active == Active);
            }
            return View(data);
        }

        public ActionResult OneProduct(int id)
        {
            var data = db.Product.Find(id);
            //var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            //var data = db.Product.Where(p => p.ProductId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = db.Product.Find(id);
            if (data == null) { return HttpNotFound(); }
         
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ReadProduct");
            }
            return View(product);
        }

        public ActionResult UpdateProduct(int id)
        {
            var one = db.Product.FirstOrDefault(p => p.ProductId == id);
            if (one == null) { return HttpNotFound(); }
            one.Price = one.Price * 2;
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex) //有錯誤的話可以從頁面擷取這個錯誤名稱
            {
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    foreach (var err in entityError.ValidationErrors)
                    {
                        //這裡只是範例而已直接把錯誤顯示於頁面Content
                        return Content(err.PropertyName + ":" + err.ErrorMessage);
                    }
                }
                throw;
            }
            
            //TODO:update資料後再次回到這個頁面
            return RedirectToAction("ReadProduct");
        }

        public ActionResult DeleteProduct(int id)
        {
            //TODO:直接刪除的話有時會造成錯誤，因為Foreign ken。
            //所以要先把相關資料刪除才可以(可以先透過導覽屬性OrderLine來刪除資料)

            //query case 1
            //依條件查詢，所以會查詢很多次造成效能議題。
            var one = db.Product.Find(id);

            //query case 2
            //一次將資料全部取回再做查詢(Include)
            //var one = db.Product.Include("OrderLine").FirstOrDefault(p => p.ProductId == id);

            //delete case 1
            //foreach (var item in one.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(item);
            //}

            //delete case 2
            db.OrderLine.RemoveRange(one.OrderLine);

            //delete case 3 (ExecuteSqlCommand 無回傳值的)
            //db.Database.ExecuteSqlCommand("DELETE FROM dbo.OrderLine WHERE ProductId=@p0", id);

            db.Product.Remove(one);
            db.SaveChanges();
            return RedirectToAction("ReadProduct");
        }

        public ActionResult ProductView()
        {
            var data = db.Database.SqlQuery<ProductViewModel>
                ("SELECT * FROM dbo.Product WHERE Active=@p0 AND ProductName like @p1", true, "%Lemon%");
            return View(data);
        }

        public ActionResult ProductSP()
        {
            var data = db.GetProduct(true,"%Lemon%");
            return View(data);
        }
    }
}