using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class Genre
    {
        public string TitleId { get; set; }
        public string Name { get; set; }

        public ICollection<Title> Titles { get; set; }

        public override string ToString()
        {
            return $"TitleId = {TitleId}, Name = {Name}, Titles = {Titles}";
        }
    }

}

