using Microsoft.EntityFrameworkCore;

namespace intex2.Models
{
    public class AccidentsDbContext : DbContext
    {
        public AccidentsDbContext(DbContextOptions<AccidentsDbContext> options) : base(options)
        {

        }

        public DbSet<Accident> Accidents { get; set; }
    }
}