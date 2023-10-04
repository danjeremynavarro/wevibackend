using System.ComponentModel.DataAnnotations;

namespace wevibackend.Models.Account;

public class RegisterModel
{
    public string Username { get; set; }
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
    public string Email { get; set; }
    public string Password { get; set; }
}