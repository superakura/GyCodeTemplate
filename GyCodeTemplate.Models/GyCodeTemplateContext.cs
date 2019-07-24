using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GyCodeTemplate.Models
{
    public partial class GyCodeTemplateContext : DbContext
    {
        public GyCodeTemplateContext()
        {
        }

        public GyCodeTemplateContext(DbContextOptions<GyCodeTemplateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeptInfo> DeptInfo { get; set; }
        public virtual DbSet<LogInfo> LogInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GyCodeTemplate;Integrated Security=True", b => b.UseRowNumberForPaging());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeptInfo>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.DeptFatherId).HasColumnName("DeptFatherID");

                entity.Property(e => e.DeptName).HasMaxLength(100);

                entity.Property(e => e.DeptRemark).HasMaxLength(200);
            });

            modelBuilder.Entity<LogInfo>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.CreatTime).HasColumnType("datetime");

                entity.Property(e => e.LogContent).HasMaxLength(500);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatTime).HasColumnType("datetime");

                entity.Property(e => e.Duty).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(200);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Sex).HasMaxLength(50);

                entity.Property(e => e.UserDeptId).HasColumnName("UserDeptID");

                entity.Property(e => e.UserName).HasMaxLength(500);

                entity.Property(e => e.UserPwd).HasMaxLength(500);
            });
        }
    }
}
