using System;

namespace Domain
{
    public class Brand : BaseEntity
    {
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DateOfOrigin { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string Venue { get; set; }
        public string TelephoneNumber { get; set; }
        public Guid CEOId { get; set; }
        public DateTime OurClientSince { get; set; }
        public int NumberOfEmployees { get; set; }
        public decimal PriceOfBrand { get; set; }
    }
}