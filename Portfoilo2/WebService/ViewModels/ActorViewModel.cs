using AutoMapper;
using WebService.Controllers;

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
    }

    public class CreateActorViewModel 
    {
        public string Id { get; set; }  
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public decimal? Rating { get; set; }

    }
}