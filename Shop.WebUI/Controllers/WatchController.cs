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
    public class WatchController : Controller
    {
        IRepository<Watch> watchContext;
        IRepository<Brand> brandContext;

        public WatchController(IRepository<Watch> watchContext, IRepository<Brand> brandContext)
        {
            this.watchContext = watchContext;
            this.brandContext = brandContext;
        }

        // GET: Watch
        public ActionResult Index()
        {
            List<Watch> watches = this.watchContext.Collection().ToList();
            return View(watches);
        }

        
        public ActionResult Create()
        {
            WatchViewModel watchView = new WatchViewModel();
            watchView.Watch = new Watch();
            watchView.Brands = this.brandContext.Collection().ToList();
            return View(watchView);
        }

        [HttpPost]
        public ActionResult Create(Watch watch, HttpPostedFileBase imageFile)
        {
            if (!ModelState.IsValid)
            {
                WatchViewModel viewModel = new WatchViewModel();
                viewModel.Watch = watch;
                viewModel.Brands = this.brandContext.Collection();
                return View(viewModel); 
            }
            else
            {
                if (imageFile != null)
                {
                    watch.Image = watch.Id + Path.GetExtension(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/ProductImages/"), watch.Image);
                    imageFile.SaveAs(path);
                }
                this.watchContext.Insert(watch);
                this.watchContext.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Watch product = this.watchContext.Find(Id);

            if (product  == null)
            {
                return HttpNotFound();
            }
            else
            {
                WatchViewModel viewModel = new WatchViewModel();
                viewModel.Watch = product;
                viewModel.Brands = this.brandContext.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Watch watch, string Id, HttpPostedFileBase imageFile)
        {
            Watch watchToEdit = this.watchContext.Find(Id);
            
            if (watchToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    throw new Exception();
                    WatchViewModel viewModel = new WatchViewModel();
                    viewModel.Watch = watch;
                    viewModel.Brands = this.brandContext.Collection();
                    return View(viewModel);
                }
                else
                {
                    if (imageFile != null)
                    {
                        watchToEdit.Image = watch.Id + Path.GetExtension(imageFile.FileName);
                        var path = Path.Combine(Server.MapPath("/Content/ProductImages/"), watchToEdit.Image);
                        imageFile.SaveAs(path);
                    }

                    watchToEdit.Name = watch.Name;
                    watchToEdit.Description = watch.Description;
                    watchToEdit.Brand = watch.Brand;
                    watchToEdit.Price = watch.Price;
                    
                    this.watchContext.Update(watchToEdit);
                    this.watchContext.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Watch watchToDelete = this.watchContext.Find(Id);

            if (watchToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(watchToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Watch watch, string Id)
        {
            Watch productToDelete = this.watchContext.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.watchContext.Delete(Id);
                this.watchContext.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}
