using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuentinAgency.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string RoomsPath { get; set; }
        public string BookingsPath { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
