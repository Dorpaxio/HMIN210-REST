using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccorHotel.Services;
using AccorHotel.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccorHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        // Un projet par hotel avec des identifiants d'agence
        // Un projet par agence qui peut se log à tous les services web des hotels
        // Un projet comparateur qui sélectionne compare chaque agence

        // GET api/<RoomsController>
        [HttpGet]
        public IActionResult Post([FromQuery] string agency, [FromQuery] string password)
        {

            if (agency == null || password == null) return Unauthorized("Vous devez passer par une agence pour voir les chambres");

            Agency agencyObj = AgenciesService.Auth(agency, password);
            if (agencyObj == null) return NotFound("Mauvaise agence ou mot de passe");

            return Ok(RoomsService.GetRooms(agencyObj));
        }
    }
}
