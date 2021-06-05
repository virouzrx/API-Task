using AddressBook.Core.Services.AddressBook.Add;
using AddressBook.Core.Services.AddressBook.Queries.Get;
using AddressBook.Core.Services.AddressBook.Queries.Get_City;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBookAPI.Controllers
{
    public class AddressBookController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Add([FromBody]AddAddressBookCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("last")]
        public async Task<ActionResult<AddressBookModel>> GetLast()
        {
            return await Mediator.Send(new GetAddressBookQuery());
        }

        [HttpGet("{city}")]

        public async Task<ActionResult<List<CityAddressBook>>> GetByCityName(string city)
        {
            return await Mediator.Send(new GetCityAddressBookQuery {City = city});
        }
    }
}
