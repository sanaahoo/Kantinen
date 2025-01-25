using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model
{
    public class Login
    {
        // Unikt ID for brugeren (ObjectId i MongoDB)
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        // Brugernavn til login
        public string Username { get; set; } = string.Empty;

        // Adgangskode til login 
        public string Password { get; set; } = string.Empty;
    }
}