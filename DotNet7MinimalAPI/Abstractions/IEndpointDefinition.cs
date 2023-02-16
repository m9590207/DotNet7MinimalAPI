namespace DotNet7MinimalAPI.Abstractions
{
    public interface IEndpointDefinition
    {
        void RegisterEndpoints(WebApplication app);
    }
}
