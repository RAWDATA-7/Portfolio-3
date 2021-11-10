using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class BestRatedActorListViewModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string Name { get; set; }
        public decimal? Rating { get; set; }
    }
    public class CreateBestRatedActorListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public decimal? Rating { get; set; }

    }
}
