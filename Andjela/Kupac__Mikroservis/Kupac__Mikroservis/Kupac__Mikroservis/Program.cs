using Kupac__Mikroservis.Data;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Repository;
using Kupac_Mikroservis.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAdresaVORepository, AdresaVORepository>();
builder.Services.AddScoped<IKupacRepository, KupacRepository>();
builder.Services.AddScoped<IOvlascenoLiceRepository, OvlascenoLiceRepository>();
builder.Services.AddScoped<IUplataRepository, UplataRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
