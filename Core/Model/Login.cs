using MongoDB.Bson;
namespace Core.Model

{   
    public class Login

    {
        
        public ObjectId Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }


}