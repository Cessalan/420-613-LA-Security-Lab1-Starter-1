
using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthDemo.Controllers
{
    public class AccountController : Controller
    {
        SecurityLab1_Starter.Infrastructure.Abstract.IAuthProvider authProvider;

        public AccountController(SecurityLab1_Starter.Infrastructure.Abstract.IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    LogUtil LogUtil = new LogUtil();
                    using (StreamWriter w = System.IO.File.AppendText("C:\\Users\\Fatsy\\source\\repos\\420-613-LA-Security-Lab1-Starter\\SecurityLab1_Starter\\useraccess.log"))
                    {
                        LogUtil.Log(model.UserName + " logged in.", w);
                    }

                    return Redirect(Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            LogUtil LogUtil = new LogUtil();
            using (StreamWriter w = System.IO.File.AppendText("C:\\Users\\Fatsy\\source\\repos\\420-613-LA-Security-Lab1-Starter\\SecurityLab1_Starter\\useraccess.log"))
            {
                LogUtil.Log(User.Identity.Name + " logged out.", w);
            }
            FormsAuthentication.SignOut();
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}