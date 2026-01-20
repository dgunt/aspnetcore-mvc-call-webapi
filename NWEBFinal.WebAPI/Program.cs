
using Microsoft.EntityFrameworkCore;
using NWEBFinal.Application.Mappings;
using NWEBFinal.Application.Services;
using NWEBFinal.Infrastructure;
using System;

namespace NWEBFinal.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //DbContext
            builder.Services.AddDbContext<NWebFinalDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("NWEBFinalConnection")));

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            //Đăng ký service
            builder.Services.AddScoped<IStudentService, StudentService>();

            // Add services to the container.

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
        }
    }
}
