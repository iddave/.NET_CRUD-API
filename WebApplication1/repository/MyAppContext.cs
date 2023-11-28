using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1.repository
{
    public class MyAppContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }
    }

    


}
