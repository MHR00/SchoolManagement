using SchoolManagement_Logic.DbAccesss;
using SchoolManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Logic.Services
{
    public class CourseService : ICourseService
    {
        private readonly ISqlDataAccess _db;
        public CourseService(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<CourseModel>> GetCourses() =>
            _db.LoadData<CourseModel, dynamic>("dbo.spCourse_GetAll", new { });


        public async Task<CourseModel?> GetCourse(int id)
        {
            var results = await _db.LoadData<CourseModel, dynamic>(
                "dbo.spCourse_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertCourse(CourseModel course) =>
            _db.SaveData("dbo.spCourse_Insert", new
            {
                course.Name,
                course.Tuition,

            });

        public Task UpdateCourse(CourseModel course) =>
            _db.SaveData("dbo.spCourse_Update", course);

        public Task DeleteCourse(int id) =>
            _db.SaveData("dbo.spCourse_Delete", new { Id = id });
    }
}
