using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace google_translate.Models
    
{
    public class Phrase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        //[BsonElement(nameof(from))]
        public string from { get; set; }=String.Empty;

        //[BsonElement(nameof(to))]
        public string to { get; set; } =String.Empty;

        //[BsonElement(nameof(phrase))]
        public string phrase { get; set; } = String.Empty; //typo here

        //[BsonElement(nameof(translation))]
        public string translation { get; set; } = String.Empty;

        //[BsonElement(nameof(key))]
        public string key { get; set; }= String.Empty;    

        public Phrase(string from, string to, string phrase, string key, string translation)
        {
            this.from = from;
            this.to = to;
            this.phrase = phrase;
            this.key = key;
            this.translation = translation;
        }
    }
}
