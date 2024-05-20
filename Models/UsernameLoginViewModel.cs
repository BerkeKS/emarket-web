using System.ComponentModel.DataAnnotations;

namespace emarket.Models;
public class UsernameLoginViewModel
{
    [Required(ErrorMessage = "This field cannot be empty.")]
    public String? Username {get; set;}
    [Required(ErrorMessage = "This field cannot be empty.")]
    public String? Password {get; set;}
}