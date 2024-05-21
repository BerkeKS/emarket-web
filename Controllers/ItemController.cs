using emarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace emarket.Controllers;

public class ItemController : Controller
{
    private readonly EMarketDbContext _db;

    public ItemController(EMarketDbContext db){
        _db = db;
    }
    public IActionResult Index(){
        IEnumerable<ItemViewModel> items = _db.Items;
        return View(items);
    }
}