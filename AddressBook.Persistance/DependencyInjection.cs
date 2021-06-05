using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<AddressBookDbContext>(options => options.UseInMemoryDatabase("AddressBookDatabase"));
            return services;
        }
    }
}
