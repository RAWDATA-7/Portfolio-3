using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class Profession
    {
        public string ActorId { get; set; }
	    public string Name { get; set; }

        public ICollection<Actor> Actors { get; set; }
        
        public override string ToString()
        {
            return $"ActorId = {ActorId}, Name = {Name}, Actors = {Actors}";
        }
    }
}
