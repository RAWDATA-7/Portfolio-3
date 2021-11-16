using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class BestMatchListViewModel
    {
        public string Url { get; set; }
        public string TitleId { get; set; }
        public int Rank { get; set; }
        public string TitleName { get; set; }
    }
}
