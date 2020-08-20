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
        IRepository<Product> productContext;
        IRepository<ProductCategory> productCategoryContext;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            this.productContext = productContext;
            this.productCategoryContext = productCategoryContext;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategoryContext.Collection().ToList();
            
            if(Category == null)
            {
                products = productContext.Collection().ToList();
            }
            else
            {
                products = productContext.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel viewModel = new ProductListViewModel();
            viewModel.Products = products;
            viewModel.ProductCategories = categories;
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
            Product product = this.productContext.Find(Id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View(product);

            }
        }
    }
}