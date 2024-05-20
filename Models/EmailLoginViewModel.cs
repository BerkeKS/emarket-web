using System.ComponentModel.DataAnnotations;

public class EmailLoginViewModel
{
    [Required(ErrorMessage = "Please enter a valid email.")]
    public String? Email {get; set;}
    [Required(ErrorMessage = "This field cannot be empty.")]
    public String? Password {get; set;}
}