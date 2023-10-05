using System.ComponentModel.DataAnnotations;

namespace wevibackend.Models.Account;

public class Response
{
    public ResponseStatus Status{ get; set; }
    public string Message { get; set; }
}

public enum ResponseStatus
{
    Success,
    Fail
}