using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class Rating
    {
        public string TitleId { get; set; }
        public decimal AvgRating { get; set; }
        public int NumVotes { get; set; }

        public ICollection<UserRating> UserRatings { get; set; }

        public Title Title { get; set; }

        public override string ToString()
        {
            return $"TitleId = {TitleId}, AvgRating = {AvgRating}, NumVotes = {NumVotes}, UserRatings = {UserRatings}, Title = {Title}";
        }
    }
}
