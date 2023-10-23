using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MyStrore.Data
{
    public class Categories
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [MaxLength(100)]
        public string? CategoryName { get; set; }

        // Danh sách ObjectId của các sản phẩm trong danh mục này
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ?ProductIds { get; set; }
    }
}
