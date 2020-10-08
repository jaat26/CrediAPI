using System.ComponentModel.DataAnnotations;

namespace CrediAPI.Data.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string CardOwnerFirstname { get; set; }

        [MaxLength(50)]
        [Required]
        public string CardOwnerLastname { get; set; }

        [MaxLength(16)]
        [Required]
        public string CardNumber { get; set; }

        [MaxLength(5)]
        [Required]
        public string ExpirationDate { get; set; }

        [MaxLength(3)]
        [Required]
        public string CVV { get; set; }
    }
}
