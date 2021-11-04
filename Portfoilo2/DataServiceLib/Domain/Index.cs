using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class Index
    {
        public string TitleId { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }

        public ICollection<Title> Titles { get; set; }

        public override string ToString()
        {
            return $"TitleId = {TitleId}, Word = {Word}, Field = {Field}, Titles = {Titles}";
        }
    }
}
