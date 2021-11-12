using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.Domain;
using DataServiceLib.FuncDomain;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class TitleViewModel
    {
		public string Url { get; set; }
		public string Id { get; set; }
		public string Type { get; set; }
		public string PrimaryTitle { get; set; }
		public string OriginalTitle { get; set; }
		public bool IsAdult { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
		public int RunTimeMinutes { get; set; }
		public string Poster { get; set; }
		public string Awards { get; set; }
		public string Plot { get; set; }
		public IList<string> Genres { get; set; }
        public decimal Rating { get; set; }
        public int NumVotes { get; set; }
		public string AkaUrl { get; set; }
    }
}
