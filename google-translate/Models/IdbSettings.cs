namespace google_translate.Models
{
    public interface IdbSettings
    {
        string DatabaseName { get; set; }
        string phraseCollectionName { get; set; }  

        string ConnectionString { get; set; }
    }
}
