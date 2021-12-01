namespace DataServiceLib.Domain
{
	public class Aka
    {
		public string TitleId { get; set; }
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
			return $"TitleId = {TitleId}, Ordering = {Ordering}, TitleName = {TitleName}, Region = {Region}, Language = {Language}, " +
				$"Types = {Types}, Attributes = {Attributes}, IsOriginalTitle = {IsOriginalTitle}, Title = {Title}";
		}
	}
}
