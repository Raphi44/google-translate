namespace google_translate.Responses
{
    public class TranslateResponse
    {
        public string Translation { get; set; }
        public bool CacheHit { get; set; }

        public TranslateResponse(string translation, bool cacheHit) => (Translation, CacheHit) = (translation, cacheHit);
    }
}
