using Microsoft.AspNetCore.Mvc;

namespace api.test.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}