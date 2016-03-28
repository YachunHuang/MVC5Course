using MVC5Course.Models;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    //TODO:公用方法
    public abstract class BaseController : Controller
    {
        protected ProductRepository reportProduct = RepositoryHelper.GetProductRepository();
        protected FabricsEntities db = new FabricsEntities();
        protected override void HandleUnknownAction(string actionName)
        {
            //TODO:Controller認不得的Action都會導到Index
            this.RedirectToAction("Index", "Home").ExecuteResult(this.ControllerContext);
        }
    }
}