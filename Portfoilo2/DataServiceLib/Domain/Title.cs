using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class Title
    {
		public string Id { get; set; }
		public string Type { get; set; }
		public string PTitle { get; set; }
		public string OTitle { get; set; }
		public bool IsAdult { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
		public int RunTimeMinutes { get; set; }
		public string Poster { get; set; }
		public string Awards { get; set; }
		public string Plot { get; set; }

		public ICollection<Principals> Principals { get; set; }
		public ICollection<KnownForTitles> KnownForTitles { get; set; }
		public ICollection<Index> Index { get; set; }

		public ICollection<Aka> Akas { get; set; }
		public ICollection<Genre> Genres { get; set; }

		public ICollection<Episode> Episodes { get; set; }

		public ICollection<Bookmark> Bookmarks { get; set; }

		public Rating Rating { get; set; }

		public override string ToString()
		{
			return $"Id = {Id}, Type = {Type}, PTitle = {PTitle}, OTitle = {OTitle}, IsAdult = {IsAdult}, StartYear = {StartYear}, EndYear = {EndYear}," +
				$" RunTimeMinutes = {RunTimeMinutes}, Poster = {Poster}, Awards = {Awards}, Plot = {Plot}, Principals = {Principals}, " +
				$"KnownForTitles = {KnownForTitles}, Index = {Index}, Akas = {Akas}," +
				$"Genres = {Genres}, Episodes = {Episodes}, Bookmarks = {Bookmarks}, Rating = {Rating}";
		}
	}
}
