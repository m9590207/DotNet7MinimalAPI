using DotNet7MinimalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

//���U�A�Ȧ���t�@����,�O��Program.cs²��
builder.RegisterServices();

var app = builder.Build();

//�Τ@���~�B�zmiddleware
app.Use(async (ctx, next) =>
{
    try
    {
        //�����bpipeline������a��o�ͪ��ҥ~
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

app.UseCors();

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();

