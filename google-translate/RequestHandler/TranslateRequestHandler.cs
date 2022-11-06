using google_translate.Models;
using google_translate.Requests;
using google_translate.Responses;
using google_translate.services;

namespace google_translate.RequestHandler
{
    public class TranslateRequestHandler
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IPhraseService _phraseService;

        public TranslateRequestHandler(IConfiguration configuration, HttpClient httpClient, IPhraseService phraseService)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _phraseService = phraseService;
        }

        public async Task<TranslateResponse> Translate(TranslateRequest request)
        {
            var key = GetMongoKey(request);
            var cacheResult = await _phraseService.GetByKeyAsync(key);

            if (cacheResult == null)
            {
                var translationResponse = await GetFromNodeRed(request);
                await PersistToCache(new Phrase(request.From, request.To, request
                    .Phrase, key, translationResponse.Translation));
                return translationResponse;
            }

            return new TranslateResponse(cacheResult.translation, true);
        }

        private async Task<TranslateResponse> GetFromNodeRed(TranslateRequest request)
        {
            var url = $"{_configuration["TranslateUrl"]}?from={request.From}&to={request.To}&phrase={request.Phrase}";
            var response = await _httpClient.GetAsync(url);
            var translation = await response.Content.ReadAsStringAsync();

            return new TranslateResponse(translation, false);
        }

        private Task PersistToCache(Phrase phrase)
        {
            return _phraseService.CreateAsync(phrase);
        }

        //lower case all so same values will always produce the same key
        private string GetMongoKey(TranslateRequest request) 
        {
            return $"{request.From}_{request.To}_{request.Phrase}".ToLower();
        }
        
           
        
    }
}
