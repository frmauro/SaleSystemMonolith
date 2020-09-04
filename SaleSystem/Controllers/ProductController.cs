using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.Entities.Product;
using SaleSystem.Models;
using SaleSystem.Repository;

namespace SaleSystem.Controllers
{
    public class ProductController : Controller
    {

        private IRepository<Product> repository;

        public ProductController(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IndexProductViewModel vm = null;
            var productsVM = new List<IndexProductViewModel>();
            var products = repository.GetAll();

            products.ToList().ForEach(p =>
            {
                vm = new IndexProductViewModel();
                vm.Description = p.Description;
                vm.Amount = p.Amount;
                vm.Id = p.Id;
                vm.Status = p.Status.ToString();
                productsVM.Add(vm);
            });

            return View(productsVM);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var model = new CreateProductViewModel();
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductViewModel model)
        {
            try
            {
                var product = new Product { Description = model.Description, Amount = model.Amount };

                if (model.Status == "Active")
                    product.Status = ProductStatus.Active;
                else
                    product.Status = ProductStatus.Inactive;

                this.repository.Insert(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var vm = new EditProductViewModel();
            var product = repository.Get(id);
            vm.Id = product.Id;
            vm.Description = product.Description;
            vm.Amount = product.Amount;
            vm.Status = product.Status.ToString();
            return View(vm);

        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditProductViewModel model)
        {
            try
            {
                var product = repository.Get(id);
                product.Description = model.Description;
                product.Amount = model.Amount;

                if (model.Status == "Active")
                    product.Status = ProductStatus.Active;
                else
                    product.Status = ProductStatus.Inactive;

                repository.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
