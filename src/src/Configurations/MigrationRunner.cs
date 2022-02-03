using Microsoft.EntityFrameworkCore;
using WebCourseRepo.Models;

namespace WebBackEndRepo.Configurations
{
    public static class MigrationRunner
    {
        public static void Run(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                EntityContext context = serviceScope.ServiceProvider.GetService<EntityContext>()!; 
                SeedData(context);
                DummyData(context);
            }
            
            

        }

        private static void DummyData(EntityContext context)
        {
            CreateCourse(context, "React");
            CreateCourse(context, "Net Core");
            CreateCourse(context, "Angular");
            context.SaveChanges();
        }

        private static void CreateCourse(EntityContext context, string titulo)
        {
            Status valido = context.Status.Find(1)!;
            TopicType video = context.TopicTypes.Find(1)!;
            var curso1 = new Course();
            curso1.Name = $"Curso de {titulo}";
            curso1.Description = $"curso {titulo}";
            curso1.Deleted = false;
            curso1.Duration = 2.5;
            curso1.Rating = 5;
            curso1.Status = valido;
            curso1.CreatedBy = 1;
            curso1.UpdatedBy = 1;
            context.Courses.Add(curso1);
            
            var section1 = new Section();
            section1.Course = curso1;
            section1.Title = $"Introduction a {titulo}";
            section1.Description = $"Introduction a {titulo}";
            section1.Number = 1;
            section1.Status = valido;
            section1.Deleted = false;
            context.Sections.Add(section1);
            var topic = new Topic();
            topic.Title = $"paso 1 de {titulo}";
            topic.Description = $"Descripcion del topico 1 de {titulo}";
            topic.Deleted = false;
            topic.Section = section1;
            topic.Number = 1;
            topic.Type = video;
            context.Topics.Add(topic);
            var topic2 = new Topic();
            topic2.Title = $"paso 2 de {titulo}";
            topic2.Description = $"Descripcion del topico 2 de {titulo}";
            topic2.Deleted = false;
            topic2.Section = section1;
            topic2.Number = 2;
            topic2.Type = video;
            context.Topics.Add(topic2);
            
            var section2 = new Section();
            section2.Course = curso1;
            section2.Title = $"{titulo} Intermedio";
            section2.Description = $"Nivel intermedio de {titulo}";
            section2.Number = 2;
            section2.Status = valido;
            section2.Deleted = false;
            context.Sections.Add(section2);
            var topic3 = new Topic();
            topic3.Title = $"paso 1 de {titulo}";
            topic3.Description = $"Descripcion del topico 1 de {titulo}";
            topic3.Deleted = false;
            topic3.Section = section2;
            topic3.Number = 1;
            topic3.Type = video;
            context.Topics.Add(topic3);
            var topic4 = new Topic();
            topic4.Title = $"paso 2 de {titulo}";
            topic4.Description = $"Descripcion del topico 2 de {titulo}";
            topic4.Deleted = false;
            topic4.Section = section2;
            topic4.Number = 2;
            topic4.Type = video;
            context.Topics.Add(topic4);
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
                    context.Database.EnsureCreated();
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
    }
}