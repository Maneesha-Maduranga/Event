using Event.Api.Context;
using Event.Api.Repository.Implementation;
using Event.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("EventMasterDbConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//Inject the services
builder.Services.AddScoped<IEventItemRepository, EventItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opt => {
    opt.AllowAnyOrigin();
    opt.AllowAnyMethod();
    opt.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
