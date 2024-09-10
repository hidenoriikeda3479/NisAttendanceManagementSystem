using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AttendanceManagementSystem.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AttendanceManagementDbContext>
    {
        public AttendanceManagementDbContext CreateDbContext(string[] args)
        {
            // appsettings.json を読み込むための設定
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AttendanceManagementDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new AttendanceManagementDbContext(builder.Options);
        }
    }
}
