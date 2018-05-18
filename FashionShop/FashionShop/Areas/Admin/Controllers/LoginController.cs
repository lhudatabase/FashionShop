using FashionShop.Areas.Admin.Code;
using FashionShop.Areas.Admin.Models;
using FashionShop.Common;
using Model.Dao;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FashionShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, MaHoaMD5.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "User");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Wrong User.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "User Is Blocked.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Wrong PassWord.");
                }
                else
                {
                    ModelState.AddModelError("", "Can't Understand...");
                }
            }
            return View("Index");
        }
    }
}