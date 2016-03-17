using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
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

        public ActionResult Test()
        {
            return View();
        }
    }
}