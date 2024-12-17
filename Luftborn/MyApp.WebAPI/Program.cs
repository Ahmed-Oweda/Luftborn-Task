using MyApp.Application.Profiles;
using MyApp.Application.Services;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure;
using MyApp.WebAPI.Middlewares;

namespace MyApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddInfrastructure(builder.Configuration);
            // Add services to the container.

            builder.Services.AddAutoMapper(typeof(EmployeeProfile).Assembly);
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddCors(options =>
            {
                string frontAppURL = builder.Configuration.GetValue<string>("MyAppFrontURL");
                options.AddPolicy("AllowMyAppFront", req =>
                {
                        req.WithOrigins(frontAppURL)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

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

            app.UseCors("AllowMyAppFront");
            app.UseMiddleware<ExceptionMiddleware>(); //register Exception handler Middleware
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
