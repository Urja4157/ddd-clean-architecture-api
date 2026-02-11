using Carter;
using DDD.Application;
using DDD.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationService();
builder.Services.AddPersistenceService(builder.Configuration);

builder.Services.AddCarter();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDD API V1");
        c.RoutePrefix = string.Empty; // <-- This makes Swagger the root page
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapCarter();
app.MapControllers();

app.Run();
