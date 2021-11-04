using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class Episode
    {
        public string Id { get; set; }
        public string TitleID { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public ICollection<Title> Titles { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, TitleID = {TitleID}, SeasonNumber = {SeasonNumber}, EpisodeNumber = {EpisodeNumber}, Titles = {Titles}";
        }
    }
}
