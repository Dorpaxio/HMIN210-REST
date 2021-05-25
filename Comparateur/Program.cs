using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comparateur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur le comparateur d'hôtels !");

            Dictionary<int, Agency> agencies = new Dictionary<int, Agency>();
            agencies.Add(1, new Agency("MaximouAgency", "https://localhost:4001/api"));
            agencies.Add(2, new Agency("QuentinouAgency", "https://localhost:4003/api"));

            Console.WriteLine("Il y a actuellement " + agencies.Count + " agences disponibles.");
            foreach(int id in agencies.Keys)
            {
                Agency agency = agencies[id];
                Console.WriteLine("- " + id + " : " + agency.Name);
            }

            string operation = "0";
            do
            {
                Console.WriteLine("Sélectionnez une opération :");
                Console.WriteLine("- 1 : Comparer les offres");
                Console.WriteLine("- 2 : Réserver un chambre");
                Console.WriteLine("- autre : Terminer");
                operation = Console.ReadLine();

                if(operation == "1")
                {
                    foreach(int id in agencies.Keys)
                    {
                        Agency agency = agencies[id];
                        Offer[] offers = agency.GetOffers().Result;
                        Console.WriteLine("### Agence : " + agency.Name + " ###");
                        foreach(Offer offer in offers)
                        {
                            Console.WriteLine("- Hotel : " + offer.HotelId + " | Chambre : " + offer.Id + " - " + offer.Beds + " lits - " + offer.Price + " euros (" + offer.ImgUrl + ")\n");
                        }
                        Console.WriteLine("######\n");
                    }
                } else if(operation == "2")
                {
                    Console.WriteLine("Vous souhaitez réserver une chambre. Entrez les informations suivantes :");
                    Console.WriteLine("Identifiant de l'agence : ");
                    string agencyId = Console.ReadLine();
                    Console.WriteLine("Votre prénom & nom : ");
                    string clientName = Console.ReadLine();
                    Console.WriteLine("Combien êtes-vous pour dormir : ");
                    string nbClients = Console.ReadLine();
                    Console.WriteLine("Votre carte de crédit :");
                    string creditCard = Console.ReadLine();
                    Console.WriteLine("Identifiant de l'hôtel : ");
                    string hotelId = Console.ReadLine();
                    Console.WriteLine("Identifiant de la chambre : ");
                    string roomId = Console.ReadLine();
                    Console.WriteLine("Date d'arrivée (format jj/MM/aaaa) :");
                    string arrivalDate = Console.ReadLine();
                    Console.WriteLine("Date de départ (format jj/MM/aaaa) :");
                    string departureDate = Console.ReadLine();

                    Console.WriteLine(agencyId);
                    Console.WriteLine(clientName);
                    Console.WriteLine(nbClients);
                    Console.WriteLine(creditCard);
                    Console.WriteLine(hotelId);
                    Console.WriteLine(roomId);
                    Console.WriteLine(arrivalDate);
                    Console.WriteLine(departureDate);

                    Agency agency = agencies[int.Parse(agencyId)];
                    string result = agency.BookOffer(int.Parse(hotelId), roomId, arrivalDate, departureDate, clientName, creditCard, int.Parse(nbClients)).Result;
                    Console.WriteLine(result + "\n\n");
                }

            } while (operation == "1" || operation == "2");

            Console.WriteLine("Appuyez sur Entrée pour terminer.");
            Console.ReadLine();
        }
    }
}
