using System.ComponentModel.DataAnnotations;

namespace CrediAPI.Models.Request
{
    public class CreditCardRequest
    {
        [Required]
        [MaxLength(50)]
        public string CardOwnerFirstname { get; set; }

        [Required]
        [MaxLength(50)]
        public string CardOwnerLastname { get; set; }

        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string ExpirationDate { get; set; }

        [Required]
        [MaxLength(3)]
        public string CVV { get; set; }
    }
}
