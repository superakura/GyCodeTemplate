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

        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GyCodeTemplate;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(500);

                entity.Property(e => e.UserPwd).HasMaxLength(500);
            });
        }
    }
}
