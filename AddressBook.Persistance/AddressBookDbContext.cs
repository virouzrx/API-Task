using Microsoft.EntityFrameworkCore;
using AddressBook.Domain;

namespace AddressBook.Persistance
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options) : base(options)
        {
        }

        public DbSet<AddressBooks> AddressBooks { get; set; }
    }
}
