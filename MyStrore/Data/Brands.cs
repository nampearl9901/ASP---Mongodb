using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStrore.Data { 

  
public class Brands
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ?Id { get; set; }

        [MaxLength(100)]
        public string? BrandName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ?ProductIds { get; set; }

    }
}
