namespace google_translate.Models

{
    public class dbSettings : IdbSettings
    {
        public string DatabaseName { get; set; }=String.Empty;
        public string phraseCollectionName { get; set; }= String.Empty;
        public string ConnectionString { get; set; } = String.Empty;

    }
}
