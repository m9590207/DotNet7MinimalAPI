using Domain.Models;

namespace Application.Abstractions
{
    public interface ISuperHeroRepository
    {
        Task<ICollection<SuperHero>> GetAllSuperHeroes();
        Task<SuperHero> GetSuperHeroById(int heroId);
        Task<SuperHero> CreateSuperHero(SuperHero toCreate);
        Task<SuperHero> UpdateSuperHero(string name, string place, int heroId);
        Task DeleteSuperHero(int heroId);
    }
}
