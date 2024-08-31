using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;
namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Get the connection string settings
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyDbContext>(op => op.UseSqlServer(ConnectionStringVar));


            // Add Identity Service
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDbContext>();

            //builder.Services.AddTransient<IEmployee, EmployeeService>();
            builder.Services.AddScoped<IAccountRepository, IdentityAccountService>();

            // Add services to the container.
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            builder.Services.AddScoped<ISongRepository, SongRepository>();
            builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
            builder.Services.AddScoped<JwtTokenService>();



            // add auth service to the app using jwt
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
                });

            // Add Policy Authorization
            builder.Services.AddAuthorization(options =>
            {
                //options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("full_access", policy =>
                    policy.RequireClaim("ClaimsAccess", "full_access"));
                //options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
                options.AddPolicy("update", policy =>
                    policy.RequireClaim("ClaimsAccess", "update"));
            });



            // swagger configuration
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("tunifyApi", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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



            var app = builder.Build();

            // call Identity UseAuthentication
            app.UseAuthentication();
            app.UseAuthorization();

            // call swagger service
            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             });

            // call swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/tunifyApi/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });



            app.MapControllers();
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
