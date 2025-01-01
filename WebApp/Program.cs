using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();
builder.Services.AddDbContext<DataContext>(opt=>opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITrainerService,TrainerService>();
builder.Services.AddScoped<IClientService,ClientService>();
builder.Services.AddScoped<IWorkoutService,WorkoutService>();
builder.Services.AddScoped<IWorkoutSessionService,WorkoutSessionService>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options=> options.SwaggerEndpoint("/openapi/v1.json","WebApp"));

}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

