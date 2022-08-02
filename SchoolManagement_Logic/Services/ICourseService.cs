using SchoolManagement_Model.Models;

namespace SchoolManagement_Logic.Services
{
    public interface ICourseService
    {
        Task DeleteCourse(int id);
        Task<CourseModel?> GetCourse(int id);
        Task<IEnumerable<CourseModel>> GetCourses();
        Task InsertCourse(CourseModel course);
        Task UpdateCourse(CourseModel course);
    }
}