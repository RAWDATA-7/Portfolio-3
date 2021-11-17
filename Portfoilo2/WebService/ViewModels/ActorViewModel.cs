using System.Collections.Generic;

namespace WebService.ViewModels
{
    public class ActorViewModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public decimal? Rating { get; set; }
        public List<string> Professions { get; set; }
        public List<string> Principals { get; set; }
        public List<string> PopularTitles { get; set; }
        public List<string> CoActors { get; set; }

    }
}