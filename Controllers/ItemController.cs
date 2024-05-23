using emarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace emarket.Controllers;

[ApiController]
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

    [HttpGet]
    [Route("/items")]
    public JsonResult ItemRoute(){
        IEnumerable<ItemViewModel> items = _db.Items;
        if(items != null){
            return new JsonResult(Ok(items));
        } else {
            return new JsonResult(NotFound());
        }
    }
}