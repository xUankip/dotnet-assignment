using ComicBookStore.Data;
using Dotnet_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBookStore.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ComicBookStoreDbContext _context;

        public RentalsController(ComicBookStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.ComicBooks = _context.ComicBooks.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int customerId, int comicBookId, int quantity, DateTime returnDate)
        {
            if (ModelState.IsValid)
            {
                var comicBook = await _context.ComicBooks.FindAsync(comicBookId);

                var rental = new Rental
                {
                    CustomerID = customerId,
                    RentalDate = DateTime.Now,
                    ReturnDate = returnDate,
                    Status = "Đang thuê"
                };

                _context.Add(rental);
                await _context.SaveChangesAsync();

                var rentalDetail = new RentalDetail
                {
                    RentalID = rental.RentalID,
                    ComicBookID = comicBookId,
                    Quantity = quantity,
                    PricePerDay = comicBook.PricePerDay
                };

                _context.Add(rentalDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}