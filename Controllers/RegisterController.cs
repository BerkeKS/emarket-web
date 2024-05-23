using emarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace emarket.Controllers;

[ApiController]
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
            return RedirectToAction("UsernameLoginIndex", "Login");
        }
        return View(userViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/register")]
    public JsonResult RegisterRoute(UserViewModel userViewModel){
        _dbcontext.Users.Add(userViewModel);
        _dbcontext.SaveChanges();
        return new JsonResult(Ok(userViewModel));
    }
}