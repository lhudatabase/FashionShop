using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Common;
using FashionShop.Models;
using Models.Dao;

namespace FashionShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Danh sách các sản phẩm
            var productDao = new ProductsDao();       
            // có 9 sản phẩm được hiển thị trong sản phẩm
            ViewBag.NewProducts = productDao.ListNewProduct(8);
            // có 3 sản phẩm được yêu thích nhất
            ViewBag.ListFeatureProducts = productDao.ListFeatureProducts(3);
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }


    }
}