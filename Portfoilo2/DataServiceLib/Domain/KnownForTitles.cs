using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class KnownForTitles
    {
        public string TitleId { get; set; }
        public string ActorId { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public ICollection<Title> Titles { get; set; }

        public override string ToString()
        {
            return $"TitleId = {TitleId}, ActorId = {ActorId}, Actors = {Actors}, Titles = {Titles}";
        }
    }
}
