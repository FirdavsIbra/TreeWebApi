using Microsoft.EntityFrameworkCore;
using Tree.DBCodeFirst.DbContexts;
using Tree.Domain.RepositoryInterfaces;
using Tree.Domain.ServiceInterfaces;
using Tree.Repository.Mappers;
using Tree.Repository.Repositories;
using Tree.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("TreeConnection")));
builder.Services.AddScoped<ITreeRepository, TreeRepository>();
builder.Services.AddScoped<IPlotRepository, PlotRepository>();
builder.Services.AddScoped<ITreeSortRepository, TreeSortRepository>();
builder.Services.AddScoped<ITreeTypeRepository, TreeTypeRepository>();

builder.Services.AddScoped<ITreeTypeService, TreeTypeService>();
builder.Services.AddScoped<ITreeSortService, TreeSortService>();
builder.Services.AddScoped<IPlotService, PlotService>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

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
