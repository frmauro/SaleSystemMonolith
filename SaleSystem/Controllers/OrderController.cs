using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Entities.Order;
using SaleSystem.Entities.Product;
using SaleSystem.Models;
using SaleSystem.Repository;

namespace SaleSystem.Controllers
{
    public class OrderController : Controller
    {

        private IRepository<Order> repository;
        private IProductRepository productRepository;

        public OrderController(IRepository<Order> repository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var vm = new CreateOrderViewModel();
            return View(vm);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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


        [HttpPost]
        public JsonResult ListByDescription([FromBody]string description)
        {
            var products = this.productRepository.ListByDescription(description);
            return Json(products);
        }


        [HttpPost]
        public JsonResult Save([FromBody]object vm)
        {
            var createOrderViewModel = JsonSerializer.Deserialize<CreateOrderViewModel>(vm.ToString());
            return Json(createOrderViewModel);
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
