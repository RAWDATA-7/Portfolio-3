namespace DataServiceLib.Domain
{
    public class Index
    {
        public string TitleId { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }


        public override string ToString()
        {
            return $"TitleId = {TitleId}, Word = {Word}, Field = {Field}";
        }
    }
}
