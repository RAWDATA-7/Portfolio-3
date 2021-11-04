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

    }
}
