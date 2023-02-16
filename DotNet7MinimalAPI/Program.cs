using DotNet7MinimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

//統一錯誤處理middleware
app.Use(async (ctx, next) =>
{
    try
    {
        //捕捉在pipeline的任何地方發生的例外
        await next();
    }
    catch (Exception)
    {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsync("An error ocurred");
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();

