using google_translate.Models;
namespace google_translate.services
{
    public interface IPhraseService
    {
        Phrase Get(string key);
        Phrase Create(Phrase phrase);
        Task CreateAsync(Phrase phrase);
        Task<Phrase> GetByKeyAsync(string key);
    }
}
