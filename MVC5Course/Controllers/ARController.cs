using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult PartialViewTest()
        {
            //TODO:return View() 會載入Layout。return PartialView，不同的是不載入Layout，直接載入View。
            return PartialView("Index");
        }

        public ActionResult FileTest(int? dl)
        {
            //return File(Server.MapPath("~/Content/Site.css"), "text/css","myCss.css");
            if (dl.HasValue)
                return File(Server.MapPath("~/App_Data/Kiwi.png"), "image/png", "download_kiwi.png");
            else
                return File(Server.MapPath("~/App_Data/Kiwi.png"), "image/png");
        }

        public ActionResult JsonTest(int id)
        {
            //TODO:return Json時需要加上此參數JsonRequestBehavior，則在呼叫時(Get)才不會發生錯誤。

            //序列化:把一個.net的物件(記憶體物件)，轉成另一種格式存起來下次再放回記憶體。
            //例如:轉成xml, json就是做序列化的動作，它是一種格式。
            //在序列化的過程中會讀到導覽屬性，會造成循環參考。
            //(在延遲載入時就容易造成這個問題，所以可以使用LazyLoadingEnabled=false即可排除。)
            var db = reportProduct.UnitOfWork.Context;
            db.Configuration.LazyLoadingEnabled = false;

            var product = reportProduct.Find(id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}