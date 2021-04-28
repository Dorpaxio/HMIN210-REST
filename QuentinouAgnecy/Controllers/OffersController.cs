using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuentinAgency.Services;
using QuentinAgency.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuentinAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        // GET: api/<OffersController>
        [HttpGet]
        public Room[] Get()
        {
            return HotelsService.GetOffers().Result;
        }
    }
}
