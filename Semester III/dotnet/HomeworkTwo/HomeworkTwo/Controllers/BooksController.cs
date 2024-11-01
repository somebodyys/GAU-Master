using HomeworkTwo.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkTwo.Controllers;

public class BooksController : Controller
{
    private static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 },
        new Book { Id = 2, Title = "1984", Author = "George Orwell", Year = 1949 }
    };

    public IActionResult Index()
    {
        return View(books);
    }

    public IActionResult Details(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return NotFound();

        return View(book);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            book.Id = books.Count + 1;
            books.Add(book);
            return RedirectToAction("Index");
        }
        return View(book);
    }
}