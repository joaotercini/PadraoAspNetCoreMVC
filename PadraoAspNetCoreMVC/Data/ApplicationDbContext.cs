using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PadraoAspNetCoreMVC.Models;

namespace PadraoAspNetCoreMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Rainfall> Rainfalls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rainfall>()
                .HasKey(r => new { r.StationId, r.Date });
            modelBuilder.Entity<Rainfall>()
                .HasOne(r => r.Station)
                .WithMany(s => s.Rainfalls)
                .HasForeignKey(r => r.StationId)
                .HasPrincipalKey(p => p.StationId);

            modelBuilder.Entity<Station>()
                .HasOne(s => s.Owner)
                .WithMany(o => o.Stations)
                .HasForeignKey(s => s.OwnerId)
                .HasPrincipalKey(o => o.OwnerId);
        }
    }
}
