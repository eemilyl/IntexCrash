﻿using System;
using System.Linq;

namespace intex2.Models.ViewModels
{
    public class AccidentsViewModel
    {
        public IQueryable<Accident> Accidents { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}