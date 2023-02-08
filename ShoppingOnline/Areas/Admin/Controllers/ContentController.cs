using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        ShoppingOnlineDBContext db = new ShoppingOnlineDBContext();
        // GET: Admin/Content
        public ActionResult Index()
        {
            var lstContent = db.Contents.ToList();
            return View(lstContent);
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Content content)
        {
            content.CreatedDate = DateTime.Now;
            db.Contents.Add(content);
            db.SaveChanges();
            return RedirectToAction("Index", "Content");
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CateDAO();
            ViewBag.CategoryID = new SelectList(dao.selectAllCate(), "ID", "Name", selectedID);
        }
    }
}