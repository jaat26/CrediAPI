using CrediAPI.Data;
using CrediAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrediAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly DataContext _context;

        public CreditCardsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCards()
        {
            try
            {
                return Ok(await _context.CreditCards.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCard>> GetCreditCard(int id)
        {
            try
            {
                CreditCard creditCard = await _context.CreditCards.FindAsync(id);
                if (creditCard == null)
                {
                    return NotFound();
                }

                return Ok(creditCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditCard(int id, CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creditCard.Id)
            {
                return BadRequest();
            }

            CreditCard card = await _context.CreditCards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            card.CardOwnerFirstname = creditCard.CardOwnerFirstname;
            card.CardOwnerLastname = creditCard.CardOwnerLastname;
            card.CardNumber = creditCard.CardNumber;
            card.ExpirationDate = creditCard.ExpirationDate;
            card.CVV = creditCard.CVV;

            try
            {
                _context.CreditCards.Update(card);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCreditCard), new { id = creditCard.Id }, creditCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<CreditCard>> PostCreditCard(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                _context.CreditCards.Add(creditCard);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCreditCard), new { id = creditCard.Id }, creditCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CreditCard>> DeleteCreditCard(int id)
        {
            CreditCard creditCard = await _context.CreditCards.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            try
            {
                _context.CreditCards.Remove(creditCard);
                await _context.SaveChangesAsync();

                return Ok(creditCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
