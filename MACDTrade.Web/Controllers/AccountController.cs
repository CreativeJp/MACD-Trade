using MACDTrade.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MACDTrade.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository _userReposritoy;

        public AccountController()
        {
            _userReposritoy = new UserRepository();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var objUser = _userReposritoy.GetUserByUserName(username);
            if (objUser != null)
            {
                var hash = Helper.CreatePasswordHash(string.Concat(password, objUser.Salt), objUser.Salt);
                if (objUser.PasswordHash == hash)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["ErrMsg"] = "username or password incorrect.";
            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }
    }
}