using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Entities.Product;
using SaleSystem.Entities.User;
using SaleSystem.Models;
using SaleSystem.Repository;

namespace SaleSystem.Controllers
{
    public class LoginController : Controller
    {

        private IUserRepository repository;

        public LoginController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // GET: LoginController/Create
        public ActionResult Logon()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logon(IFormCollection collection)
        {
            try
            {
                var email = collection["txtEmail"];
                var password = collection["txtPassword"];

                var user = this.repository.GetByEmailAndByPassword(email, password);

                HttpContext.Session.SetString("user", user.Email);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public  IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Logon", "Login");
        }

    }
}
