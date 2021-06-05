using MediatR;
using System;
using System.Collections.Generic;
namespace AddressBook.Core.Services.AddressBook.Add
{
    public class AddAddressBookCommand : IRequest
    {
        public string Country { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string ZipCode { get; init; }
        public string HouseNumber { get; init; }

    }
}
