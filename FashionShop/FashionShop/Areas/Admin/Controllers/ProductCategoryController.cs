using Model.Dao;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;

namespace FashionShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchString, int page = 1, int pageSize = 999999)
        {
            var dao = new ProductCategoryDao();
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
        public ActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                var proDuctcategory = new ProductCategory();
                proDuctcategory.Name = productCategory.Name;
                proDuctcategory.MetaTitle = productCategory.MetaTitle;
                proDuctcategory.ParentID = productCategory.ParentID;
                proDuctcategory.DisplayOrder = productCategory.DisplayOrder;
                proDuctcategory.CreatedDate = DateTime.Now;
                proDuctcategory.CreatedBy = productCategory.CreatedBy;
                proDuctcategory.Status = productCategory.Status;
                long id = dao.Insert(proDuctcategory);
                if (id > 0)
                {
                    SetAlert("Created ProductCategory Completed", "success");
                    return RedirectToAction("Index", "ProductCategory");
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
            var productCategory = new ProductCategoryDao().ViewDetail(id);
            return View(productCategory);
        }


        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();

                var result = dao.Update(productCategory);
                if (result)
                {
                    SetAlert("Edited ProductCategory Completed.", "success");
                    return RedirectToAction("Index", "ProductCategory");
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
            new ProductCategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}