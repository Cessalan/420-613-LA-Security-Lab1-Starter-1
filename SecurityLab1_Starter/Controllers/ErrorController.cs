using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ServerError()
        {
            ViewBag.CurrentURL = Request.QueryString["aspxerrorpath"];
            return View();
        }

        public ActionResult NotFound()
        {
            
            return View();  
        }
    }
}