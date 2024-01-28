using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using STOCTABLE.Application.Interfaces;
using STOCTABLE.Application.Services;
using STOCTABLE.Domain.Identity;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;
using STOCTABLE.Persistence.Persistences;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;
// Add services to the container.

string? PGSQLConString = Environment.GetEnvironmentVariable("STOCTABLE_CONN_STRING_PGSQL");

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<StoctableContext>(options =>
        options.UseNpgsql(PGSQLConString));

builder.Services.AddIdentityCore<User>(opt =>
    {
        opt.Password.RequiredLength = 6;
        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<Role>()
    .AddRoleManager<RoleManager<Role>>()
    .AddSignInManager<SignInManager<User>>()
    .AddRoleValidator<RoleValidator<Role>>()
    .AddEntityFrameworkStores<StoctableContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
    
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
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<IFabricanteService, FabricanteService>();

builder.Services.AddScoped<IGeneralPersistence, GeneralPersistence>();
builder.Services.AddScoped<IProdutoPersistence, ProdutoPersistence>();
builder.Services.AddScoped<IFabricantePersistence, FabricantePersistence>();
builder.Services.AddScoped<IUsuarioPersistence, UsuarioPersistence>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "STOCTABLE API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header com Bearer.
                        Para gerar a autorização entre com o seu token no campo a seguir,
                        ex: 'Bearer eI38Je02-J*...' (inserir a palavra Bearer, espaço token)",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    }) ;
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
