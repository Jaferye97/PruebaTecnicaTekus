using WebApi.Extensions.DependencyInjection;
using WebApi.Extensions.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddMvcWithAuthorization()
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerDocumentation()
    .AddInfrastructure(builder.Configuration)
    .AddRepositories()
    .AddApplicationUseCases()
    .AddCacheServices()
    .AddCorsPolicies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularClient");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
