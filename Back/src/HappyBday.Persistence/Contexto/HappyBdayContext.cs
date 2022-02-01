using HappyBday.Domain;
using Microsoft.EntityFrameworkCore;

namespace HappyBday.Persistence.Contexto
{
    public class HappyBdayContext : DbContext
    {
        public HappyBdayContext(DbContextOptions<HappyBdayContext> options) : base(options)
        {            
        }

        public DbSet<Parentesco> Parentescos { get; set; }

        public DbSet<Aniversario> Aniversarios { get; set; }
    }
}