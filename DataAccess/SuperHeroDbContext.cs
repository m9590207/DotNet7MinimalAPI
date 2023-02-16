using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SuperHeroDbContext : DbContext
    {
        public SuperHeroDbContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
