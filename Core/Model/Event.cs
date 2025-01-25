using MongoDB.Bson;

namespace Core.Model
{
    public class Event
    {
        // Unikt ID for begivenheden (ObjectId i MongoDB)
        public ObjectId Id { get; set; }

        // Navn på begivenheden
        public string Name { get; set; } = "";

        // Dato for begivenheden
        public DateTime Dato { get; set; }

        // Lokation for begivenheden
        public string Lokation { get; set; } = "";

        // Antal deltagere til begivenheden
        public int DeltagerAntal { get; set; }

        // Madvalg til begivenheden
        public string MadValg { get; set; } = "";

        // Særlige ønsker til begivenheden
        public string SærligeØnsker { get; set; } = "";

        // Kunden, der har booket begivenheden
        public string Kunde { get; set; } = "";
    }
}