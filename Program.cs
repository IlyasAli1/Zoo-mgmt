using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Zoo.Data;

namespace Zoo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }
        private static void CreateDbIfNotExists(IHost host)
        {
            using IServiceScope scope = host.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;

            ZooDbContext context = services.GetRequiredService<ZooDbContext>();
            context.Database.EnsureCreated();

            if (!context.Species.Any())
            {
                System.Collections.Generic.IEnumerable<Models.DbModels.SpeciesDbModel> species = SampleSpecies.GetSpecies();
                context.Species.AddRange(species);
                context.SaveChanges();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
        }
    }
}
