using CrediAPI.Data.Entities;
using CrediAPI.Helpers;
using CrediAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrediAPI.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCreditCardsAsync();
            await CheckRolesAsync(); 
            await CheckUserAsync("John", "Arevalo", "john_arevalo@hotmail.com", "313 535 9237", UserType.Admin);
        }

        private async Task<User> CheckUserAsync(
            string firstName,
            string lastName,
            string email,
            string phone,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
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



