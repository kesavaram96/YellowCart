using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YellowCart.Data;
using YellowCart.Models;
using YellowCart.ViewModels;

namespace YellowCart.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
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
            if(user.UserType=="admin")
            {
                ViewBag.Title = "Orders";
                var orders = _context.Orders.Include(o => o.Product).Include(o => o.User);
                return View(await orders.ToListAsync());
            }
            ViewBag.Title = "My Orders";
            var applicationDbContext = _context.Orders.Include(o => o.Product).Include(o => o.User).Where(u => u.User == user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            var orders = await _context.Orders
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            
            var UID = HttpContext.Session.GetInt32("Id");
            Users user = _context.Users.Find(UID);

            if (!UID.HasValue)
            {
                TempData["error"] = "Please Login to See Orders";
                return RedirectToAction("Login", "Users");
            }

            //int user = _context.Users.Find();
            Cart cart = _context.Cart.Find(Id);

            if (cart == null || user == null)
            {
                return NotFound();
            }

            //var cartProduct = _context.Products.SingleAsync(m=>m.ProductName==cart.Product.ProductName);
            if (cart != null)
            {

                Orders order = new Orders
                {
                    User = user,
                    ProductId = cart.ProductId,
                    OrderDate = DateTime.Now,
                    Quantitive=cart.Quantitive,
                    TotalAmount=cart.Total
                    

                };
                _context.Orders.Add(order);
                _context.Cart.Remove(cart);
                _context.SaveChanges();
                TempData["sucess"] = "Your order is placed!!! Enjoy your shopping";

                return RedirectToAction("Index", "Orders");
            }

            
           
            return RedirectToAction("Index","Home");
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", orders.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmPassword", orders.UserId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductId,OrderDate,TotalAmount,Quantitive")] Orders orders)
        {
            if (id != orders.Id)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", orders.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmPassword", orders.UserId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            return View();
        }

            private bool OrdersExists(int id)
        {
          return _context.Orders.Any(e => e.Id == id);
        }
    }
}
