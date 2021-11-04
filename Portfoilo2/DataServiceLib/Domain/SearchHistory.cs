using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class SearchHistory
    {
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return $"UserId = {UserId}, TimeStamp = {TimeStamp}, Word = {Word}, Field = {Field}, User = {User} ";
        }
    }
}
