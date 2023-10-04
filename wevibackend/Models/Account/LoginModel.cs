using System.ComponentModel.DataAnnotations;

namespace wevibackend.Models.Account;

public class LoginModel
{ 
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "User Name is required")]
    public string Password { get; set; }
}