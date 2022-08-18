using Microsoft.AspNetCore.Mvc;
using SchoolManagement_Model.Models;

namespace SchoolManagement_Logic.Services
{
    public interface ITeacherService
    {
        Task DeleteTeacher(int id);
        Task<TeacherModel?> GetTeacher(int id);
        Task<IEnumerable<TeacherModel>> GetTeachers();
        Task<IEnumerable<MessagePublishDto>> GetMessages();
        Task<IEnumerable<MessageByDoctorIdDto?>> GetMessge_ByTeacherId(int id);
        Task CreateMessage(MessagePublishDto message);
        Task InsertTeacher(TeacherCreateModel teacher);
        Task UpdateTeacher(TeacherUpdateModel teacher);
        Task<IEnumerable<TeachersStudentsModel?>> GetTeachersStudents(int id);
    }
}