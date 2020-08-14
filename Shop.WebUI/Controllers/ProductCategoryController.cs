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

        public ProductCategoryController()
        {
            // TODO: Inicializar Objecto que interage com a base de dados.
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            List<ProductCategory> categories = new List<ProductCategory>(); // TODO: obter a lista de contactos da base de dados.
            categories.Add(new ProductCategory("Telemóveis"));
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
                // TODO: Inserir a categoria na base de dados.
                return RedirectToAction("Index");
            }
        }

        // GET: ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            ProductCategory category = new ProductCategory();  // TODO: Consultar a base de dados e obter a categoria consoante o Id.

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
        public ActionResult Edit(Product product, string Id)
        {
            ProductCategory categoryToEdit = new ProductCategory();  // TODO: Consultar a base de dados e obter a categoria consoante o Id.

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
                    //TODO: Guardar as alterações na base de dados.
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            ProductCategory categoryToDelete = new ProductCategory();  // TODO: Consultar a base de dados e obter a categoria consoante o Id.

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
            Product categoryToDelete = new Product();  // TODO: Consultar a base de dados e obter a categoria consoante o Id.

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                // TODO: Apagar a categoria da base de dados.
                return View(categoryToDelete);
            }
        }
    }
}