using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NETCore_MongoDb.Models
{
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string FirstName { get; set; }

        [BsonElement("Surname")]
        public string LastName { get; set; }
    }
}
