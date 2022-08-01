using SchoolManagement_Model.Models;

namespace SchoolManagement_Logic.Services
{
    public interface IStudentService
    {
        Task DeleteStudent(int id);
        Task<StudentModel?> GetStudent(int id);
        Task<IEnumerable<StudentModel>> GetStudents();
        Task InsertStudent(StudentModel student);
        Task UpdateStudent(StudentModel student);
    }
}