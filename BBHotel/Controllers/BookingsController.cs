using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBHotel.Services;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BBHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        // POST api/<BookingsController>
        [HttpPost]
        public IActionResult Post([FromForm] string roomid, [FromForm] string customername, [FromForm] string creditcard, 
            [FromForm] int nbcustomers, [FromForm] string arrival, [FromForm] string departure)
        {
            if (roomid == null || customername == null || creditcard == null || nbcustomers == 0 || arrival == null || departure == null)
                return BadRequest("Merci de renseigner tous les champs nécessaires");

            DateTime arrivalDate;
            DateTime departureDate;
            try {
                arrivalDate = DateTime.ParseExact(arrival, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                departureDate = DateTime.ParseExact(departure, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            } catch(Exception ex) {
                return BadRequest("Le format des dates est : jj/MM/aaaa (ex: 26/09/2000)");
            }

            string result = BookingsService.BookRoom(roomid, creditcard, customername, nbcustomers, arrivalDate, departureDate);
            switch(result)
            {
                case "201":
                    return Created("", "");
                case "404":
                    return NotFound("Impossible de trouver la chambre avec cet ID");
                case "4092":
                    return Conflict("Vous n'avez pas le de droit de réserver cette chambre (manque de place)");
                case "409":
                    return Conflict("Cette chambre est déjà réservée");
                default:
                    return StatusCode(500);
            }
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
