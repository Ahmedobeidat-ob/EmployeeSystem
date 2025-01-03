
using IGTask.Core.Configrations;
using IGTask.Core.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using IGTask.Core.IRepository;
using IGTask.Infra.Repository;
using IGTask.Core.IService;
using IGTask.Infra.Service;

namespace IGTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("IGTaskConnection");

            if (connectionString == null)
            {
                Console.WriteLine("Connection string not found.");

            }
            else
            {
               using(var connection= new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur when trying to open the connection
                        Console.WriteLine("An error occurred while trying to open the connection: " + ex.Message);
                    }
                }
            }

            builder.Services.AddDbContext<IGTaskDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            // Add services to the container.
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IEmployeesService, EmployeesService>();
            builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("AllowAll", p => p.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
            });
            builder.Services.AddControllers();

            // Enable static file serving
            builder.Services.AddDirectoryBrowser();

         

          
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            var app = builder.Build();
            // Serve static files
            app.UseStaticFiles();
            app.UseDirectoryBrowser();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}