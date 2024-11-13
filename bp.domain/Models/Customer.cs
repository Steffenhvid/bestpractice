namespace bp.domain.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Address Address { get; set; } = new Address();

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private Customer()
        { }
    }
}