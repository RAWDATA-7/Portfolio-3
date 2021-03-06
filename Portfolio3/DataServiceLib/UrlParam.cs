namespace DataServiceLib
{
    public class UrlParam
    {
        private int _pageSize = 12;
        public const int MaxPageSize = 25;
        public int Page { get; set; } = 0;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string OrderBy { get; set; }
    }
}
