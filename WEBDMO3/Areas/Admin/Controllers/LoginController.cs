using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBDMO3.Areas.Admin.Models;
using WEBDMO3.Common;

namespace WEBDMO3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        // Login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.CheckLogin(model.Username, model.Password);
                if (res)
                {
                    // add user session
                    var user = dao.GetIdByUsername(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserID = user.id;
                    userSession.Username = user.username;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login false");
                }
            }
            return View("index");
        }
    }
}