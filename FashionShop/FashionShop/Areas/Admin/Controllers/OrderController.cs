﻿using Models.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 999999)
        {
            var dao = new OrderDao();
            var model = dao.ListALLPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

       
        public ActionResult Edit(int id)
        {
            var order = new OrderDao().ViewDetail(id);
            return View(order);
        }


        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
               
                var result = dao.Update(order);
                if (result)
                {
                    SetAlert("Edited Order Completed", "success");
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "ERROR");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new OrderDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}