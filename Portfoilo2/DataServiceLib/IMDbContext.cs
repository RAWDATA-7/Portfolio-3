using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;

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
        public DbSet<BestRatedActor> BestRatedActors { get; set; }
        public DbSet<PopularTitle> PopularTitles { get; set; }

        public DbSet<FindCoActor> FindCoActors { get; set;}
        public DbSet<BestRatedTitle> BestRatedTitles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        string path = System.IO.File.ReadAllText(@"C:\Users\JesperBlom\hello\Portfolio2\Portfoilo2\path.txt");
        //string path = System.IO.File.ReadAllText(@"C:\Users\sfsto\Documents\GitHub\Portfolio2\Portfoilo2\path.txt");

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql(path);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>().ToTable("names");
            modelBuilder.Entity<Actor>().Property(x => x.Id).HasColumnName("nameid");
            modelBuilder.Entity<Actor>().Property(x => x.Name).HasColumnName("primaryname");
            modelBuilder.Entity<Actor>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<Actor>().Property(x => x.DeathYear).HasColumnName("deathyear");
            modelBuilder.Entity<Actor>().Property(x => x.Rating).HasColumnName("actorrating");

            modelBuilder.Entity<Profession>().ToTable("professions").HasKey(pk => new { pk.ActorId, pk.Name});
            modelBuilder.Entity<Profession>().Property(x => x.ActorId).HasColumnName("nameid");
            modelBuilder.Entity<Profession>().Property(x => x.Name).HasColumnName("professionname");

            modelBuilder.Entity<Principals>().ToTable("principals").HasKey(pk => new { pk.TitleId, pk.ActorId});
            modelBuilder.Entity<Principals>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Principals>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Principals>().Property(x => x.ActorId).HasColumnName("nameid");
            modelBuilder.Entity<Principals>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<Principals>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<Principals>().Property(x => x.Characters).HasColumnName("characters");

            modelBuilder.Entity<KnownForTitles>().ToTable("knownfortitles").HasKey(pk => new { pk.TitleId, pk.ActorId});
            modelBuilder.Entity<KnownForTitles>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<KnownForTitles>().Property(x => x.ActorId).HasColumnName("nameid");

            modelBuilder.Entity<Title>().ToTable("titles");
            modelBuilder.Entity<Title>().Property(x => x.Id).HasColumnName("titleid");
            modelBuilder.Entity<Title>().Property(x => x.Type).HasColumnName("titletype");
            modelBuilder.Entity<Title>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Title>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");
            modelBuilder.Entity<Title>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<Title>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<Title>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<Title>().Property(x => x.RunTimeMinutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<Title>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<Title>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<Title>().Property(x => x.Plot).HasColumnName("plot");

            modelBuilder.Entity<Domain.Index>().ToTable("index").HasKey(pk => new { pk.TitleId });
            modelBuilder.Entity<Domain.Index>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Domain.Index>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<Domain.Index>().Property(x => x.Field).HasColumnName("field");

            modelBuilder.Entity<Aka>().ToTable("akas").HasKey(pk => new { pk.TitleId});
            modelBuilder.Entity<Aka>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Aka>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Aka>().Property(x => x.TitleName).HasColumnName("title");
            modelBuilder.Entity<Aka>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<Aka>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<Aka>().Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<Aka>().Property(x => x.Attributes).HasColumnName("attributes");
            modelBuilder.Entity<Aka>().Property(x => x.IsOriginalTitle).HasColumnName("isoriginaltitle");

            modelBuilder.Entity<Genre>().ToTable("genres").HasKey(pk => new { pk.TitleId });
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasColumnName("genrename");
            modelBuilder.Entity<Genre>().Property(x => x.TitleId).HasColumnName("titleid");

            modelBuilder.Entity<Rating>().ToTable("ratings").HasKey(pk => new { pk.TitleId });
            modelBuilder.Entity<Rating>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<Rating>().Property(x => x.AvgRating).HasColumnName("avgrating");
            modelBuilder.Entity<Rating>().Property(x => x.NumVotes).HasColumnName("numvotes");

            modelBuilder.Entity<Episode>().ToTable("episodes");
            modelBuilder.Entity<Episode>().Property(x => x.Id).HasColumnName("episodeid");
            modelBuilder.Entity<Episode>().Property(x => x.TitleID).HasColumnName("parentid");
            modelBuilder.Entity<Episode>().Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<Episode>().Property(x => x.EpisodeNumber).HasColumnName("episodenumber");

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnName("username");
            modelBuilder.Entity<User>().Property(x => x.FirstName).HasColumnName("firstname");
            modelBuilder.Entity<User>().Property(x => x.LastName).HasColumnName("lastname");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(x => x.Sex).HasColumnName("sex");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("password");

            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory").HasKey(pk => new { pk.UserId });
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<SearchHistory>().Property(x => x.TimeStamp).HasColumnName("timestamp");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Field).HasColumnName("field");

            modelBuilder.Entity<Bookmark>().ToTable("bookmarkings").HasKey(pk => new { pk.TitleId, pk.UserId });
            modelBuilder.Entity<Bookmark>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<Bookmark>().Property(x => x.TitleId).HasColumnName("titleid");

            modelBuilder.Entity<UserRating>().ToTable("userratings").HasKey(pk => new { pk.TitleId, pk.UserId });
            modelBuilder.Entity<UserRating>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<UserRating>().Property(x => x.TitleId).HasColumnName("titleid");
            modelBuilder.Entity<UserRating>().Property(x => x.Rating).HasColumnName("rating");

            modelBuilder.Entity<BestRatedActor>().HasNoKey();
            modelBuilder.Entity<BestRatedActor>().Property(x => x.Id).HasColumnName("nameid");
            modelBuilder.Entity<BestRatedActor>().Property(x => x.Name).HasColumnName("actorname");
            modelBuilder.Entity<BestRatedActor>().Property(x => x.BirthYear).HasColumnName("byear");
            modelBuilder.Entity<BestRatedActor>().Property(x => x.DeathYear).HasColumnName("dyear");
            modelBuilder.Entity<BestRatedActor>().Property(x => x.Rating).HasColumnName("rating");

            modelBuilder.Entity<PopularTitle>().HasNoKey();
            modelBuilder.Entity<PopularTitle>().Property(x => x.Id).HasColumnName("titleid");
            modelBuilder.Entity<PopularTitle>().Property(x => x.Name).HasColumnName("primarytitle");
            modelBuilder.Entity<PopularTitle>().Property(x => x.Rating).HasColumnName("avgrating");

            modelBuilder.Entity<FindCoActor>().HasNoKey();
            modelBuilder.Entity<FindCoActor>().Property(x => x.Id).HasColumnName("nameid");

            modelBuilder.Entity<BestRatedTitle>().HasNoKey();
            modelBuilder.Entity<BestRatedTitle>().Property(x => x.Id).HasColumnName("titleid");
            modelBuilder.Entity<BestRatedTitle>().Property(x => x.Name).HasColumnName("titlename");
            modelBuilder.Entity<BestRatedTitle>().Property(x => x.Rating).HasColumnName("avgrating");


        }
    }  
}

