using Shop.Core.Contracts;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        IRepository<ProductCategory> productCategoryContext;
        public ProductCategoryController(IRepository<ProductCategory> productCategoryContext)
        {
            this.productCategoryContext = productCategoryContext;
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            List<ProductCategory> categories = productCategoryContext.Collection().ToList();
            return View(categories);
        }
           
        // GET: ProductCategory/Create
        public ActionResult Create()
        {
            ProductCategory category = new ProductCategory();
            return View(category);
        }

        // POST: ProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                this.productCategoryContext.Insert(category);
                this.productCategoryContext.Commit();
                return RedirectToAction("Index");
            }
        }

        // GET: ProductCategory/Edit/5
        public ActionResult Edit(string Id)
        {
            ProductCategory category = this.productCategoryContext.Find(Id);

            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }

        // POST: ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductCategory category, string Id)
        {
            ProductCategory categoryToEdit = this.productCategoryContext.Find(Id);

            if (categoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(categoryToEdit);

                }
                else
                {
                    categoryToEdit.Name = category.Name;
                    this.productCategoryContext.Update(categoryToEdit);
                    this.productCategoryContext.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: ProductCategory/Delete/5
        public ActionResult Delete(string Id)
        {
            ProductCategory categoryToDelete = this.productCategoryContext.Find(Id);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }

        // POST: ProductCategory/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(ProductCategory category, string Id)
        {
            ProductCategory categoryToDelete = this.productCategoryContext.Find(Id);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.productCategoryContext.Delete(Id);
                this.productCategoryContext.Commit();
                return View(categoryToDelete);
            }
        }
    }
}