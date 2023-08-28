using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YellowCart.Data;
using YellowCart.Models;

namespace YellowCart.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
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
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
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
            //ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Category,"Id","SubCategoryName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int cat_id, Product product,IFormFile? file)
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

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    product.Image = @"/images/product/" + fileName;
                }
            
                product.CategoryId = cat_id;
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["sucess"] = "Product Added Sucessfully";
                return RedirectToAction(nameof(Index));

          
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "SubCategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            if (id == null || _context.Products == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "SubCategoryName", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Description,Price,CategoryId,Image,Quantity")] Product product, IFormFile? file)
        {
            var UID = HttpContext.Session.GetInt32("Id");
            Users user = _context.Users.Find(UID);
            //request user

            if (!UID.HasValue)
            {
                TempData["error"] = "Please Login to See this Page";
                return RedirectToAction("Login", "Users");
            }
            if (UID.HasValue && user.UserType == "user")
            {
                TempData["error"] = "Only Admin can see this page";
                return RedirectToAction("Index", "Home");
            }
            if (id != product.Id)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    if (System.IO.File.Exists(product.Image))
                    {
                        System.IO.File.Delete(product.Image);
                    }
                    //string filePath = Path.Combine(wwwRootPath,product.Image);
                    //System.IO.File.Delete(filePath);
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    product.Image = @"/images/product/" + fileName;
                }
              
                try
                {
                    _context.Update(product);
                    TempData["sucess"] = "Product Update sucessfully";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return RedirectToAction("Pagenotfound", "Home");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
            if (id == null || _context.Products == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            TempData["sucess"] = "Product Delete sucessfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
