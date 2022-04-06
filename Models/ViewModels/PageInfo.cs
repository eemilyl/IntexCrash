using System;
using System.Collections.Generic;

namespace intex2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumAccidents { get; set; }

        public int AccidentsPerPage { get; set; }

        public int CurrentPage { get; set; }

        //Figure out how many pages we need 
        public int TotalPages => (int)Math.Ceiling((double) TotalNumAccidents / AccidentsPerPage);

    }
}
