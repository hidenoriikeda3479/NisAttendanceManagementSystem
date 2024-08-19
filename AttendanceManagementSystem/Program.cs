using AttendanceManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace AttendanceManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // appsettings.json を読み込むための設定
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AttendanceManagementDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // サービスプロバイダの構築
            var services = new ServiceCollection();
            services.AddDbContext<AttendanceManagementDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<Login>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                // アプリケーションの開始
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var mainForm = serviceProvider.GetRequiredService<Login>();
                Application.Run(mainForm);
            }
        }
    }
}