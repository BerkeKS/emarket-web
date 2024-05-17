using emarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace emarket.Controllers;
public class LoginController : Controller
{
    private readonly EMarketDbContext _dbcontext;
    public LoginController(EMarketDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    public IActionResult UsernameLoginIndex() {
        var userViewModel = new UserViewModel(); 
        return View(userViewModel);
    }

    public IActionResult EmailLoginIndex(){
        var userViewModel = new UserViewModel(); 
        return View(userViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UsernameLogin(UserViewModel userViewModel){
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", "Home");   
        }
        return View(userViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EmailLogin(UserViewModel userViewModel){
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", "Home");   
        }
        return View(userViewModel);
    }
}