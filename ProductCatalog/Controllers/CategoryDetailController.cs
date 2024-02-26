using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Dal.Repository;
using ProductCatalog.Domain.Entity;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    [Authorize]
    public class CategoryDetailController : Controller
    {
        private readonly ProductPageRepository _repository;

        public CategoryDetailController(ProductPageRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(ProductCategory category)
        {
            _repository.CreateProductCategory(category);
            try
            {
                return Redirect(Request?.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(ProductGroup group)
        {
            _repository.CreateProductGroup(group);
            try
            {
                return Redirect(Request?.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryDetail/Details/5
        public ActionResult Details(int id)
        {
            ProductCategory? category = _repository
                .GetCategoryById(id);
            return View(category);
        }

        // POST: CategoryDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductPage collection)
        {
            _repository.CreateProductPage(collection);
            try
            {
                return Redirect(Request?.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // POST: CategoryDetail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProductPage(ProductPage page)
        {
            _repository.EditProductPage(page);
            
            try
            {

                return Redirect(Request?.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // POST: CategoryDetail/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PageDeleteRequestModel deleteRequest)
        {
            var item = _repository.GetPageById(deleteRequest.PageId);

            if (item == null)
            {
                return Redirect(Request?.Headers["Referer"]);
            }
            _repository.DeletePage(item);
            return Redirect(Request?.Headers["Referer"]);


        }
    }
}
