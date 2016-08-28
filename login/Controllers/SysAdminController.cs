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
            return View("Register");
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
        public ActionResult Register()
        {
            int loginId = Convert.ToInt32(Request.Params["userName"]);
            string loginPwd = Request.Params["userPwd"].ToString();
            string adminName = "mawenjie";
            SysAdmin registUser=new SysAdmin(){
                LoginId=loginId,
                LoginPwd=loginPwd,
                AdminName=adminName
            };
            SysAdmin user = new SysAdminService().AdminRegister(registUser);
            if (user != null)
            {
                ViewBag.userName = user.AdminName;
            }
            else
            {
                ViewBag.userName = "注册失败";
            }
            return View("Register");
        }
    }
}
