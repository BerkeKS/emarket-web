using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emarket.Models;

public class OrderUserModel {

    public OrderUserModel(String id, string username, double price, bool completed){
        OrderId = id;
        PurchaserUsername = username;
        totalPrice = price;
        IsConfirmed = completed;
    }

    [Key]
    public String OrderId {get; set;}
    [ForeignKey("Purchaser")]
    public String PurchaserUsername {get; set;}
    public UserViewModel Purchaser {get; set;}
    public double totalPrice {get; set;}
    public bool IsConfirmed {get; set;}
}