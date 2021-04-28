using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaximouAgency.Services;
using MaximouAgency.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaximouAgency.Controllers
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
