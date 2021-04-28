using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBHotel.Models
{
    public class Booking
    {
        public string CreditCard { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string ClientName { get; set; }
        public string RoomId { get; set; }
    }
}
