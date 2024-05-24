using emarket.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
public class ControllerRoutes
{
    private readonly EMarketDbContext _dbcontext;
    public ControllerRoutes(EMarketDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/usernamelogin")]
    public String UsernameLoginRoute(UsernameLoginViewModel usernameLoginViewModel){
        var user = _dbcontext.Users.FirstOrDefault(u => u.Username == usernameLoginViewModel.Username);
        if (user != null && user.Password == usernameLoginViewModel.Password) {
                return "Successful."; 
            } else{
                return "Wrong username or password.";
            }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/emaillogin")]
    public String EmailLoginRoute(EmailLoginViewModel emailLoginViewModel){
        var user = _dbcontext.Users.FirstOrDefault(u => u.Email == emailLoginViewModel.Email);
            if(user != null && user.Password == emailLoginViewModel.Password){
                return "Successful.";
            } else{
                return "Wrong email or password.";
            }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/register")]
    public UserViewModel RegisterRoute(UserViewModel userViewModel){
        _dbcontext.Users.Add(userViewModel);
        _dbcontext.SaveChanges();
        return userViewModel;
    }

    [HttpGet]
    [Route("/items")]
    public IEnumerable<ItemViewModel> ItemRoute(){
        IEnumerable<ItemViewModel> items = _dbcontext.Items;
        return items;
    }
}