using System.Collections.Generic;

namespace DataServiceLib.Domain
{
    public class Episode
    {
        public string Id { get; set; }
        public string TitleId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public ICollection<Title> Titles { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, TitleID = {TitleId}, SeasonNumber = {SeasonNumber}, EpisodeNumber = {EpisodeNumber}, Titles = {Titles}";
        }
    }
}
