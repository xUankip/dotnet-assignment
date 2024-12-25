using ComicBookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace ComicBookStore.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ComicBookStoreDbContext _context;

        public ReportsController(ComicBookStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
            {
                ViewBag.ErrorMessage = "Vui lòng chọn khoảng thời gian.";
                return View();
            }

            var report = from rental in _context.Rentals
                join rentalDetail in _context.RentalDetails on rental.RentalID equals rentalDetail.RentalID
                join comicBook in _context.ComicBooks on rentalDetail.ComicBookID equals comicBook.ComicBookID
                join customer in _context.Customers on rental.CustomerID equals customer.CustomerID
                where rental.RentalDate >= startDate && rental.ReturnDate <= endDate
                select new
                {
                    BookName = comicBook.Title,
                    RentalDate = rental.RentalDate,
                    ReturnDate = rental.ReturnDate,
                    CustomerName = customer.FullName,
                    Quantity = rentalDetail.Quantity
                };

            return View(report.ToList());
        }
    }
}