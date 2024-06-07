using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emarket.Models;

public class OrderUserModel {

    [Key]
    public String Id {get; set;}
    [ForeignKey("Purchaser")]
    public String PurchaserUsername {get; set;}
    public ItemViewModel Purchaser {get; set;}
    public double totalPrice {get; set;}
    public bool IsConfirmed {get; set;}
}