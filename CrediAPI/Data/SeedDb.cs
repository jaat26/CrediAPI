using CrediAPI.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrediAPI.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCreditCardsAsync();
        }

        private async Task CheckCreditCardsAsync()
        {
            if (!_context.CreditCards.Any())
            {
                AddCreditCard("John",    "Arevalo",  "1234567890", "05/25", "123");
                AddCreditCard("Juana",   "Arias",    "2345678901", "06/24", "234");
                AddCreditCard("Tereza",  "Castro",   "3456789012", "02/22", "345");
                AddCreditCard("Carlos",  "Pedraza",  "4567890123", "03/21", "456");
                AddCreditCard("Pedro",   "Perez",    "5678901234", "12/20", "567");
                AddCreditCard("Liliana", "Martinez", "6789012345", "11/23", "678");
                await _context.SaveChangesAsync();
            }
        }

        private void AddCreditCard(
            string firstName,
            string lastName,
            string cardNUmber,
            string expiration,
            string cvv)
        {
            CreditCard card = new CreditCard
            {
                CardOwnerFirstname = firstName,
                CardOwnerLastname = lastName,
                CardNumber = cardNUmber,
                ExpirationDate = expiration,
                CVV = cvv
            };
            _context.CreditCards.Add(card);
        }
    }
}



