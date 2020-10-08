using System.ComponentModel.DataAnnotations;

namespace CrediAPI.Models.Request
{
    public class ChangePasswordRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string NewPasswordConfirm { get; set; }
    }
}
