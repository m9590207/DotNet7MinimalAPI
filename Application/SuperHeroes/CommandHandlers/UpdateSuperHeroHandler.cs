using Application.Abstractions;
using Application.SuperHeroes.Commands;
using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.CommandHandlers
{
    public class UpdateSuperHeroHandler : IRequestHandler<UpdateSuperHero, SuperHero>
    {
        private readonly ISuperHeroRepository _superHeroRepo;
        public UpdateSuperHeroHandler(ISuperHeroRepository superHeroRepo)
        {
            _superHeroRepo = superHeroRepo;
        }

        public async Task<SuperHero> Handle(UpdateSuperHero request, CancellationToken cancellationToken)
        {
            var hero = await _superHeroRepo.UpdateSuperHero(request.Name, request.Place, request.HeroId);
            return hero;
        }
    }
}
