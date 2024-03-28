using Autofac;
using PresentationLayer.Utilities;

var builder = WebApplication.CreateBuilder(args);
var autofacBuilder = new ContainerBuilder();

// Add services to the container.
autofacBuilder.RegisterModule(new RepositoryModule("Port=5432;Host=localhost;Database=postgres;Username=postgres;Password=ququshka37;Persist Security Info=True\" providerName=\"Npgsql"));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
