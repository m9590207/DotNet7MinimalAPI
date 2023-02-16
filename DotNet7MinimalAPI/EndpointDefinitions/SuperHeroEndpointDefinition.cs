using Application.SuperHeroes.Commands;
using Application.SuperHeroes.Queries;
using Domain.Models;
using DotNet7MinimalAPI.Abstractions;
using DotNet7MinimalAPI.Filters;
using MediatR;

namespace DotNet7MinimalAPI.EndpointDefinitions
{
    public class SuperHeroEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("api/SuperHero");

            posts.MapGet("/{id}", GetSuperHeroById)
                .WithOpenApi(operation => new(operation)
                 {
                     Summary = "查詢",
                     Description = "傳入id查詢一個super hero"
                });

            posts.MapPost("/", CreateSuperHero)
                .AddEndpointFilter<SuperHeroValidationFilter>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "新增",
                    Description = "新增一個super hero"
                });

            posts.MapGet("/", GetAllSuperHeroes)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "查詢",
                    Description = "查詢所有super hero"
                });

            posts.MapPut("/{id}", UpdateSuperHero)
                .AddEndpointFilter<SuperHeroValidationFilter>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "修改",
                    Description = "修改一個super hero"
                }); 

            posts.MapDelete("/{id}", DeleteSuperHero)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "刪除",
                    Description = "刪除一個super hero"
                });
        }

        private async Task<IResult> GetSuperHeroById(IMediator mediator, int id)
        {
            var getSuperHero = new GetSuperHeroById { HeroId = id };
            var superHero = await mediator.Send(getSuperHero);
            return TypedResults.Ok(superHero);
        }

        private async Task<IResult> CreateSuperHero(IMediator mediator, SuperHero SuperHero)
        {
            var createSuperHero = new CreateSuperHero { Name = SuperHero.Name, Place = SuperHero.Place };
            var createdSuperHero = await mediator.Send(createSuperHero);
            return Results.CreatedAtRoute("GetSuperHeroById", new { createdSuperHero.Id }, createdSuperHero);
        }

        private async Task<IResult> GetAllSuperHeroes(IMediator mediator)
        {
            var getCommand = new GetAllSuperHeroes();
            var superHeroes = await mediator.Send(getCommand);
            return TypedResults.Ok(superHeroes);
        }

        private async Task<IResult> UpdateSuperHero(IMediator mediator, SuperHero SuperHero, int id)
        {
            var updateSuperHero = new UpdateSuperHero { HeroId = id, Name = SuperHero.Name, Place = SuperHero.Place };
            var updatedSuperHero = await mediator.Send(updateSuperHero);
            return TypedResults.Ok(updatedSuperHero);
        }

        private async Task<IResult> DeleteSuperHero(IMediator mediator, int id)
        {
            var deleteSuperHero = new DeleteSuperHero { HeroId = id };
            await mediator.Send(deleteSuperHero);
            return TypedResults.NoContent();
        }

    }

}
