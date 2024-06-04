using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emarket.Models;

public class OrderViewModel {

    [Key]
    public String Id {get; set;}
    [ForeignKey("Purchaser")]
    public String PurchaserName {get; set;}
    public UserViewModel Purchaser {get; set;}
    public double TotalPrice {get; set;}
    public bool IsConfirmed {get; set;}
}