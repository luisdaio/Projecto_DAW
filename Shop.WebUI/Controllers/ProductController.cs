using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Core.Models;
using Shop.Core.ViewModels;

namespace Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
            // TODO: Inicializar Objecto que interage com a base de dados.
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>(); // TODO: obter a lista de contactos da base de dados.
            products.Add(new Product("Iphone 10", "Telemóvel da marca Apple", 1000, "Smartphone", ""));
            return View(products);
        }

        
        public ActionResult Create()
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.product = new Product();
            // viewModel.categories = productCategories.Collection();
            return View(viewModel);
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
                // TODO: Inserir o producto na base de dados.
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = new Product();  // TODO: Consultar a base de dados e obter o produto consoante o Id.

            if (product  == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductViewModel viewModel = new ProductViewModel();
                viewModel.product = product;
                // viewModel.categories = productCategories.Collection(); TODO: Consultar a base de dados e ir buscar
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = new Product();  // TODO: Consultar a base de dados e obter o produto consoante o Id.

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
                    //TODO: Guardar as alterações na base de dados.
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = new Product();  // TODO: Consultar a base de dados e obter o produto consoante o Id.

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
            Product productToDelete = new Product();  // TODO: Consultar a base de dados e obter o produto consoante o Id.

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                // TODO: Apagar o produto da base de dados.
                return View(productToDelete);
            }
        }
    }
}
