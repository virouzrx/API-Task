namespace AddressBook.Core.Services.AddressBook.Queries.Get
{
    public class AddressBookModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string HouseNumber { get; set; }
    }
}
