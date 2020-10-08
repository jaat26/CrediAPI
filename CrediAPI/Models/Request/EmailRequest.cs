using System.ComponentModel.DataAnnotations;

namespace CrediAPI.Models.Request
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
