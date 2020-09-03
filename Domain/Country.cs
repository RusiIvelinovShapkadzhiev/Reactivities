using System;

namespace Domain
{
    public class Country : BaseCountryCityEntity
    {
        public bool IsPartOfEU { get; set; }
        public Guid CapitalId { get; set; }
        public string TelephoneCode { get; set; }
    }
}