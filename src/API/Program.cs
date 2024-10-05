
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.AddDbContext<ApplicationDbContext>();

            //QUEM PEDIR A INTERFACE IStudentRepository, eu vou devolver a classe concreta StudentRepository (isso é injeção de dependência)
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IPremiumRepository, PremiumRepository>();
            builder.Services.AddScoped<IPremiumAppServices, PremiumAppServices>();
            builder.Services.AddScoped<IStudentAppServices, StudentAppServices>();





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
        }
    }
}
