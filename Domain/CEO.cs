using System;

namespace Domain
{
    public class CEO : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CountryId { get; set; }
        public string Experience { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}