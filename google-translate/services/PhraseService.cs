using google_translate.Models;
using MongoDB.Driver;

namespace google_translate.services
{
    public class PhraseService : IPhraseService
    {
        private readonly IMongoCollection<Phrase> _phrase;

        public PhraseService(IdbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _phrase = database.GetCollection<Phrase>(settings.phraseCollectionName);
        }
        public Phrase Create(Phrase phrase)
        {
            _phrase.InsertOne(phrase);
            return phrase;
        }

        public Task CreateAsync(Phrase phrase)
        {
            return _phrase.InsertOneAsync(phrase);
        }

        public Phrase Get(string key)
        {
            return _phrase.Find(phrase => phrase.key==key).FirstOrDefault();
        }

        public async Task<Phrase> GetByKeyAsync(string key)
        {
            var phrase = await _phrase.FindAsync(phrase => phrase.key==key);
            return await phrase.FirstOrDefaultAsync();
        }

    }
}
