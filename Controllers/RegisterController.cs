using emarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace emarket.Controllers;

public class RegisterController : Controller
{
    private readonly EMarketDbContext _dbcontext;

    public RegisterController(EMarketDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    public IActionResult Index() {
        var userViewModel = new UserViewModel(); 
        return View(userViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(UserViewModel userViewModel){
        if(ModelState.IsValid)
        {
            _dbcontext.Users.Add(userViewModel);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return View(userViewModel);
    }
}