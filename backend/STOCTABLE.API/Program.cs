using Microsoft.EntityFrameworkCore;
using STOCTABLE.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string PGSQLConString = Environment.GetEnvironmentVariable("CONNECTION_STRING_PGSQL");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<StoctableContext>(options =>
    options.UseNpgsql(PGSQLConString));


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
