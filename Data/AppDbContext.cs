using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }
        public DbSet<LibraryManager.Models.Book> Books { get; set; }
    }
}
