
using Microsoft.EntityFrameworkCore;
using Oona.AppWebTwo.Application.Interfaces.ICountryServices;
using Oona.AppWebTwo.Application.Interfaces.UnitOfWorkServices;
using Oona.AppWebTwo.Application.Sevices.CountryServices;
using Oona.AppWebTwo.Core.Domain.Interfaces;
using Oona.AppWebTwo.Infrastructure.Data;
using Oona.AppWebTwo.Infrastructure.Data.IRepository;
using Oona.AppWebTwo.Infrastructure.Data.Repository;
using System.Text.Json.Serialization;

namespace Oona.AppWebTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddMemoryCache();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(origin => true) // allow any origin you can change here to allow localhost:4200
                        .AllowCredentials();
            }));
            //-----------------------Add services---------------------------------
            builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
