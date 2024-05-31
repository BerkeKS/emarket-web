using System.ComponentModel.DataAnnotations;

namespace emarket.Models;

public class OrderViewModel {
    [Key]
    public String id {get; set;}
    [Required]
    public int totalPrice {get; set;}
    public bool isConfirmed {get; set;}
}