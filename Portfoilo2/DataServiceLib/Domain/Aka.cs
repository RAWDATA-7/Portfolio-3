using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
	public class Aka
    {
		public string TitleID { get; set; }
		public int Ordering { get; set; }
		public string TitleName { get; set; }
		public string Region { get; set; }
		public string Language { get; set; }
		public string Types { get; set; }
		public string Attributes { get; set; }
		public bool IsOriginalTitle { get; set; }
		public Title Title { get; set; }

		public override string ToString()
		{
			return $"TitleID = {TitleID}, Ordering = {Ordering}, TitleName = {TitleName}, Region = {Region}, Language = {Language}, " +
				$"Types = {Types}, Attributes = {Attributes}, IsOriginalTitle = {IsOriginalTitle}, Title = {Title}";
		}
	}
}
