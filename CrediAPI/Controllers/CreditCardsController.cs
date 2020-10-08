using CrediAPI.Data;
using CrediAPI.Data.Entities;
using CrediAPI.Models.Request;
using CrediAPI.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCards()
        {
            try
            {
                return Ok(new Response
                {
                    IsSuccess = true,
                    Message = "Successful operation",
                    Data = await _context.CreditCards.ToListAsync()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }

        }


        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CreditCard>> GetCreditCard(int id)
        {
            try
            {
                CreditCard creditCard = await _context.CreditCards.FindAsync(id);
                if (creditCard == null)
                {
                    return NotFound(new Response
                    {
                        IsSuccess = false,
                        Message = "Credit card not foud"
                    });
                }

                return Ok(new Response
                {
                    IsSuccess = true,
                    Message = "Successful operation",
                    Data = creditCard
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditCard(int id, CreditCardRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Bad request",
                    Data = ModelState
                });
            }

            CreditCard card = await _context.CreditCards.FindAsync(id);
            if (card == null)
            {
                return NotFound(new Response
                {
                    IsSuccess = false,
                    Message = "Credit card not found"
                });
            }

            card.CardOwnerFirstname = request.CardOwnerFirstname;
            card.CardOwnerLastname = request.CardOwnerLastname;
            card.CardNumber = request.CardNumber;
            card.ExpirationDate = request.ExpirationDate;
            card.CVV = request.CVV;

            try
            {
                _context.CreditCards.Update(card);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCreditCard), new { id = card.Id }, card);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = ModelState
                });
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<CreditCard>> PostCreditCard(CreditCardRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Bad request",
                    Data = ModelState
                });
            }

            CreditCard card = new CreditCard
            {
                CardOwnerFirstname = request.CardOwnerFirstname,
                CardOwnerLastname = request.CardOwnerLastname,
                CardNumber = request.CardNumber,
                ExpirationDate = request.ExpirationDate,
                CVV = request.CVV
            };

            try
            {
                _context.CreditCards.Add(card);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCreditCard), new { id = card.Id }, card);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = ModelState
                });
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CreditCard>> DeleteCreditCard(int id)
        {
            CreditCard creditCard = await _context.CreditCards.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound(new Response
                {
                    IsSuccess = false,
                    Message = "Credit card not found"
                });
            }

            try
            {
                _context.CreditCards.Remove(creditCard);
                await _context.SaveChangesAsync();

                return Ok(new Response
                {
                    IsSuccess = true,
                    Message = "Successful operation",
                    Data = creditCard
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = ModelState
                });
            }
        }
    }
}
