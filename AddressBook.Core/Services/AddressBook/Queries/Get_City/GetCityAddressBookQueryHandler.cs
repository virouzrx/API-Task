using AddressBook.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Core.Services.AddressBook.Queries.Get_City
{
    public class GetCityAddressBookQueryHandler : IRequestHandler<GetCityAddressBookQuery, List<CityAddressBook>>
    {
        public GetCityAddressBookQueryHandler(AddressBookDbContext dbContext, ILogger<GetCityAddressBookQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        private readonly AddressBookDbContext _dbContext;
        private readonly ILogger<GetCityAddressBookQueryHandler> _logger;


        public async Task<List<CityAddressBook>> Handle(GetCityAddressBookQuery request, CancellationToken cancellationToken)
        {
            var addressBook = await _dbContext.AddressBooks
                .Where(x => x.City == request.City)
                .Select(x => new CityAddressBook
                {
                    City = x.City,
                    Country = x.Country,
                    ZipCode = x.ZipCode,
                    Street = x.Street,
                    HouseNumber = x.HouseNumber,
                    Id = x.Id
                }).ToListAsync();
            if (addressBook is null)
            {
                _logger.LogError("Addres book was null");
                throw new Exception("Address book was null");
            }
            _logger.LogInformation("Found objects: ");
            return addressBook;
        }
    }
}
