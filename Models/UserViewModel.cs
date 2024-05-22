using System.ComponentModel.DataAnnotations;

namespace emarket.Models;

public class UserViewModel
{
    [Key]
    public String? Username {get; set;}
    [Required]
    [MinLength(8, ErrorMessage = "The password must have at least 8 characters.")]
    //^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d])$", ErrorMessage = "The password must have at least one uppercase letter, lowercase letter, number and special character.")]
    public String? Email {get; set;}
    [Required]
    public String? Password {get; set;}
    [Required]
    public String? FullName {get; set;}
    [Range(10, int.MaxValue, ErrorMessage = "Users below age 10 can not register.")]
    public int Age {get; set;}
}