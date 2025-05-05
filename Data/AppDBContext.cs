using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IMSApi.Models;
using Microsoft.AspNetCore.Identity;

namespace IMSApi.Data 
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Image> Image { get; set; }

        public DbSet<Report> Report { get; set; }

        public DbSet<Financial> Financial { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<AppointmentSlot> AppointmentSlots { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships for Image
            modelBuilder.Entity<Image>()
                .HasOne(i => i.UploadedStaff)
                .WithMany() // UploadedStaff does not have a navigation property back to Image
                .HasForeignKey(i => i.UploadedBy)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Image>()
                .HasOne(i => i.AssignedStaff)
                .WithMany() // AssignedStaff does not have a navigation property back to Image
                .HasForeignKey(i => i.AssignedTo)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Report>()
        .HasOne(r => r.CreatedStaff)
        .WithMany() // No reverse navigation property in Staff
        .HasForeignKey(r => r.CreatedBy)
        .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
        }
    }
}