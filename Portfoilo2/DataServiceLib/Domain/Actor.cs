using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class Actor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public decimal? Rating { get; set; }

        public ICollection<Profession> Professions { get; set; }

        public ICollection<Principals> Principals { get; set; }

        public ICollection<KnownForTitles> KnownForTitles { get; set; }



        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, BirthYear = {BirthYear}, DeathYear = {DeathYear}, Rating = {Rating}, Profession = {Professions}," +
                $" Principals = {Principals}, KnownForTitles = {KnownForTitles}";
        }
    }
}
