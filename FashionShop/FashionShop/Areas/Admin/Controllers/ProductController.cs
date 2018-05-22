using Model.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 99999999)
        {
            var dao = new ProductDao();
            var model = dao.ListALLPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var proDuct = new Product();
                proDuct.Name = product.Name;
                proDuct.Code = product.Code;
                proDuct.MetaTitle = product.MetaTitle;
                proDuct.Description = product.Description;
                proDuct.Image = product.Image;
                proDuct.Price = product.Price;
                proDuct.IncludedVAT = product.IncludedVAT;
                proDuct.Quantity = product.Quantity;
                proDuct.CategoryID = product.CategoryID;
                proDuct.Detail = product.Detail;
                proDuct.Warranty = product.Warranty;
                proDuct.CreatedDate = DateTime.Now;
                proDuct.CreatedBy = product.CreatedBy;
                proDuct.TopHot = product.TopHot;
                proDuct.Status = product.Status;
                long id = dao.Insert(proDuct);
                if (id > 0)
                {
                    SetAlert("Created Product Compeled", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "ERROR");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
               
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("Edited Product Compeled.", "success");
                    return RedirectToAction("Index", "Product");
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
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}