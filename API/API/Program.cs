
using API.Data;
using API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
      
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AsianGroupDatabase"));
            });

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddCors(options =>
            {
             options.AddDefaultPolicy(
                   policy =>
                   {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();                                                        
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();



           app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}