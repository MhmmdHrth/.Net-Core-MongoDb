using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BookServices.Core
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }
    }
}
