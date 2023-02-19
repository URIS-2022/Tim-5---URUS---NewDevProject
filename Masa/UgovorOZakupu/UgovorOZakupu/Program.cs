using Microsoft.EntityFrameworkCore;
using UgovorOZakupu.Data;
using UgovorOZakupu.Interfaces;
using UgovorOZakupu.Repository;
using AutoMapper;
using UgovorOZakupu;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDokumentRepository, DokumentRepository>();
builder.Services.AddScoped<IJavnoNadmetanjeRepository, JavnoNadmetanjeRepository>();
builder.Services.AddScoped<IKupacRepository, KupacRepository>();
builder.Services.AddScoped<ILicnostRepository, LicnostRepository>();
builder.Services.AddScoped<IUgovorOZakupuRepository, UgovorOZakupuRepository>();



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
