using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Watch> watchContext;
        IRepository<Brand> brandContext;

        public HomeController(IRepository<Watch> watchContext, IRepository<Brand> brandContext)
        {
            this.watchContext = watchContext;
            this.brandContext = brandContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Watches(string Brand = null)
        {
            List<Watch> watches;
            List<Brand> brands = brandContext.Collection().ToList();

            if (Brand == null)
            {
                watches = watchContext.Collection().ToList();
            }
            else
            {
                watches = watchContext.Collection().Where(p => p.Brand == Brand).ToList();
            }

            WatchListViewModel viewModel = new WatchListViewModel();
            viewModel.Watches = watches;
            viewModel.Brands = brands;
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(string Id)
        {
            Watch watch = this.watchContext.Find(Id);

            if (watch == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View(watch);

            }
        }
    }
}