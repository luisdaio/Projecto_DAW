using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.Core.ViewModels;

namespace Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> productContext;
        IRepository<ProductCategory> productCategoryContext;

        public ProductController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            this.productContext = productContext;
            this.productCategoryContext = productCategoryContext;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = this.productContext.Collection().ToList();
            return View(products);
        }

        
        public ActionResult Create()
        {
            ProductViewModel productView = new ProductViewModel();
            productView.product = new Product();
            productView.categories = this.productCategoryContext.Collection().ToList();
            return View(productView);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                this.productContext.Insert(product);
                this.productContext.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = this.productContext.Find(Id);

            if (product  == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductViewModel viewModel = new ProductViewModel();
                viewModel.product = product;
                viewModel.categories = this.productCategoryContext.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = this.productContext.Find(Id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productToEdit);

                }
                else
                {
                    productToEdit.Name = product.Name;
                    productToEdit.Description = product.Description;
                    productToEdit.Category = product.Category;
                    productToEdit.Price = product.Price;
                    productToEdit.Image = product.Image;
                    
                    this.productContext.Update(productToEdit);
                    this.productContext.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = this.productContext.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Product product, string Id)
        {
            Product productToDelete = this.productContext.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.productContext.Delete(Id);
                this.productContext.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}
