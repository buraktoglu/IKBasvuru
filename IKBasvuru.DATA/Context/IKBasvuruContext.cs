using IKBasvuru.DATA.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Context
{
    public class IKBasvuruContext : DbContext
    {
        public IKBasvuruContext()
        {
        }

        public IKBasvuruContext(DbContextOptions<IKBasvuruContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobApplication> JobApplication { get; set; }
        public virtual DbSet<JobPosition> JobPosition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=.;initial catalog=IKBasvuru;uid=sa;pwd=9636333btx;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired().HasColumnType("datetime");
                entity.Property(e => e.MaritalStatus).IsRequired();
                entity.Property(e => e.KVKKCheck).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.JobPosition).IsRequired();
                entity.Property(e => e.FilePath).IsRequired();
                entity.HasIndex(e => e.JobPositionId, "IX_JobApplication_JobPositionId");
                entity.HasOne(e => e.JobPosition)
                .WithMany(p => p.JobApplication)
                .HasForeignKey(e => e.JobPositionId)
                .HasConstraintName("FK_JobApplication_JobPosition");
            });

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });
            //Configure domain classes using modelBuilder here..
        }


    }
}
