using System.ComponentModel.DataAnnotations;

namespace emarket.Models;

public class ItemViewModel
{
    [Key]
    public String Name {get; set;}
    public String? Image {get; set;}
    public String Category {get; set;}
    [Required]
    public int Amount {get; set;}
    [Required]
    public int Price {get; set;}
}