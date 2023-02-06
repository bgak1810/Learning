using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    /* we will inject this dbcontext into our services for di into our controler to talk to the db*/
    public class BooksAPIDBContext : DbContext
    {
        public BooksAPIDBContext(DbContextOptions options) : base(options)
        {
        }
        /* this property acts as tables for efcore */
        public DbSet<Books> PropBooks { get; set; }
    }
}
