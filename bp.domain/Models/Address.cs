namespace bp.domain.Models
{
    public class Address : BaseEntity
    {
        /// <summary>
        /// The street name including the number, floor and side.
        /// I.e. Bomholdtgade 4, 5th
        /// </summary>
        public string? StreetName { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
    }
}