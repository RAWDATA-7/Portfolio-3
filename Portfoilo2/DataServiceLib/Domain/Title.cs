using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib.FuncDomain;

namespace DataServiceLib.Domain
{
	public class Title
    {
		public string Id { get; set; }
		public string Type { get; set; }
		public string PrimaryTitle { get; set; }
		public string OriginalTitle { get; set; }
		public bool IsAdult { get; set; }
		public int? StartYear { get; set; }
		public int? EndYear { get; set; }
		public int? RunTimeMinutes { get; set; }
		public string Poster { get; set; }
		public string Awards { get; set; }
		public string Plot { get; set; }
		[NotMapped]
        public List<PopularActor> PopularActors { get; set; }

        public ICollection<Principals> Principals { get; set; }
		public ICollection<Aka> Akas { get; set; }
		public ICollection<Genre> Genres { get; set; }
		public ICollection<Episode> Episodes { get; set; }

		public override string ToString()
		{
			return $"Id = {Id}, Type = {Type}, PTitle = {PrimaryTitle}, OTitle = {OriginalTitle}, IsAdult = {IsAdult}, StartYear = {StartYear}, EndYear = {EndYear}," +
				$" RunTimeMinutes = {RunTimeMinutes}, Poster = {Poster}, Awards = {Awards}, Plot = {Plot}, Principals = {Principals}, " +
				$"Akas = {Akas}, Genres = {Genres}, Episodes = {Episodes}";
		}
	}
}
