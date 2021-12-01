using System;

namespace DataServiceLib.Domain
{
    public class SearchHistory
    {
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }

        public override string ToString()
        {
            return $"UserId = {UserId}, TimeStamp = {TimeStamp}, Word = {Word}, Field = {Field}";
        }
    }
}
