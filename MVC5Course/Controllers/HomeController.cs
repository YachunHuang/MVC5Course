using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        //TODO:輸入propfull按下tab
        //private int myprop;

        //public int MyProperty
        //{
        //    get { return myprop; }
        //    set { myprop = value; }
        //}

        public ActionResult Index()
        {
            //TODO: 工作清單demo

            //TODO: enum and switch demo
            //ConsoleColor mycolor = ConsoleColor.Blue;
            //switch (mycolor)
            //{
            //    case ConsoleColor.Black:
            //        break;
            //    case ConsoleColor.DarkBlue:
            //        break;
            //    case ConsoleColor.DarkGreen:
            //        break;
            //    case ConsoleColor.DarkCyan:
            //        break;
            //    case ConsoleColor.DarkRed:
            //        break;
            //    case ConsoleColor.DarkMagenta:
            //        break;
            //    case ConsoleColor.DarkYellow:
            //        break;
            //    case ConsoleColor.Gray:
            //        break;
            //    case ConsoleColor.DarkGray:
            //        break;
            //    case ConsoleColor.Blue:
            //        break;
            //    case ConsoleColor.Green:
            //        break;
            //    case ConsoleColor.Cyan:
            //        break;
            //    case ConsoleColor.Red:
            //        break;
            //    case ConsoleColor.Magenta:
            //        break;
            //    case ConsoleColor.Yellow:
            //        break;
            //    case ConsoleColor.White:
            //        break;
            //    default:
            //        break;
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //TODO:自訂錯誤畫面與自訂訊息內容HandleError
        //加上ExceptionType可以決定什麼錯誤要跑什麼錯誤頁面，除了指定的錯誤要跑Error這個頁面以外其餘都會在Error2作顯示
        [HandleError(ExceptionType = typeof(InvalidOperationException), View = "Error2")]
        public ActionResult Test(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("kiwi拋出自訂錯誤ArgumentException");
            }
            throw new InvalidOperationException("kiwi操作錯誤InvalidOperationException");

            return View();
        }
    }
}