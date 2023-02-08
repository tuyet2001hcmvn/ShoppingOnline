using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Controllers
{
    public class ProductController : Controller
    {
        ShoppingOnlineDBContext context = new ShoppingOnlineDBContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            var dao = new ProductDAO().ItemDetail(id);
            ViewBag.Category = context.ProductCategories.Find(dao.CategoryID);
            ViewBag.RelatedProduct = new ProductDAO().lstRelatedProduct(id);
            return View(dao);
        }

        public ActionResult CategoryDetail(int ID)
        {
            var item = (from p in context.Products
                        join cp in context.ProductCategories on ID equals cp.ID
                        select new
                        {
                            cp.Name,
                            p.CategoryID,
                            cp.ID
                        }).FirstOrDefault();
            ViewBag.CateName = item.Name;

            var model = context.Products.Where(c => c.CategoryID == ID).ToList();

            return View(model);
        }
    }
}