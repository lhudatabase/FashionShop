using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Areas.Admin.Controllers
{
    public class FeedBackController : BaseController
    {
        // GET: Admin/FeedBack
     
            public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
            {
                var dao = new FeedBackDao();
                var model = dao.ListALLPaging(searchString, page, pageSize);
                ViewBag.SearchString = searchString;
                return View(model);
            }

            [HttpDelete]
            public ActionResult Delete(int id)
            {
                new OrderDao().Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
