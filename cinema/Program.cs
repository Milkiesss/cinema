using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Application.Interfaces.Services.Authentication;
using cinema.Application.Services;
using cinema.Infrastructure.Authentication;
using cinema.Infrastructure.Dal.EntityFramework;
using cinema.Infrastructure.Dal.Repository;
using Microsoft.EntityFrameworkCore;

namespace cinema.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddSingleton<IGoogleStorageService, GoogleStorageService>();

            builder.Services.AddScoped<ISeatsRepository, SeatsRepository>();
            builder.Services.AddScoped<ISeatsService, SeatsService>();

            builder.Services.AddScoped<IAuditoriumRepository, AuditoriumRepository>();
            builder.Services.AddScoped<IAuditoriumService, AuditoriumService>();

            builder.Services.AddScoped<IScreeningManagementService, ScreeningManagementService>();
            builder.Services.AddScoped<ISeatManagementService, SeatManagementService>();
    
            builder.Services.AddScoped<IScreeningRepository, ScreeningRepository>();
            builder.Services.AddScoped<IScreeningService, ScreeningService>();
            
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            

            builder.Services.AddMemoryCache();
            

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<DataContext>(option =>
            {
                option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
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
            app.UseAuthentication();//todo


            app.MapControllers();

            app.Run();
        }
    }
}
