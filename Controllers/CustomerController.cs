using ComicBookStore.Data;
using Dotnet_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicBookStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ComicBookStoreDbContext _context;

        public CustomersController(ComicBookStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,PhoneNumber,RegistrationDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.RegistrationDate = DateTime.Now;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(customer);
        }
    }
}