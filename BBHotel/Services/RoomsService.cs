using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBHotel.Models;

namespace BBHotel.Services
{
    public static class RoomsService
    {
        private static Room[] Rooms = new Room[]
        {
            new Room() {Id = "R45", Beds = 4, Price = 89.99, ImgUrl = "https://www.usine-digitale.fr/mediatheque/3/9/8/000493893_homePageUne/hotel-c-o-q-paris.jpg"},
            new Room() {Id = "R46", Beds = 2, Price = 49.99, ImgUrl = "https://www.deplacementspros.com/photo/art/default/18495994-22633231.jpg?v=1511806303"},
            new Room() {Id = "R47", Beds = 6, Price = 119.69, ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Hotel-room-renaissance-columbus-ohio.jpg/1200px-Hotel-room-renaissance-columbus-ohio.jpg"},
            new Room() {Id = "R48", Beds = 2, Price = 189.99, ImgUrl = "https://resize-parismatch.lanmedia.fr/img/var/news/storage/images/paris-match/vivre/art-de-vivre/une-chambre-d-hotel-entierement-vegane-1604412/25986157-1-fre-FR/Une-chambre-d-hotel-entierement-vegane.jpg"},
            new Room() {Id = "R49", Beds = 4, Price = 89.98, ImgUrl = "https://www.toutsurmesfinances.com/assurance/wp-content/uploads/sites/8/2016/11/chambre-hotel-assurance.jpg"},
        };

        public static Room[] GetRooms(Agency agency)
        {
            if (agency == null) return Rooms;
            return Rooms.Select(room => new Room() { Id = room.Id, Beds = room.Beds, Price = (1 - agency.Reduction) * room.Price, ImgUrl = room.ImgUrl }).ToArray();
        }

        public static Room getRoom(string roomId)
        {
            return Rooms.FirstOrDefault(room => room.Id.ToLower() == roomId.ToLower());
        }
    }
}
