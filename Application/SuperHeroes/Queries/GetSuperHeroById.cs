using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.Queries
{
    public class GetSuperHeroById : IRequest<SuperHero>
    {
        public int HeroId { get; set; }
    }
}
