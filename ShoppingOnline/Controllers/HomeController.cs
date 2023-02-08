using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Controllers
{
    public class HomeController : Controller
    {
        private ShoppingOnlineDBContext context;
        public HomeController()
        {
            context = new ShoppingOnlineDBContext();
        }
        public ActionResult Index()
        {
            var dao = new ProductDAO();
            ViewBag.NewProduct = dao.lstNewProduct();
            ViewBag.FeaturedProduct = dao.lstFeaturedProduct();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var dao = new MenuAndFooterDAO().listByGroupID(1);
            return PartialView(dao);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var dao = new MenuAndFooterDAO().listByGroupID(2);
            return PartialView(dao);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var dao = new MenuAndFooterDAO().GetFooter();
            return PartialView(dao);
        }

        [ChildActionOnly]
        public ActionResult Slide()
        {
            var dao = new MenuAndFooterDAO().GetSlide();
            return PartialView(dao);
        }

        [ChildActionOnly]
        public ActionResult ProductCategory()
        {
            ViewBag.ProCate = new MenuAndFooterDAO().GetProductCategories();
            return PartialView();
        }
    }
}