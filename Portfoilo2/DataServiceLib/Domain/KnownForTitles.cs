using System.Collections.Generic;

namespace DataServiceLib.Domain
{
    public class KnownForTitles
    {
        public string TitleId { get; set; }
        public string ActorId { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public override string ToString()
        {
            return $"TitleId = {TitleId}, ActorId = {ActorId}, Actors = {Actors}";
        }
    }
}
