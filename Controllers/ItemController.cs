using emarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost]
    public void Buy(ItemViewModel item){
        if (Request.Cookies["Login"] != null){
            string activeUsername = Request.Cookies["Login"]!;
            var order = _db.OrderUsers.Last(o => o.PurchaserUsername == activeUsername);
            if (order.IsConfirmed){
                //_db.OrderUsers.Add();
                //_db.OrderItems.Add();
            } else {
                var ordered = _db.OrderItems.All(o => o.OrderId == order.OrderId && o.PurchasedItem == item.Name);
                if(ordered){
                    //Update the amount
                    //Update total price
                }
                else{
                    //Add a value of the new item
                    //Update total price
                }
            }
        } else{
            //Return error message regarding login status
        }
    }
}