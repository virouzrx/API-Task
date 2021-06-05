using AddressBook.Domain;
using AddressBook.Persistance;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Core.Services.AddressBook.Add
{
    public class AddressBookCommandHandler : IRequestHandler<AddAddressBookCommand>
    {
        public AddressBookCommandHandler(AddressBookDbContext dbContext, ILogger<AddressBookCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        private readonly AddressBookDbContext _dbContext;
        private readonly ILogger<AddressBookCommandHandler> _logger;

        public async Task<Unit> Handle(AddAddressBookCommand request, CancellationToken cancellationToken)
        {
            var addressBook = new AddressBooks
            {
                Country = request.Country,
                City = request.City,
                Street = request.Street,
                ZipCode = request.ZipCode,
                HouseNumber = request.HouseNumber
            };

            _dbContext.AddressBooks.Add(addressBook);
            var result = await _dbContext.SaveChangesAsync() > 0;
            if (result)
            {
                _logger.LogInformation("Added object to db");
                return Unit.Value;
            }
            _logger.LogError("There was an error when trying to add object to db");
            throw new Exception("ProblemSavingChangesAddressBook");
        }
    }
}
