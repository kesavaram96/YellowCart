using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;
using YellowCart.Data;
using YellowCart.Models;
using YellowCart.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YellowCart.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        

        public IActionResult Index()
        {
            var ProductCat = new ProductCat();
            ProductCat.Products=_context.Products.ToList();
            ProductCat.Categories=_context.Category.ToList();
            var cartCount = _context.Cart.Count();
            
            return View(ProductCat);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Shop(string? query)
        {

            if (query != null)
            {
                IEnumerable<Product> searchedProductList = _context.Products.Where(p => p.Category.SubCategoryName == query).ToList();
                if (searchedProductList.Count() == 0)
                {
                    searchedProductList = _context.Products.Where(p => p.ProductName.Contains(query) || p.Category.SubCategoryName.Contains(query)).ToList();
                    if (searchedProductList.Count() == 0)
                    {
                        TempData["error"] = "No Items found in the database.";
                        return View(searchedProductList);
                    }
                    else
                    {
                        ViewBag.Msg = String.Format("Searched by Product Name. {0} item(s) found.", searchedProductList.Count());



                        return View(searchedProductList);
                    }

                }
                else
                {
                    TempData["error"] = String.Format("Searched by Product Brand. {0} item(s) found.", searchedProductList.Count());

                    return View(searchedProductList);
                }
            }

            IEnumerable<Product> objProductList = _context.Products.ToList();
            return View(objProductList);


           
        }
   
        public IActionResult Admin()
        {
            var UID = HttpContext.Session.GetInt32("Id");
            Users user = _context.Users.Find(UID);
            //request user

            if (!UID.HasValue)
            {
                TempData["error"] = "Please Login to See this Page";
                return RedirectToAction("Login", "Users");
            }
            if (UID.HasValue && user.UserType != "admin")
            {
                TempData["error"] = "Only Admin can see this page";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Pagenotfound()
        {
            return View();
        }


    }
    
}