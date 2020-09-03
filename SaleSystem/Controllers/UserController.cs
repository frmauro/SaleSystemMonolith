using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Entities.User;
using SaleSystem.Models;
using SaleSystem.Repository;

namespace SaleSystem.Controllers
{
    public class UserController : Controller
    {

        private IRepository<User> repository;

        public UserController(IRepository<User> repository)
        {
            this.repository = repository;
        }

        // GET: UserController
        public ActionResult Index()
        {
            IndexUserViewModel vm = null;
            var uersVM = new List<IndexUserViewModel>();
            var users = repository.GetAll();

            users.ToList().ForEach(u =>
            {
                vm = new IndexUserViewModel();
                vm.Email = u.Name;
                vm.Name = u.Name;
                vm.Id = u.Id;
                vm.Password = u.Password;
                vm.Status = u.Status.ToString();
                vm.Type = u.Type.ToString();
                uersVM.Add(vm);
            });

            return View(uersVM);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var model = new CreateUserViewModel();
            return View(model);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel model)
        {
            try
            {
                var user = new User { Name = model.Name, Email = model.Email, Password = model.Password };

                if (model.Type == "Administrator")
                    user.Type = TypeUser.Administrator;
                else
                    user.Type = TypeUser.Client;

                if (model.Status == "Active")
                    user.Status = UserStatus.Active;
                else
                    user.Status = UserStatus.Inactive;

                this.repository.Insert(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
