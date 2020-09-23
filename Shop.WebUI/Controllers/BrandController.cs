using Shop.Core.Contracts;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class BrandController : Controller
    {
        IRepository<Brand> brandContext;
        public BrandController(IRepository<Brand> brandContext)
        {
            this.brandContext = brandContext;
        }

        // GET: Brand
        public ActionResult Index()
        {
            List<Brand> brands = brandContext.Collection().ToList();
            return View(brands);
        }
           
        // GET: Brand/Create
        public ActionResult Create()
        {
            Brand brand = new Brand();
            return View(brand);
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            else
            {
                this.brandContext.Insert(brand);
                this.brandContext.Commit();
                return RedirectToAction("Index");
            }
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(string Id)
        {
            Brand brand = this.brandContext.Find(Id);

            if (brand == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(brand);
            }
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(Brand brand, string Id)
        {
            Brand brandToEdit = this.brandContext.Find(Id);

            if (brandToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(brandToEdit);

                }
                else
                {
                    brandToEdit.Name = brand.Name;
                    this.brandContext.Update(brandToEdit);
                    this.brandContext.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(string Id)
        {
            Brand brandToDelete = this.brandContext.Find(Id);

            if (brandToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(brandToDelete);
            }
        }

        // POST: Brand/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Brand brand, string Id)
        {
            Brand brandToDelete = this.brandContext.Find(Id);

            if (brandToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.brandContext.Delete(Id);
                this.brandContext.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}