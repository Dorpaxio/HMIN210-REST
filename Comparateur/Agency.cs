using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comparateur
{
    class Agency
    {
        public string Name { get; set; }
        private string Url;
        private string OffersPath;
        private string BookingsPath;

        private static HttpClient Http = new HttpClient();

        public Agency(string name, string url) : this(name, url, "/offers", "/bookings")
        {

        }

        public Agency(string name, string url, string offersPath, string bookingsPath)
        {
            this.Name = name;
            this.Url = url;
            this.OffersPath = offersPath;
            this.BookingsPath = bookingsPath;
        }

        public async Task<Offer[]> GetOffers()
        {
            HttpResponseMessage response = await Http.GetAsync(Url + OffersPath);
            return response.StatusCode.ToString() != "OK" ? null : await response.Content.ReadAsAsync<Offer[]>();
        }

        public async Task<string> BookOffer(int hotelId, string roomId, string arrivalDate, string departureDate, string clientname, string creditcard, int nbclients)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent(hotelId.ToString()), "hotelId");
            formData.Add(new StringContent(clientname), "customername");
            formData.Add(new StringContent(roomId), "roomid");
            formData.Add(new StringContent(creditcard), "creditcard");
            formData.Add(new StringContent(nbclients.ToString()), "nbcustomers");
            formData.Add(new StringContent(arrivalDate), "arrival");
            formData.Add(new StringContent(departureDate), "departure");

            HttpResponseMessage response = await Http.PostAsync(Url + BookingsPath, formData);
            switch(response.StatusCode.ToString())
            {
                case "Created":
                    return "La réservation a bien été effectuée !";
                case "Conflict":
                    return "Cette chambre a déjà été réservée ou il n'y a pas assez de lit.";
                case "NotFound":
                    return "Cette chambre n'existe pas.";
                default:
                    return "Une erreur est survenue. (" + response.StatusCode.ToString() + ")";
            }
        }
    }
}
