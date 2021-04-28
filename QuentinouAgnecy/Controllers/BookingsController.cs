using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuentinAgency.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuentinAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        // POST api/<BookingsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] int hotelid, [FromForm] string roomid, [FromForm] string customername, [FromForm] string creditcard,
            [FromForm] int nbcustomers, [FromForm] string arrival, [FromForm] string departure)
        {
            if (roomid == null || customername == null || creditcard == null || nbcustomers == 0 || arrival == null || departure == null)
                return BadRequest("Merci de renseigner tous les champs nécessaires");

            string result = await HotelsService.BookOffer(hotelid, roomid, arrival, departure, customername, creditcard, nbcustomers);
            switch(result)
            {
                case "201":
                    return Created("", "");
                case "404":
                    return NotFound("Chambre introuvable.");
                case "40401":
                    return NotFound("Hotel introuvable");
                case "409":
                    return Conflict("La chambre est déjà réservé ou il n'y a pas assez de lit");
                default:
                    return StatusCode(500);
            }
        }
    }
}
