using Domain.Models;
using MediatR;

namespace Application.SuperHeroes.Queries
{
    public class GetAllSuperHeroes : IRequest<ICollection<SuperHero>>
    {
    }
}
