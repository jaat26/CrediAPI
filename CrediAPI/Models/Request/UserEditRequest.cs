using System.ComponentModel.DataAnnotations;

namespace CrediAPI.Models.Request
{
    public class UserEditRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
