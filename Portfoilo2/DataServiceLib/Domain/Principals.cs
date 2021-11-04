using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
	public class Principals
    {
		public string TitleId { get; set; }
		public int Ordering { get; set; }
		public string ActorId { get; set; }
		public string Category { get; set; }
		public string Job { get; set; }
		public string Characters { get; set; }

		public ICollection<Actor> Actors { get; set; }

		public ICollection<Title> Titles { get; set; }

		public override string ToString()
		{
			return $"TitleId = {TitleId}, Ordering = {Ordering}, ActorId = {ActorId}, Category = {Category}, Job = {Job}, Characters = {Characters}," +
				$" Actors = {Actors}, Titles = {Titles}";
		}
	}
}
