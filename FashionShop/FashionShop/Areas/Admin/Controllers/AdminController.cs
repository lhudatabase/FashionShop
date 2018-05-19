using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        [Authorize]
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult UsersAccount()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult FileManager()
        {
            return View();
        }

        public ActionResult Icon()
        {
            return View();
        }
    }
}