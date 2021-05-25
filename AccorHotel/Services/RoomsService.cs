using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccorHotel.Models;

namespace AccorHotel.Services
{
    public static class RoomsService
    {
        private static Room[] Rooms = new Room[]
        {
            new Room() {Id = "West", Beds = 2, Price = 75.99, ImgUrl = "https://img.ohmymag.com/article/conso/chambre-d-hotel_933c08fc344d1de8e630e931a9bf35c6664ac400.jpg"},
            new Room() {Id = "North", Beds = 1, Price = 49.99, ImgUrl = "https://www.hotel-diana-dauphine.com/media/cache/jadro_resize/rc/V56aTphK1606904223/jadroRoot/medias/5658345e8f976/chambre-1.jpg"},
            new Room() {Id = "Est", Beds = 3, Price = 98.99, ImgUrl = "https://img.ohmymag.com/article/conso/chambre-d-hotel_933c08fc344d1de8e630e931a9bf35c6664ac400.jpg"},
            new Room() {Id = "South", Beds = 2, Price = 144.44, ImgUrl = "https://resize-elle.ladmedia.fr/rcrop/638,,forcex/img/var/plain_site/storage/images/loisirs/sorties/hotels/belles-chambres-d-hotel/76660985-1-fre-FR/Les-plus-belles-chambres-d-hotel-pour-une-nuit-de-Saint-Valentin-reussie.jpg"},
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
