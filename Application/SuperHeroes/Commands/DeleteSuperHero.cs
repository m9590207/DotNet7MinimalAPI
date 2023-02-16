using MediatR;

namespace Application.SuperHeroes.Commands
{
    public class DeleteSuperHero : IRequest
    {
        public int HeroId { get; set; } 
    }
}
