using CRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}
