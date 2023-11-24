using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.repository
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<MyAppContext>
    {
        public MyAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyAppContext>();

            var builder = WebApplication.CreateBuilder();
            // получаем строку подключения из файла appsettings.json
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new MyAppContext(optionsBuilder.Options);
        }
    }
}
