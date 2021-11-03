using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class Profession
    {
        public string Id { get; set; }
	    public string Name { get; set; }
        
        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}";
        }
    }
}
