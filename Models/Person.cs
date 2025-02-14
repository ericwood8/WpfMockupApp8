namespace WpfMockupApp8.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public Person (string id, string active, string firstName, string lastName, string email, string phoneNumber, string address, string city, string state, string zipCode)
        {
            // Required
            if (Guid.TryParse(id, out Guid result))
                Id = result;
            else 
                Id = Guid.Empty;
            Active = bool.Parse(active);
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;

            // Optional
            State = state;
            ZipCode = zipCode;
        }
    }
}
