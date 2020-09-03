using System;

namespace Domain
{
    public class City : BaseCountryCityEntity
    {
        public Guid CountryId { get; set; }
        public bool IsAlsoCountry { get; set; }
        public bool IsCapital { get; set; }

    }
}