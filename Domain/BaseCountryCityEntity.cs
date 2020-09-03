namespace Domain
{
    public class BaseCountryCityEntity : BaseEntity
    {
        public int Population { get; set; }
        public string Language { get; set; }
        public string Religion { get; set; }
        public string Currency { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
    }
}