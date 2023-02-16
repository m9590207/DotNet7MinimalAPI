using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly SuperHeroDbContext _ctx;
        public SuperHeroRepository(SuperHeroDbContext ctx)
        {
            _ctx= ctx;
        }
        public async Task<SuperHero> CreateSuperHero(SuperHero toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _ctx.SuperHeroes.Add(toCreate);
            await _ctx.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeleteSuperHero(int heroId)
        {
            var superHero = await _ctx.SuperHeroes
                .FirstOrDefaultAsync(p => p.Id == heroId);
            if (superHero == null) return;

            _ctx.SuperHeroes.Remove(superHero);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<SuperHero>> GetAllSuperHeroes()
        {
            return await _ctx.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero> GetSuperHeroById(int heroId)
        {
            return await _ctx.SuperHeroes.FirstOrDefaultAsync(p => p.Id == heroId);
        }

        public async Task<SuperHero> UpdateSuperHero(string name, string place, int heroId)
        {
            var superHero = await _ctx.SuperHeroes.FirstOrDefaultAsync(p => p.Id == heroId);
            superHero.LastModified = DateTime.Now;
            superHero.Name = name;
            superHero.Place = place;
            await _ctx.SaveChangesAsync();
            return superHero;
        }
    }
}
