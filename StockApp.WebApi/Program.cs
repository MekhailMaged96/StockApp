using StockApp.Application;
using StockApp.Infrastructure;
using StockApp.Infrastructure.Hubs;
using StockApp.WebApi.Extensions;
using StockApp.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();




app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<StockHub>("/stockHub");
    endpoints.MapControllers();
});


await app.InitialiseDatabaseAsync();

app.Run();
