using Autofac;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using DataAccessLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Utilities;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var autofacBuilder = new ContainerBuilder();

// Add services to the container.
builder.Services.AddTransient<IDbRepository, DbRepository>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IProtocolService, ProtocolService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRaceService, RaceService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
