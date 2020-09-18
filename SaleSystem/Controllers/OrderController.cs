using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Entities.Order;
using SaleSystem.Entities.Product;
using SaleSystem.Entities.User;
using SaleSystem.Models;
using SaleSystem.Repository;

namespace SaleSystem.Controllers
{
    public class OrderController : Controller
    {

        private IOrderRepository repository;
        private IProductRepository productRepository;
        private IUserRepository userRepository;

        public OrderController(IOrderRepository repository, IProductRepository productRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            var list = new List<IndexOrderViewModel>();
            var orders =  repository.GetAll();
            orders.ToList().ForEach(o => {
                var vm = new IndexOrderViewModel();
                vm.Id = o.OrderId;
                vm.Description = o.Description;
                vm.Status = o.Status.ToString();
                list.Add(vm);
            });


            return View(list);
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
            var entity = ConvertVmToEntity(createOrderViewModel);
            this.repository.Insert(entity);

            return Json("OK");
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


        private Order ConvertVmToEntity(CreateOrderViewModel vm)
        {

            var itens = new List<Item>();
            vm.Itens.ForEach(v => {
                var idProduct = Convert.ToInt32(v.Id);
                var product = this.productRepository.Get(idProduct);
                var item = new Item
                {
                    Amount = Convert.ToInt32(v.Amount),
                    Description = product.Description,
                    Product = product,
                    Price = product.Price
                };
                itens.Add(item);
            });
            var user = this.userRepository.GetAll().FirstOrDefault();
            var order = new Order
            {
                Description = vm.Description,
                CreateDate = DateTime.Now,
                User = user,
                Itens = itens
            };

            if (vm.Status == "Open")
                order.Status = OrderStatus.Open;

            if (vm.Status == "Finish")
                order.Status = OrderStatus.Finish;

            if (vm.Status == "Cancel")
                order.Status = OrderStatus.Cancel;

            return order;
        }
    }
}
