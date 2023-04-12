﻿using BLL.Models;
using BLL.Models.Exceptions;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository repo;

        public CourseService(ICourseRepository repo)
        {
            this.repo = repo;
        }
        public int AddCourse(CourseModel course)
        {
            Course courseEntity = new Course
            {
                CourseTypeName = course.CourseTypeName,
                InstituteId = course.InstituteId,
                TeacherId = course.TeacherId,
                Salary = course.Salary
            };

            int courseId = repo.Add(courseEntity);

            return courseId;
        }

        public CourseModel GetCourseById(int id)
        {
            Course? courseEntity = repo.GetById(id);
            if (courseEntity == null)
            {
                throw new ValidationException("Course doesn't exist");
            }

            return new CourseModel
            {
                CourseId = courseEntity.CourseId,
                InstituteName = courseEntity.Institute.InstituteTypeName,
                TeacherName = courseEntity.Teacher.FirstName,
            };
        }

        public List<CourseModel> Get()
        {
            List<Course> courseEntities = repo.Get();

            if (!courseEntities.Any())
            {
                throw new ValidationException("We have no any courses");
            }

            var courses = new List<CourseModel>();

            foreach (var item in courseEntities)
            {
                courses.Add(new CourseModel { CourseTypeName = item.CourseTypeName, InstituteId = item.InstituteId, TeacherId = item.TeacherId, Salary = item.Salary });
            }
            return courses;
        }

        public void Update(int id, CourseModel course)
        {
            var courseEntity = new Course
            {
                CourseId = id,
                CourseTypeName = course.CourseTypeName,
                InstituteId = course.InstituteId,
                TeacherId = course.TeacherId,
                Salary = course.Salary
            };
            repo.Update(id, courseEntity);
        }

    }
}
