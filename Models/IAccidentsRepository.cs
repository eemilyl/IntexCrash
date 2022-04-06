using System;
using System.Collections.Generic;
using System.Linq;

namespace intex2.Models

{
    public interface IAccidentsRepository
    {
        IQueryable<Accident> Accidents { get;  }
    }
}

