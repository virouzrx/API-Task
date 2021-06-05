using MediatR;
using System.Collections.Generic;

namespace AddressBook.Core.Services.AddressBook.Queries.Get_City
{
    public class GetCityAddressBookQuery : IRequest<List<CityAddressBook>>
    {
        public string City { get; init; }
    }
}
