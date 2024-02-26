using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Dal.Repository;
using ProductCatalog.Models;
using System.Diagnostics;

namespace ProductCatalog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ProductPageRepository _repository;

        public HomeController(ILogger<HomeController> logger,
            ProductPageRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var category = _repository
               .GetAllCategory();
            return View(category);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
