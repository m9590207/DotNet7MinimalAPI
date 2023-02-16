using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.Commands
{
    public class UpdateSuperHero : IRequest<SuperHero>
    {
        public int HeroId { get; set; } 
        public string? Name { get; set; }    
        public string? Place { get; set; }   
    }
}
