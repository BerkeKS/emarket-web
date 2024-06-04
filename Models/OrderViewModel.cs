using System.ComponentModel.DataAnnotations;

namespace emarket.Models;

public class OrderViewModel {

    [Key]
    public String Id {get; set;}
    [Required]
    public List<Tuple<String, int>> PurchasedItems {get; set;}
    [Required]
    public double TotalPrice {get; set;}
    public bool IsConfirmed {get; set;}
}