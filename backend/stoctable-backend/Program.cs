using Microsoft.EntityFrameworkCore;
using stoctable_backend.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

string ConString = Environment.GetEnvironmentVariable(variable: "CONNECTION_STRING_PGSQL");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<StoctableContext>(options =>
    options.UseNpgsql(ConString));

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
