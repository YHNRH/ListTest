using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ListTest.Models;
using System.ComponentModel.DataAnnotations;

namespace ListTest
{
    public partial class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
      //      Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        /*    if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-S6V7KHT;Database=Test;Trusted_Connection=True;");
            } */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      

            modelBuilder.Entity<UserRoles>()
                   .HasOne(c => c.User)
                   .WithMany(c => c.UserRoles)
                   .HasForeignKey(p => p.IdUser)
                   ;

            modelBuilder.Entity<UserRoles>()
                   .HasOne(c => c.Role)
                   .WithMany(c => c.UserRoles)
                   .HasForeignKey(p => p.IdRoles)
                   ;

            modelBuilder.Entity<Appointment>()
                   .HasOne(c => c.User)
                   .WithOne(c => c.Appointment)
                   .HasForeignKey<Appointment>(c =>c.Id)
                   ;

            modelBuilder.Entity<Appointment>()

          .HasKey(b => b.Id);

            modelBuilder.Entity<UserRoles>()

          .HasKey(b => new { b.IdUser, b.IdRoles });
        }


        public virtual DbSet<Users> Users { get; set; }
     

        public DbSet<ListTest.Models.Roles> Roles { get; set; }
     

        public DbSet<ListTest.Models.UserRoles> UserRoles { get; set; }
     

        public DbSet<ListTest.Models.Appointment> Appointment { get; set; }
    }
}