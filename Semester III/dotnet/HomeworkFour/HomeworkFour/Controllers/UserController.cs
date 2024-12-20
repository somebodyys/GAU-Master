using HomeworkFour.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkFour.Controllers;

public class UserController : Controller
{
    private static readonly List<User> Users =
    [
        new User { Name = "John Doe", Age = 25, Email = "john@example.com" },
        new User { Name = "Jane Smith", Age = 30, Email = "jane@example.com" }
    ];
    
    public ActionResult Index()
    {
        ViewBag.Title = "User List";
        ViewBag.Message = "List of all registered users.";
        ViewData["UserCount"] = Users.Count;
        TempData["LastAdded"] = Users.Last().Name;

        return View(Users);
    }
    
    public ActionResult UserDetails()
    {
        return PartialView("_UserDetails", Users.First());
    }
}