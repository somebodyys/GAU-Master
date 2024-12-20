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
        return View(Users);
    }
    
    public ActionResult UserDetails()
    {
        return PartialView("_UserDetails", Users.First());
    }
}