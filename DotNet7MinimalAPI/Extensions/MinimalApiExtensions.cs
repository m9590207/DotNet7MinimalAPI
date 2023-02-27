using Application.Abstractions;
using Application.SuperHeroes.Commands;
using DataAccess;
using DataAccess.Repositories;
using DotNet7MinimalAPI.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotNet7MinimalAPI.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<SuperHeroDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();
            builder.Services.AddMediatR(typeof(CreateSuperHero));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin() 
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            //反射//(會影響效能,但註冊的動作只有在啓動時執行一次,
            //所以增加一些啓動時間換以後新增許多EndpointDefinition可自動註冊的便利)
            //找到實作IEndpointDefinition不是抽象也不是介面,可以Create Instance的Assembly
            //自動註冊所有實作IEndpointDefinition的EndpointDefinition
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                    && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var endpointDef in endpointDefinitions)
            {
                endpointDef.RegisterEndpoints(app);
            }
        }
    }
}
