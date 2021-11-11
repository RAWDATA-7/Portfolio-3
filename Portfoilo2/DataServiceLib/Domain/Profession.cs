using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class Profession
    {
        public string ActorId { get; set; }
	    public string Name { get; set; }

        public override string ToString()
        {
            return $"ActorId = {ActorId}, Name = {Name}";
        }
    }
}
