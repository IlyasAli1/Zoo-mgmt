using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Zoo.Data;
using Zoo.Helper;

namespace Zoo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }
        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ZooDbContext>();

            var exists = DatabaseHelper.CheckDatabaseExistsAndSeeded("Server=localhost,1433;Database=zoo-mgmt;User Id=sa;Password=Password123;", "zoo-mgmt");
            if (!exists)
            {
                var animals = SampleAnimal.GetAnimals().ToList();
                context.Animal.AddRange(animals);
                context.SaveChanges();

                var zookeepers = context.Zookeeper;
                SampleZookeepers.UpdateZookeepers(zookeepers.ToList(), animals);
                context.SaveChanges();

                var transfers = SampleTransfer.GetTransfers(animals);
                context.Transfer.AddRange(transfers);
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
