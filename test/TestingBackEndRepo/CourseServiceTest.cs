using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using WebCourseRepo.Dtos;
using WebCourseRepo.Models;
using WebCourseRepo.Repositories;
using WebCourseRepo.Services.Implementation;
using Xunit;

namespace TestingBackEndRepo
{
    public class CourseServiceTest
    {
        private readonly CourseService _sut;
        private readonly Mock<ICourseRepository> _courseRepoMock = new Mock<ICourseRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public CourseServiceTest()
        {
            _sut = new CourseService(_courseRepoMock.Object,_mapperMock.Object);
        }

        [Fact]
        public async Task GetAllCoursesById()
        {
            //Arrange
            var courseId = 1;
            var courseName = "Esta es una prueba";
            var courseDescription = "Description";
            var courseDuration = 34.5;
            var courseRating = 34.5;
            var courseDeleted = false;
            var courseCreatedBy = 1;
            var courseUpdatedBy = 1;

            var courseDto = new Course
            {
                Id = courseId,
                Name = courseName,
                Description = courseDescription,
                Duration = courseDuration,
                Rating = courseRating,
                Deleted = courseDeleted,
                CreatedBy = courseCreatedBy,
                UpdatedBy = courseUpdatedBy
            };
            _courseRepoMock.Setup(x => x.FindById(courseId)).ReturnsAsync(courseDto);


            //Act
            var course = await _sut.FindById(courseId);

            //Assert

            Assert.Equal(courseId, course.Id);
            Assert.Equal(courseDescription, course.Description);
            Assert.Equal(courseDuration, course.Duration);
            Assert.Equal(courseRating, course.Rating);
            Assert.Equal(courseDeleted, course.Deleted);
            Assert.Equal(courseCreatedBy, course.CreatedBy);
            Assert.Equal(courseUpdatedBy, course.UpdatedBy);
        }
    }
}