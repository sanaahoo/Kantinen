using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model

{
    public class Login
    
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty; // Store hashed passwords
    }
}
