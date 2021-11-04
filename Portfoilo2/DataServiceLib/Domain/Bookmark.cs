using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class Bookmark
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Title> Titles { get; set; }

        public override string ToString()
        {
            return $"UserId = {UserId}, TitleId = {TitleId}, Users = {Users}, Titles = {Titles}";
        }
    }
}
