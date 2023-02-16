using Application.Abstractions;
using Application.SuperHeroes.Queries;
using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.QueryHandlers
{
    public class GetAllSuperHeroesHandler : IRequestHandler<GetAllSuperHeroes, ICollection<SuperHero>>
    {
        private readonly ISuperHeroRepository _superHeroRepo;
        public GetAllSuperHeroesHandler(ISuperHeroRepository superHeroRepo)
        {
            _superHeroRepo= superHeroRepo;
        }
        public async Task<ICollection<SuperHero>> Handle(GetAllSuperHeroes request, CancellationToken cancellationToken)
        {
            return await _superHeroRepo.GetAllSuperHeroes();
        }
    }
}
