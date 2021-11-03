using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class Principals
    {
		public string TitleID { get; set; }
		public int Ordering { get; set; }
		public string ActorID { get; set; }
		public string Category { get; set; }
		public string Job { get; set; }
		public string Characters { get; set; }

		public ICollection<Actor> Actors { get; set; }

		public ICollection<Title> Titles { get; set; }

		public override string ToString()
		{
			return $"TitleID = {TitleID}, Ordering = {Ordering}, ActorID = {ActorID}, Category = {Category}, Job = {Job}, Characters = {Characters}," +
				$" Actors = {Actors}, Titles = {Titles}";
		}
	}
}
