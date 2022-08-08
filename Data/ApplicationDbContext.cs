using Microsoft.EntityFrameworkCore;
using WebAppBookList.Models;

namespace WebAppBookList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Book> Books { get; set; }
    }
}
