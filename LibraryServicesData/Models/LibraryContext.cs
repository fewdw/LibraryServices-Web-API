using System.Data.Entity;

namespace LibraryServicesData.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() :base("name=LibraryContext"){}

        public DbSet<LibraryServicesData.Models.Book> Books { get; set; }
    }
}