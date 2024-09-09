using Microsoft.EntityFrameworkCore;
using AttendanceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AttendanceManagementSystem.Data
{
    /// <summary>
    /// データベースコンテキストクラス
    /// </summary>
    public class AttendanceManagementDbContext : DbContext
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="options">DbContextOptionsの設定</param>
        public AttendanceManagementDbContext(DbContextOptions<AttendanceManagementDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 従業員テーブルのDbSet
        /// </summary>
        public DbSet<EmployeeModel> Employees { get; set; } = default!;

        /// <summary>
        /// 権限マスタのDbSet
        /// </summary>
        public DbSet<PermissionModel> Permissions { get; set; } = default!;

        /// <summary>
        /// 勤怠テーブルのDbSet
        /// </summary>
        public DbSet<AttendanceModel> Attendances { get; set; } = default!;

        /// <summary>
        /// ランクマスタのDbSet
        /// </summary>
        public DbSet<RankModel> Ranks { get; set; } = default!;

        /// <summary>
        /// シフトマスタのDbSet
        /// </summary>
        public DbSet<ShiftModel> Shifts { get; set; } = default!;

        /// <summary>
        /// シフト管理テーブルのDbSet
        /// </summary>
        public DbSet<ShiftManagementModel> ShiftManagements { get; set; } = default!;

        /// <summary>
        /// モデル作成時のカスタマイズ処理
        /// </summary>
        /// <param name="modelBuilder">モデルビルダー</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 複合キーの設定
            modelBuilder.Entity<ShiftManagementModel>()
                .HasKey(sm => new { sm.EmployeeId, sm.Year, sm.Month, sm.Day });
            modelBuilder.Entity<AttendanceModel>()
                .HasKey(sm => new { sm.EmployeeId, sm.Year, sm.Month, sm.Day });

            // 権限マスタの初期データ
            modelBuilder.Entity<PermissionModel>().HasData(
                new PermissionModel { PermissionId = 1, PermissionName = "Admin", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new PermissionModel { PermissionId = 2, PermissionName = "User", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // ランクマスタの初期データ
            modelBuilder.Entity<RankModel>().HasData(
                new RankModel { RankId = 1, HourlyPay = 1000, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new RankModel { RankId = 2, HourlyPay = 1200, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // シフトマスタの初期データ
            modelBuilder.Entity<ShiftModel>().HasData(
                new ShiftModel { ShiftId = 1, ShiftTypeName = "Morning", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new ShiftModel { ShiftId = 2, ShiftTypeName = "Evening", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // 従業員テーブルの初期データ
            modelBuilder.Entity<EmployeeModel>().HasData(
                new EmployeeModel { EmployeeId = 1, EmployeeName = "John Doe", Gender = 1, Password = "hashedpassword123", PhoneNumber = "08012345678", PostCode = "1234567", Address = "Tokyo, Japan", BirthDate = new DateTime(1990, 1, 1), RankId = 1, ShiftId = 1, HireDate = new DateTime(2020, 1, 1), PermissionId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // 勤怠テーブルの初期データ
            modelBuilder.Entity<AttendanceModel>().HasData(
                new AttendanceModel { EmployeeId = 1, Year = 2024, Month = 8, Day = 9, WorkStartTime = new DateTime(2024, 8, 9, 9, 0, 0), WorkEndTime = new DateTime(2024, 8, 9, 18, 0, 0), BreakTime = new TimeSpan(1, 0, 0), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // シフト管理テーブルの初期データ
            modelBuilder.Entity<ShiftManagementModel>().HasData(
                new ShiftManagementModel { EmployeeId = 1, Year = 2024, Month = 8, Day = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );
        }
    }
}
