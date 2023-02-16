using Application.Abstractions;
using Application.SuperHeroes.Commands;
using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.CommandHandlers
{
    public class CreateSuperHeroHandler : IRequestHandler<CreateSuperHero, SuperHero>
    {
        private readonly ISuperHeroRepository _superHeroRepo;
        public CreateSuperHeroHandler(ISuperHeroRepository superHeroRepo)
        {
            _superHeroRepo = superHeroRepo;
        }

        public async Task<SuperHero> Handle(CreateSuperHero request, CancellationToken cancellationToken)
        {
            var newHero = new SuperHero 
            {
                Name = request.Name,
                Place = request.Place,
            };
            return await _superHeroRepo.CreateSuperHero(newHero);
        }
    }
}
