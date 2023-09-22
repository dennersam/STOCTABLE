using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using STOCTABLE.Application.Interfaces;
using STOCTABLE.Application.Services;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;
using STOCTABLE.Persistence.Persistences;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string? PGSQLConString = Environment.GetEnvironmentVariable("CONNECTION_STRING_PGSQL");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<StoctableContext>(options =>
    options.UseNpgsql(PGSQLConString));


builder.Services.AddControllers()
    .AddNewtonsoftJson(x =>
        {
            x.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            x.SerializerSettings.Converters.Add(new StringEnumConverter());
        })
    .AddJsonOptions(opt =>
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
        );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IFabricanteService, FabricanteService>();
builder.Services.AddScoped<IGeneralPersistence, GeneralPersistence>();
builder.Services.AddScoped<IProdutoPersistence, ProdutoPersistence>();
builder.Services.AddScoped<IFabricantePersistence, FabricantePersistence>();


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

builder.Services.AddCors();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
