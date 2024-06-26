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
        var usernameLoginViewModel = new UsernameLoginViewModel(); 
        return View(usernameLoginViewModel);
    }

    public IActionResult EmailLoginIndex(){
        var emailLoginViewModel = new EmailLoginViewModel(); 
        return View(emailLoginViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UsernameLogin(UsernameLoginViewModel usernameLoginViewModel){
        if (ModelState.IsValid)
        {
            var user = _dbcontext.Users.FirstOrDefault(u => u.Username == usernameLoginViewModel.Username);
            if (user != null && user.Password == usernameLoginViewModel.Password) {
                CookieOptions cookieOptions = new CookieOptions{
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("Login", usernameLoginViewModel.Username!, cookieOptions);
                return RedirectToAction("Index", "Home");   
            } else{
                ModelState.AddModelError("", "Invalid username or password.");
            }
        }
        return View(usernameLoginViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EmailLogin(EmailLoginViewModel emailLoginViewModel){
        if (ModelState.IsValid)
        {
            var user = _dbcontext.Users.FirstOrDefault(u => u.Email == emailLoginViewModel.Email);
            if(user != null && user.Password == emailLoginViewModel.Password){
                CookieOptions cookieOptions = new CookieOptions{
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("Login", user.Username!, cookieOptions);
                return RedirectToAction("Index", "Home");
            } else{
                ModelState.AddModelError("", "Invalid email or password.");
            }
        }
        return View(emailLoginViewModel);
    }

    public IActionResult Logout(String username){
        Response.Cookies.Delete("Login");
        return RedirectToAction("Index", "Home");
    }
}