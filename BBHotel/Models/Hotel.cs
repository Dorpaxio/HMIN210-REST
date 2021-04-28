using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBHotel.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public int StreetNumber { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Rating { get; set; }
        public Room[] Rooms { get; set; }
    }
}
