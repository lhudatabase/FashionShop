using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}