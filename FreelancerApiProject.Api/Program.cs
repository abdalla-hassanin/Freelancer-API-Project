using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FreelancerApiProject.Core;
using FreelancerApiProject.Core.Base.MiddleWare;
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure middleware pipeline
ConfigureMiddleware(app);

app.Run();
return;

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    ConfigureSwagger(services);
    ConfigureIdentity(services);
    ConfigureJwtAuthentication(services, configuration);
    ConfigureDatabase(services, configuration);
    ConfigureLocalization(services);
    ConfigureCors(services);
    RegisterApplicationServices(services);
}

void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth Service", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });
}

void ConfigureIdentity(IServiceCollection services)
{
    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    services.Configure<IdentityOptions>(options =>
    {
        options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ " +
            "أبجدهوزحطيكلمنسعفصقرشتثخذضظغ";
        options.User.RequireUniqueEmail = true;
    });
}

void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
{
    var jwtSettings = configuration.GetSection("JWT");
    var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = JwtRegisteredClaimNames.Sub,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

    services.AddAuthorization();
}

void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
}

void ConfigureLocalization(IServiceCollection services)
{
    services.AddLocalization(opt => opt.ResourcesPath = "");

    services.Configure<RequestLocalizationOptions>(options =>
    {
        var supportedCultures = new List<CultureInfo>
        {
            new("en-US"),
            new("de-DE"),
            new("fr-FR"),
            new("ar-EG")
        };

        options.DefaultRequestCulture = new RequestCulture("en-US");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });
}

void ConfigureCors(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddDefaultPolicy(corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
    });
}

void RegisterApplicationServices(IServiceCollection services)
{
    services.AddInfrastructureDependencies()
        .AddServiceDependencies()
        .AddCoreDependencies();
}

void ConfigureMiddleware(WebApplication application)
{
    if (application.Environment.IsDevelopment())
    {
        application.UseSwagger();
        application.UseSwaggerUI();
    }

    application.UseMiddleware<ErrorHandlerMiddleware>();

    application.UseHttpsRedirection();
    application.UseRouting();
    application.UseCors();
    application.UseAuthentication();
    application.UseAuthorization();

    var localizationOptions = application.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
    application.UseRequestLocalization(localizationOptions.Value);

    application.MapControllers();
}