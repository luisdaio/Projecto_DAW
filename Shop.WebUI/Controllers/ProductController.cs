using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Create(Product product, HttpPostedFileBase imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                if (imageFile != null)
                {
                    product.Image = product.Id + Path.GetExtension(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/ProductImages/"), product.Image);
                    imageFile.SaveAs(path);
                }
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
        public ActionResult Edit(Product product, string Id, HttpPostedFileBase imageFile)
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
                    if (imageFile != null)
                    {
                        productToEdit.Image = product.Id + Path.GetExtension(imageFile.FileName);
                        var path = Path.Combine(Server.MapPath("/Content/ProductImages/"), productToEdit.Image);
                        imageFile.SaveAs(path);
                    }

                    productToEdit.Name = product.Name;
                    productToEdit.Description = product.Description;
                    productToEdit.Category = product.Category;
                    productToEdit.Price = product.Price;
                    
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
