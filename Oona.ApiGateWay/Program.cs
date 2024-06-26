
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Oona.ApiGateWay
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

            //---------------------Use ocelot getway-------------------------------

            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            //----------------------cash on getway level----------------------------
            builder.Services.AddOcelot(builder.Configuration)
            .AddCacheManager(x =>
             {
                 x.WithDictionaryHandle();
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
            app.UseOcelot();


            app.MapControllers();

            app.Run();
        }
    }
}
