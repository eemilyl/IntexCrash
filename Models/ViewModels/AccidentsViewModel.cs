using System;
using System.Collections.Generic;
using System.Linq;

namespace intex2.Models.ViewModels
{
    public class AccidentsViewModel
    {
        public List<Accident> Accidents { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}