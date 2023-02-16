using Application.Abstractions;
using Application.SuperHeroes.Commands;
using MediatR;

namespace Application.SuperHeroes.CommandHandlers
{
    public class DeleteSuperHeroHandler : IRequestHandler<DeleteSuperHero>
    {
        private readonly ISuperHeroRepository _superHeroRepo;
        public DeleteSuperHeroHandler(ISuperHeroRepository superHeroRepo)
        {
            _superHeroRepo = superHeroRepo;
        }

        public async Task<Unit> Handle(DeleteSuperHero request, CancellationToken cancellationToken)
        {
            await _superHeroRepo.DeleteSuperHero(request.HeroId);
            return Unit.Value;
        }       
    }
}
