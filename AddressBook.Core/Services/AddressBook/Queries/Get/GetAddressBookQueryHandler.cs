using AddressBook.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Core.Services.AddressBook.Queries.Get
{
    public class GetAddressBookQueryHandler : IRequestHandler<GetAddressBookQuery, AddressBookModel>
    {

        public GetAddressBookQueryHandler(AddressBookDbContext dbContext, ILogger<GetAddressBookQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        private readonly AddressBookDbContext _dbContext;
        private readonly ILogger<GetAddressBookQueryHandler> _logger;

        public async Task<AddressBookModel> Handle(GetAddressBookQuery request, CancellationToken cancellationToken)
        {
            var addressBook = await _dbContext.AddressBooks.LastOrDefaultAsync();
            if (addressBook is null)
            {
                _logger.LogError("Error - addres book was null");
                throw new Exception("Address book was null");
            }
            _logger.LogInformation("Last found address: ");
            return new AddressBookModel
            {


                City = addressBook.City,
                Country = addressBook.Country,
                ZipCode = addressBook.ZipCode,
                Street = addressBook.Street,
                HouseNumber = addressBook.HouseNumber,
                Id = addressBook.Id
            };
        }
    }
}
