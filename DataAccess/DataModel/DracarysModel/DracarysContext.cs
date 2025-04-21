using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DataModel.DracarysModel
{
    public partial class DracarysContext : DbContext
    {
        public DracarysContext()
        {
        }
        [ActivatorUtilitiesConstructor]
        public DracarysContext(DbContextOptions<DracarysContext> options) : base(options)
        {
        }


        public virtual DbSet<SysErrorLog> SysErrorLogs { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysErrorLog>(entity =>
            {
                entity.ToTable("SysErrorLog");

                entity.Property(e => e.Class)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(2)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrorMessage).IsUnicode(false);

                entity.Property(e => e.Host)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Method)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
