using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.DAO;
using Model.EntityFramework;
using ShoppingOnline.Areas.Admin.Models;
using ShoppingOnline.Common;
using ShoppingOnline.Controllers;

namespace ShoppingOnline.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        private ShoppingOnlineDBContext context;
        public UserController()
        {
            context = new ShoppingOnlineDBContext();
        }

        // GET: Admin/User
        public ActionResult Index(string strSearch, int page = 1, int pagesize = 10)
        {
            var dao = new UserDAO();
            var model = dao.Paging(strSearch, page, pagesize);
            ViewBag.strSearch = strSearch;
            ViewBag.ListUsers = new UserDAO().lstAllUser();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.CreatedDate = DateTime.Now;
            user.Password = Encryptor.MD5Hash(user.Password);
            if (user.ID == 0)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            var dao = new UserDAO();
            dao.Delete(user.ID);
            return RedirectToAction("Index", "User");
        }

        public ActionResult Edit(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dao = new UserDAO();
            user.Password = Encryptor.MD5Hash(user.Password);
            dao.Update(user);
            return View(user);
        }

        [HttpPost]
        public JsonResult Changestatus(int id)
        {
            var dao = new UserDAO().Changestatus(id);
            return Json(new
            {
                status = dao
            }); 
        }
    }
}