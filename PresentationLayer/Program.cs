using Autofac;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using PresentationLayer.Utilities;
using System.Collections.ObjectModel;

var builder = WebApplication.CreateBuilder(args);
var autofacBuilder = new ContainerBuilder();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.
autofacBuilder.RegisterModule(new RepositoryModule("Port=5432;Host=localhost;Database=postgres;Username=postgres;Password=ququshka37"));
builder.Services.AddControllers();
var container = autofacBuilder.Build();
var userService = container.Resolve<IUserService>(); // костыль
// TODO: тут singleton или transient, убрать autofac
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var users = new ObservableCollection<UserDTO>(userService.GetUsers());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
