using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Models;

namespace SocialApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly SocialAppDbContext _context;


    public HomeController(ILogger<HomeController> logger, SocialAppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Users()
    {
        var allUsers = _context.Users.ToList();

        return View(allUsers);
    }

     public IActionResult CreateEditUser(int? Id)
    {
        if (Id.HasValue)
        {
            var userInDb = _context.Users.SingleOrDefault(user => user.Id == Id);
            return View(userInDb);
        }

        return View();
    }

     public IActionResult DeleteUser(int Id)
    {
        var userInDb = _context.Users.SingleOrDefault(user => user.Id == Id);
        _context.Users.Remove(userInDb);
        _context.SaveChanges();

        return RedirectToAction("Users");
    }

     public IActionResult CreateEditUserForm(User model)
    {
        if (model.Id == 0){
            _context.Users.Add(model);
        } else {
            _context.Users.Update(model);
        }

        _context.SaveChanges();

        return RedirectToAction("Users");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
