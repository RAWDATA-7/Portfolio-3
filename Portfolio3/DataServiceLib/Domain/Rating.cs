namespace DataServiceLib.Domain
{
    public class Rating
    {
        public string TitleId { get; set; }
        public decimal AvgRating { get; set; }
        public int NumVotes { get; set; }

        public override string ToString()
        {
            return $"TitleId = {TitleId}, AvgRating = {AvgRating}, NumVotes = {NumVotes}";
        }
    }
}
