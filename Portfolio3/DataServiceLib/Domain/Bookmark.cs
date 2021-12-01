namespace DataServiceLib.Domain
{
    public class Bookmark
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }

        public override string ToString()
        {
            return $"UserId = {UserId}, TitleId = {TitleId}";
        }
    }
}
