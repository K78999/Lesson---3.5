using Lesson_3._5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_3._5.Controllers
{
    public class BookController : Controller
    {
        // Static list to store books (in-memory)
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20, Description = "A Handbook of Agile Software Craftsmanship" },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15, Description = "Professional ASP.NET MVC" },
            new Book { Id = 3, Name = "Design Pattern", Price = 25, Description = "Elements of Reusable Object-Oriented Software" }
        };

        // Index Action - Danh sách sách
        public IActionResult Index()
        {
            return View(books);
        }

        // Detail Action - Chi tiết sách
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Add Action - GET: Display form
        public IActionResult Add()
        {
            return View();
        }

        // Add Action - POST: Handle form submission
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                // Generate new Id
                book.Id = books.Max(b => b.Id) + 1;
                books.Add(book);
                TempData["SuccessMessage"] = $"Thêm sách '{book.Name}' thành công!";
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
