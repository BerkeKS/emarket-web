using System.ComponentModel.DataAnnotations;

namespace emarket.Models;

public class UserViewModel
{
    [Key]
    public String? Username {get; set;}
    [Required]
    public String? Email {get; set;}
    [Required]
    public String? Password {get; set;}
    [Required]
    public String? FullName {get; set;}
    public int Age {get; set;}
}