using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() {Name = "Dotnet", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() {Name = "Sql", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() {Name = "Kubernetis", Publisher = "Cloud Native Computing Foundation", Cost = "Free"}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We alredy have data");
            }
        }
    }
}