using System.ComponentModel.DataAnnotations;

namespace TransactionService.Application.Exceptions;


public class TransactionServiceException : Exception
{
    public string StatusCode { get; }
    public string StatusMessage { get; set; }
    [Display(Name = "Message")]
    public string MainMessage { get; set; }
    
    public TransactionServiceException(string message) : base(message)
    {
        StatusCode = "99";
        StatusMessage = message;
        MainMessage = message;
    }
}