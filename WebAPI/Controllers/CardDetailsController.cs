using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardDetailsController : ControllerBase
    {
        ICardDetailService _cardDetailService;

        public CardDetailsController(ICardDetailService cardDetailService)
        {
            _cardDetailService = cardDetailService;
        }

        [HttpPost("addcard")]
        public IActionResult AddCard(CardDetail cardDetail)
        {
            var result = _cardDetailService.AddCard(cardDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getcardsbyuserid")]
        public IActionResult GetCardsByUserId(int userId)
        {
            var result = _cardDetailService.GetCardsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
