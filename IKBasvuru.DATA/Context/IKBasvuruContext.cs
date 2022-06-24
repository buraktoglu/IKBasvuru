﻿using IKBasvuru.DATA.Domain;
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
                optionsBuilder.UseSqlServer("data source=MSKK-YGB-LT9791;initial catalog=IKBasvuru;uid=sa;pwd=963633btx;MultipleActiveResultSets=True;App=EntityFramework");
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

                entity.Property(e => e.Email).IsRequired();
                
                entity.Property(e => e.Address).IsRequired();
                
                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FilePath).IsRequired();
                
                entity.HasIndex(e => e.JobPositionId, "IX_JobApplication_JobPositionId");

                entity.Property(e => e.IsActive).IsRequired();

                entity.Property(e => e.CreatedDate).IsRequired().HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).IsRequired().HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).IsRequired();

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

                entity.Property(e => e.IsActive).IsRequired();

                entity.Property(e => e.CreatedDate).IsRequired().HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).IsRequired().HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).IsRequired();
            });

        }


    }
}
