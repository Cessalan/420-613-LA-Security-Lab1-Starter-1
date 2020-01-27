using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [Authorize(Users = "testuser1, testuser2 ,testuser3")]
        public ActionResult Index()
        {
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {


            filterContext.ExceptionHandled = true;
            LogUtil log = new LogUtil();
            string filepath = @"C:\Users\Fatsy\source\repos\420-613-LA-Security-Lab1-Starter\SecurityLab1_Starter\logFile.txt";
            using (StreamWriter w = System.IO.File.AppendText(filepath))
            {

                log.Log(filterContext.Exception.Message, w);
            }
            filterContext.Result = RedirectToAction("Index", "Error");

        }

    }
}