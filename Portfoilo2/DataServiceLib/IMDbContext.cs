using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataServiceLib.Domain;

namespace DataServiceLib
{
    public class IMDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<KnownForTitles> KnownForTitles { get; set; }
        public DbSet<Principals> Principals { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Domain.Index> Indices { get; set; }
        public DbSet<Aka> Akas { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //string path = System.IO.File.ReadAllText(@"Portfoilo2/path");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql("host = rawdata.ruc.dk; db = raw7; uid = raw7; pwd = IWaVYCuK");
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

            modelBuilder.Entity<Title>().ToTable("titles");
            modelBuilder.Entity<Title>().Property(x => x.Id).HasColumnName("titleID");
            modelBuilder.Entity<Title>().Property(x => x.Type).HasColumnName("titleType");
            modelBuilder.Entity<Title>().Property(x => x.PrimaryTitle).HasColumnName("primartTitle");
            modelBuilder.Entity<Title>().Property(x => x.OriginalTitle).HasColumnName("originalTitle");
            modelBuilder.Entity<Title>().Property(x => x.IsAdult).HasColumnName("isAdult");
            modelBuilder.Entity<Title>().Property(x => x.StartYear).HasColumnName("startYear");
            modelBuilder.Entity<Title>().Property(x => x.EndYear).HasColumnName("endYear");
            modelBuilder.Entity<Title>().Property(x => x.RunTimeMinutes).HasColumnName("runTimeMinutes");
            modelBuilder.Entity<Title>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<Title>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<Title>().Property(x => x.Plot).HasColumnName("plot");

            modelBuilder.Entity<Domain.Index>().ToTable("index");
            modelBuilder.Entity<Domain.Index>().Property(x => x.TitleID).HasColumnName("titleID");
            modelBuilder.Entity<Domain.Index>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<Domain.Index>().Property(x => x.Field).HasColumnName("field");

            modelBuilder.Entity<Aka>().ToTable("akas");
            modelBuilder.Entity<Aka>().Property(x => x.TitleID).HasColumnName("titleID");
            modelBuilder.Entity<Aka>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Aka>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<Aka>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<Aka>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<Aka>().Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<Aka>().Property(x => x.Attributes).HasColumnName("attributes");
            modelBuilder.Entity<Aka>().Property(x => x.IsOriginalTitle).HasColumnName("isOriginalTitle");

            modelBuilder.Entity<Genre>().ToTable("genres");
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasColumnName("genreName");
            modelBuilder.Entity<Genre>().Property(x => x.TitleId).HasColumnName("titleID");

            modelBuilder.Entity<Rating>().ToTable("ratings");
            modelBuilder.Entity<Rating>().Property(x => x.TitleId).HasColumnName("titleID");
            modelBuilder.Entity<Rating>().Property(x => x.AvgRating).HasColumnName("avgRating");
            modelBuilder.Entity<Rating>().Property(x => x.NumVotes).HasColumnName("numVotes");

            modelBuilder.Entity<Episode>().ToTable("episodes");
            modelBuilder.Entity<Episode>().Property(x => x.Id).HasColumnName("episodeID");
            modelBuilder.Entity<Episode>().Property(x => x.TitleID).HasColumnName("parentID");
            modelBuilder.Entity<Episode>().Property(x => x.SeasonNumber).HasColumnName("seasonNumber");
            modelBuilder.Entity<Episode>().Property(x => x.EpisodeNumber).HasColumnName("episodeNumber");

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("userID");
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnName("userName");
            modelBuilder.Entity<User>().Property(x => x.FirstName).HasColumnName("firstName");
            modelBuilder.Entity<User>().Property(x => x.LastName).HasColumnName("lastName");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(x => x.Sex).HasColumnName("sex");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("password");

            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory");
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("userID");
            modelBuilder.Entity<SearchHistory>().Property(x => x.TimeStamp).HasColumnName("timeStamp");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Field).HasColumnName("field");

            modelBuilder.Entity<Bookmark>().ToTable("bookmarkings");
            modelBuilder.Entity<Bookmark>().Property(x => x.UserId).HasColumnName("userID");
            modelBuilder.Entity<Bookmark>().Property(x => x.TitleId).HasColumnName("titleID");

            modelBuilder.Entity<UserRating>().ToTable("userratings");
            modelBuilder.Entity<UserRating>().Property(x => x.UserId).HasColumnName("userID");
            modelBuilder.Entity<UserRating>().Property(x => x.TitleId).HasColumnName("titleID");
            modelBuilder.Entity<UserRating>().Property(x => x.Rating).HasColumnName("rating");
        }
    }
}

