using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataServiceLib.Domain;

namespace DataServiceLib
{
    class IMDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<KnownForTitles> KnownForTitles { get; set; }
        public DbSet<Principals> Principals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string path = System.IO.File.ReadAllText(@"Portfoilo2/path");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql(path);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>().ToTable("names");
            modelBuilder.Entity<Actor>().Property(x => x.Id).HasColumnName("nameID");
            modelBuilder.Entity<Actor>().Property(x => x.Name).HasColumnName("primaryname");
            modelBuilder.Entity<Actor>().Property(x => x.BirthYear).HasColumnName("birthYear");
            modelBuilder.Entity<Actor>().Property(x => x.DeathYear).HasColumnName("deathYear");
            modelBuilder.Entity<Actor>().Property(x => x.Rating).HasColumnName("actorrating");
   
            modelBuilder.Entity<Profession>().ToTable("professions");
            modelBuilder.Entity<Profession>().Property(x => x.ActorId).HasColumnName("nameID");
            modelBuilder.Entity<Profession>().Property(x => x.Name).HasColumnName("professionname");

            modelBuilder.Entity<Principals>().ToTable("principals");
            modelBuilder.Entity<Principals>().Property(x => x.TitleID).HasColumnName("titleID");
            modelBuilder.Entity<Principals>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Principals>().Property(x => x.ActorID).HasColumnName("nameID");
            modelBuilder.Entity<Principals>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<Principals>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<Principals>().Property(x => x.Characters).HasColumnName("characters");

            modelBuilder.Entity<KnownForTitles>().ToTable("knownfortitles");
            modelBuilder.Entity<KnownForTitles>().Property(x => x.TitleID).HasColumnName("titleID");
            modelBuilder.Entity<KnownForTitles>().Property(x => x.ActorID).HasColumnName("nameID");
        }
    }
}

