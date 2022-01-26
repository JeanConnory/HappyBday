using HappyBday.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyBday.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<Parentesco> Parentescos { get; set; }
    }
}