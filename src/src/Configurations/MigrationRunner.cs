using System;
using Microsoft.EntityFrameworkCore;
using WebCourseRepo.Models;

namespace WebCourseRepo.Configurations
{
    public static class MigrationRunner
    {
        public static void Run(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<EntityContext>());
            }

        }

        private static void SeedData(EntityContext context)
        {
            try
            {
                if (context.Database.IsRelational())
                {

                    context.Database.Migrate();
                }
                else
                {
                    SeedStatus(context);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private static void SeedStatus(EntityContext context)
        {
            Status activo = new Status(1, "Active");
            context.Set<Status>().AddRangeAsync(
            activo,
            new Status(2, "Disabled"),
            new Status(3, "In Progress"),
            new Status(4, "Cancelled"),
            new Status(5, "Completed"));
            context.SaveChangesAsync();
        }

        private static void SeedTags(EntityContext context)
        {
        
            context.Set<Tag>().AddRangeAsync(
            new
            {
                Id = 1,
                Name = "Python",
                Popularity = 5,
                StatusId = 1
            },
                 new
                 {
                     Id = 2,
                     Name = "C#",
                     Popularity = 5,
                     StatusId = 1
                 },
                 new
                 {
                     Id = 3,
                     Name = "Java",
                     Popularity = 5,
                     StatusId = 1
                 }
                );
            context.SaveChangesAsync();
        }
    }
}