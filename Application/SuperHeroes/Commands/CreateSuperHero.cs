using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.Commands
{
    public class CreateSuperHero : IRequest<SuperHero>
    {
        public string? Name { get; set; }
        public string? Place { get; set; }
    }
}
