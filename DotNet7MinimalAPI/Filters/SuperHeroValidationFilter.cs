using Domain.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DotNet7MinimalAPI.Filters
{
    public class SuperHeroValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)        {

            var superHero = context.GetArgument<SuperHero>(1);
            if (superHero.Name.IsNullOrEmpty() || superHero.Place.IsNullOrEmpty())
                return await Task.FromResult(Results.BadRequest("SuperHero not valid"));

            return await next(context);
        }
    }
}
