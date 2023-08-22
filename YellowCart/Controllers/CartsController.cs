using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YellowCart.Data;
using YellowCart.Models;


namespace YellowCart.Controllers
{
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {

            var UID = HttpContext.Session.GetInt32("Id");
            Users user = _context.Users.Find(UID);
            //request user

            if (!UID.HasValue)
            {
                TempData["error"] = "Please Login to See Cart";
                return RedirectToAction("Login", "Users");
            }
            var applicationDbContext = _context.Cart.Include(c => c.Product).Include(c => c.User).Where(u=>u.User==user);
            return View(await applicationDbContext.ToListAsync());
        }

       

        //// GET: Carts/Create
        //public IActionResult Create()
        //{
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmPassword");
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Id,int qty)
        {
            var UID = HttpContext.Session.GetInt32("Id");
            Users user = _context.Users.Find(UID);
         
            if(!UID.HasValue)
            {
                TempData["error"] = "Please Login to Add Cart";
                return RedirectToAction("Login", "Users");
            }
               
            //int user = _context.Users.Find();
            Product product = _context.Products.Find(Id);

            if (product == null || user == null)
            {
                return NotFound();
            }
            
            var cartProduct = _context.Cart.FirstOrDefault(p => p.Product == product);
            if (cartProduct== null)
            {

                Cart cart = new Cart
                {
                    Quantitive = qty,
                    Product = product,
                    User = user,
                    Total = qty * product.Price

                };
                _context.Cart.Add(cart);
                _context.SaveChanges();
                TempData["sucess"] = "Added to Cart";

                return RedirectToAction("Index", "Carts");
            }
            
                TempData["error"] = "Item already in Cart";
                return RedirectToAction("Index", "Carts");
            
        }
     
        [HttpPost]
        public async Task<IActionResult> Edit(int id, int qty)
        {
            var cart = _context.Cart.Find(id);
            var product=_context.Products.FirstOrDefault(m=>m.Id.Equals(cart.ProductId)); 
            
            if (cart==null)
            {
                return NotFound();
            }
            if(qty == 0) 
            {
                _context.Cart.Remove(cart);
                _context.SaveChanges();
                TempData["sucess"] = "Cart Updated";
                return RedirectToAction("Index");
            }
            cart.Quantitive = qty;
            cart.Total = qty* product.Price;
            _context.Update(cart);
            await _context.SaveChangesAsync();
            TempData["sucess"] = "Cart Updated";

            return RedirectToAction("Index");
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Cart == null)
            //{
            //    return NotFound();
            //}

            //var cart = await _context.Cart
            //    .Include(c => c.Product)
            //    .Include(c => c.User)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (cart == null)
            //{
            //    return NotFound();
            //}

            //return View(cart);
            if (_context.Cart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cart'  is null.");
            }
            var cart = await _context.Cart.FindAsync(id);
            if (cart != null)
            {
                _context.Cart.Remove(cart);
            }

            await _context.SaveChangesAsync();
            TempData["sucess"] = "Item Removed";
            return RedirectToAction(nameof(Index));
        }

        // POST: Carts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Cart == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Cart'  is null.");
        //    }
        //    var cart = await _context.Cart.FindAsync(id);
        //    if (cart != null)
        //    {
        //        _context.Cart.Remove(cart);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CartExists(int id)
        {
          return _context.Cart.Any(e => e.Id == id);
        }
    }
}
