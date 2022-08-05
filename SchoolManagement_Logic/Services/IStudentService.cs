using SchoolManagement_Model.Models;

namespace SchoolManagement_Logic.Services
{
    public interface IStudentService
    {
        Task DeleteStudent(int id);
        Task<StudentModel?> GetStudent(int id);
     
        Task<IEnumerable<StudentModel>> GetStudents();
        Task InsertStudent(StudentCreateModel student);
        Task UpdateStudent(StudentUpdateModel student);

        Task<StudentCourseModel?> GetStudentsCourse(int id);
        Task<IEnumerable<StudentsTeachersModel?>> GetStudentsTeachers(int id);

        Task<StudentsTotalTuitionModel> GetTotalTuition(int studentId);
    }
}