using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataServiceLib.FuncDomain;

namespace DataServiceLib.Domain
{
     public class Actor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public decimal? Rating { get; set; }

        public ICollection<Profession> Professions { get; set; }

        public ICollection<Principals> Principals { get; set; }

        public ICollection<KnownForTitles> KnownForTitles { get; set; }
        [NotMapped]
        public IList<PopularTitle> PopularTitles { get; set; }
        [NotMapped]
        public IList<FindCoActor> CoActors { get; set; }


        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, BirthYear = {BirthYear}, DeathYear = {DeathYear}, Rating = {Rating}, Profession = {Professions}," +
                $" Principals = {Principals}, KnownForTitles = {KnownForTitles}";
        }
    }
}
