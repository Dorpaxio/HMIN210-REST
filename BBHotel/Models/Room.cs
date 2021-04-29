using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBHotel.Models
{
    public class Room
    {
        public string Id { get; set; }
        public int Beds { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
    }
}
