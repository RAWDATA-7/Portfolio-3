using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class KnownForTitles
    {
        public string TitleID { get; set; }
        public string ActorID { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public override string ToString()
        {
            return $"TitleID = {TitleID}, ActorID = {ActorID}, Actors = {Actors}";
        }
    }
}
