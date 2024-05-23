using emarket.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace emarket.Controllers;

[ApiController]
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
                return RedirectToAction("Index", "Home");   
            } else{
                ModelState.AddModelError("", "Invalid username or password.");
            }
        }
        return View(usernameLoginViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/usernamelogin")]
    public JsonResult UsernameLoginRoute(UsernameLoginViewModel usernameLoginViewModel){
        var user = _dbcontext.Users.FirstOrDefault(u => u.Username == usernameLoginViewModel.Username);
        if (user != null && user.Password == usernameLoginViewModel.Password) {
                return new JsonResult(Ok("Successful."));   
            } else{
                return new JsonResult(BadRequest("Wrong username or password."));
            }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EmailLogin(EmailLoginViewModel emailLoginViewModel){
        if (ModelState.IsValid)
        {
            var user = _dbcontext.Users.FirstOrDefault(u => u.Email == emailLoginViewModel.Email);
            if(user != null && user.Password == emailLoginViewModel.Password){
                return RedirectToAction("Index", "Home");
            } else{
                ModelState.AddModelError("", "Invalid email or password.");
            }
        }
        return View(emailLoginViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/emaillogin")]
    public JsonResult EmailLoginRoute(EmailLoginViewModel emailLoginViewModel){
        var user = _dbcontext.Users.FirstOrDefault(u => u.Email == emailLoginViewModel.Email);
            if(user != null && user.Password == emailLoginViewModel.Password){
                return new JsonResult(Ok("Successful."));
            } else{
                return new JsonResult(BadRequest("Wrong email or password."));
            }
    }
}