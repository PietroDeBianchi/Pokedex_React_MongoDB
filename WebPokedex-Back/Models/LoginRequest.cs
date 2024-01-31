using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebPokedex.Models
{
    public class LoginRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? username { get; set; }   

        public string? password { get; set; }
    }
}
