using Microsoft.EntityFrameworkCore;
using WebCourseRepo.Models;

namespace WebCourseRepo.Configurations
{
    public class EntityContext : DbContext
    {
        public DbSet<Status> Status { get; set; }
        public DbSet<TopicType> TopicTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicFeedback> TopicFeedbacks { get; set; }
        
       

        public EntityContext(DbContextOptions options) : base(options)
        {

        }
        public void Traceable(ModelBuilder builder, Type type)
        {
            builder.Entity(type).Property("CreatedDate").HasDefaultValueSql("getdate()");
            builder.Entity(type).Property("UpdatedDate").HasDefaultValueSql("getdate()");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedStatus(modelBuilder);
          

        }
        

        private void SeedStatus(ModelBuilder modelBuilder)
        {
            Status activo = new Status(1, "Active");
            modelBuilder.Entity<Status>().HasData(
                activo,
                new Status(2, "Disabled"),
                new Status(3, "In Progress"),
                new Status(4, "Cancelled"),             
                new Status(5, "Completed")
            );

            modelBuilder.Entity<Tag>().HasData(
                 new
                 {
                     Id = 1,
                     Name = "Python", 
                     Popularity = 5, 
                     StatusId =  1
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

            modelBuilder.Entity<TopicType>().HasData(
              new
              {
                  Id = 1,
                  Name = "Video"
              },
              new
              {
                  Id = 2,
                  Name = "Audio"

              },
              new
              {
                  Id = 3,
                  Name = "HTML"
              },
              new
              {
                  Id = 4,
                  Name = "PDF"
              },
              new
              {
                  Id = 5,
                  Name = "Test"
              }
           );
        }
    }
}