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
            // appsettings.json ��ǂݍ��ނ��߂̐ݒ�
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AttendanceManagementDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // �T�[�r�X�v���o�C�_�̍\�z
            var services = new ServiceCollection();
            services.AddDbContext<AttendanceManagementDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<Login>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                // �A�v���P�[�V�����̊J�n
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var mainForm = serviceProvider.GetRequiredService<Login>();
                Application.Run(mainForm);
            }
        }
    }
}