﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YellowCart.Data;
using YellowCart.Models;
using YellowCart.ViewModels;

namespace YellowCart.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
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
            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users users)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.SingleOrDefault(m => m.Email == users.Email) == null)
                {
                    _context.Add(users);
                    await _context.SaveChangesAsync();
                    TempData["sucess"] = "User Created sucess, Please Login";
                    
                    return RedirectToAction("Index","Home");
                }
                TempData["error"] = "Email already exist";
                return View();
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var UID = HttpContext.Session.GetInt32("Id");
            Users user = _context.Users.Find(UID);
            
            if (id == null || _context.Users == null || id!=UID)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Users users)
        {
            if (id != users.Id)
            {
                return RedirectToAction("Pagenotfound", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return RedirectToAction("Pagenotfound", "Home");
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["sucess"] = "Profile updated sucess!";
                return RedirectToAction("Index","Home");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Login(string? returnUrl)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel login,string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                
                var user = await _context.Users
                .SingleOrDefaultAsync(m => m.Email == login.Email);
                if (user == null) 
                {
                    ModelState.AddModelError("Email","Email id is Not found");
                    return View("Login");
                }
                if (user.Password==login.Password)
                {
                    HttpContext.Session.SetInt32("Id", user.Id);
                    ViewData["user"] = user;
                    TempData["sucess"] = "Log in sucess, Welcome Back "+user.FirstName;

                    var cartCount = _context.Cart.Where(m => m.User == user).Count();
                    HttpContext.Session.SetInt32("cart", cartCount);

                    
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
       
                        return Redirect(HttpUtility.UrlDecode(returnUrl));
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("Password", "Invalid Password");
            }
            return View("Login");

        }
        public async Task<IActionResult> Logout()
        {

            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("cart");
            TempData["sucess"] = "Log out sucess";
            return RedirectToAction("Index", "Home");
        }
    }
}