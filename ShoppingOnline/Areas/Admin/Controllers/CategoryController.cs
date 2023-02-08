using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ShoppingOnlineDBContext db = new ShoppingOnlineDBContext();
        // GET: Admin/Category
        public ActionResult Index(string strSearch, int page = 1, int pagesize = 1)
        {
            var dao = new CateDAO();
            var model = dao.Paging(strSearch, page, pagesize);
            ViewBag.strSearch = strSearch;
            return View(model);
        }
    }
}