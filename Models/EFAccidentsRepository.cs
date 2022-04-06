using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace intex2.Models
{
    public class EFAccidentsRepository : IAccidentsRepository
    {
        private AccidentsDbContext _context { get; set; }

        public EFAccidentsRepository(AccidentsDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Accident> Accidents => _context.Accidents;

    }
}

