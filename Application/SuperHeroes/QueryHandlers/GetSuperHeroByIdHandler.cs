using Application.Abstractions;
using Application.SuperHeroes.Queries;
using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.QueryHandlers
{
    public class GetSuperHeroByIdHandler : IRequestHandler<GetSuperHeroById, SuperHero>
    {
        private readonly ISuperHeroRepository _superHeroRepo;
        public GetSuperHeroByIdHandler(ISuperHeroRepository superHeroRepo)
        {
            _superHeroRepo = superHeroRepo;
        }

        public async Task<SuperHero> Handle(GetSuperHeroById request, CancellationToken cancellationToken)
        {
            return await _superHeroRepo.GetSuperHeroById(request.HeroId);
        }
    }
}
