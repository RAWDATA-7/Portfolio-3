﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class BestRatedTitleListViewModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Rating { get; set; }
    }
}
