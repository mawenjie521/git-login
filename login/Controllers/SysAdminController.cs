using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using login.Models;

namespace login.Controllers
{
    public class SysAdminController : Controller
    {
        //
        // GET: /SysAdmin/

        public ActionResult Index()
        {
            return View("AdminLogin");
        }
        public ActionResult AdminLogin()
        {
            int loginId = Convert.ToInt32(Request.Params["loginId"]);
            string loginPwd = Request.Params["loginPwd"].ToString();
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = loginId,
                LoginPwd = loginPwd
            };
            objAdmin = new SysAdminService().AdminLogin(objAdmin);
            if (objAdmin != null)
            {
                ViewBag.userName = objAdmin.AdminName;
            }
            else
            {
                ViewBag.userName = "用户名或密码错误";
            }
            return View("first");
        }
    }
}
